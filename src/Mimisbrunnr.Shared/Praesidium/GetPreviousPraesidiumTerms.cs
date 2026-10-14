using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetPreviousPraesidiumTerms
    {
        public required IReadOnlyList<PraesidiumTermDto.YearRole>  PreviousPraesidiumTerms  {get; set;}
    }
}