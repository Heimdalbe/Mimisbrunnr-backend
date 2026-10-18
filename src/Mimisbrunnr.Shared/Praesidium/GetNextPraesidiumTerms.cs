using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetNextPraesidiumTerms
    {
        public required IReadOnlyList<PraesidiumTermDto.YearRole>  NextPraesidiumTerms  {get; set;}
    }
}