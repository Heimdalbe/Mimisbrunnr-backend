namespace Mimisbrunnr.Shared.Games;

public class SnakeBoard
{
    public int Width { get; set; }
    public int Height { get; set; }

    public class Validator : AbstractValidator<SnakeBoard>
    {
        public Validator()
        {
            RuleFor(b => b.Width).InclusiveBetween(8, 40);
            RuleFor(b => b.Height).InclusiveBetween(8, 40);
        }
    }
}

public class SubmitSnakeScore : SnakeBoard
{
    public int Score { get; set; }

    public new class Validator : AbstractValidator<SubmitSnakeScore>
    {
        public Validator()
        {
            Include(new SnakeBoard.Validator());
            RuleFor(s => s.Score).GreaterThan(0).LessThanOrEqualTo(s => s.Width * s.Height - 3);
        }
    }
}
