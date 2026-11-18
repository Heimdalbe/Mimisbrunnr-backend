namespace Mimisbrunnr.Shared.Games;

public record SnakeLeaderboardEntry(string Username, int Score);

public interface ISnakeService
{
    Task<Result<List<SnakeLeaderboardEntry>>> GetLeaderboard(SnakeBoard board, CancellationToken ct);
    Task<Result> Submit(SubmitSnakeScore request, CancellationToken ct);
}
