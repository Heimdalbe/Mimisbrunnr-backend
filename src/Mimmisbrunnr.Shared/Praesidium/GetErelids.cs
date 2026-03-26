using Mimmisbrunnr.Shared.Praesidium.Dtos;

namespace Mimmisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetErelids
    {
        public required IReadOnlyList<ErelidDto.Simple> Erelids {get; set;}
    }
}