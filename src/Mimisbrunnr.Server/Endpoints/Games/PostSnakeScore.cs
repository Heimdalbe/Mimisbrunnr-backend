using Mimisbrunnr.Shared.Games;

namespace Mimisbrunnr.Server.Endpoints.Games;

public class PostSnakeScore(ISnakeService service) : Endpoint<SubmitSnakeScore, Result>
{
    public override void Configure() => Post("/api/games/snake/scores");

    public override Task<Result> ExecuteAsync(SubmitSnakeScore req, CancellationToken ct) => service.Submit(req, ct);
}
