using Mimisbrunnr.Shared.Games;

namespace Mimisbrunnr.Server.Endpoints.Games;

public class GetSnakeLeaderboard(ISnakeService service) : Endpoint<SnakeBoard, Result<List<SnakeLeaderboardEntry>>>
{
    public override void Configure()
    {
        Get("/api/games/snake/leaderboard");
        AllowAnonymous();
    }

    public override Task<Result<List<SnakeLeaderboardEntry>>> ExecuteAsync(SnakeBoard req, CancellationToken ct) =>
        service.GetLeaderboard(req, ct);
}
