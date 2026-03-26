namespace Mimmisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetYears
    {
        public required IReadOnlyList<int> Years {get; set;}
    }
}