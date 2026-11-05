using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Games;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Games;

namespace Mimisbrunnr.Services.Games;

public class SnakeService(ApplicationDbContext db, ISessionContextProvider session) : ISnakeService
{
    public async Task<Result<List<SnakeLeaderboardEntry>>> GetLeaderboard(SnakeBoard board, CancellationToken ct)
    {
        var validation = await new SnakeBoard.Validator().ValidateAsync(board, ct);
        if (!validation.IsValid)
            return Result.Invalid(validation.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage)));

        var scores = await (from score in db.SnakeScores.AsNoTracking()
                            join user in db.Users on score.UserId equals user.Id
                            where score.Width == board.Width && score.Height == board.Height
                            group score by new { user.Id, user.UserName } into player
                            select new { Username = player.Key.UserName!, Score = player.Max(s => s.Score) })
            .OrderByDescending(s => s.Score).ThenBy(s => s.Username).Take(10)
            .Select(s => new SnakeLeaderboardEntry(s.Username, s.Score)).ToListAsync(ct);
        return Result.Success(scores);
    }

    public async Task<Result> Submit(SubmitSnakeScore request, CancellationToken ct)
    {
        var userId = session.User?.Identity?.IsAuthenticated == true
            ? session.User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
        if (userId is null || !await db.Users.AnyAsync(u => u.Id == userId, ct))
            return Result.Unauthorized();

        var validation = await new SubmitSnakeScore.Validator().ValidateAsync(request, ct);
        if (!validation.IsValid)
            return Result.Invalid(validation.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage)));

        if (await db.SnakeScores.AnyAsync(s => s.UserId == userId && s.Width == request.Width
            && s.Height == request.Height && s.Score >= request.Score, ct))
            return Result.Success();

        db.SnakeScores.Add(new SnakeScore
        {
            UserId = userId, Width = request.Width, Height = request.Height, Score = request.Score
        });
        await db.SaveChangesAsync(ct);
        return Result.Success();
    }
}
