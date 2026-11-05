namespace Mimisbrunnr.Domain.Games;

public class SnakeScore
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public int Width { get; set; }
    public int Height { get; set; }
    public int Score { get; set; }
}
