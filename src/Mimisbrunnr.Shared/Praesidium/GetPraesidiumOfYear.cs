using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetPraesidiumOfYear
    {
        public required IReadOnlyList<PraesidiumTermDto.Simple>  Praesidium  {get; set;}
    }
}