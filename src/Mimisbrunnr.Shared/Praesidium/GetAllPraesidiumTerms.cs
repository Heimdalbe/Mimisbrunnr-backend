using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetAllPraesidiumTerms
    {
        public required IReadOnlyList<PraesidiumTermDto.YearRole>  AllPraesidiumTerms  {get; set;}
    }
}