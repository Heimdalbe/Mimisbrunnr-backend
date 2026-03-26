using Mimmisbrunnr.Shared.Praesidium.Dtos;

namespace Mimmisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetPraesidiumOfYear
    {
        public required IReadOnlyList<PraesidiumTermDto.Simple>  Praesidium  {get; set;}
    }
}