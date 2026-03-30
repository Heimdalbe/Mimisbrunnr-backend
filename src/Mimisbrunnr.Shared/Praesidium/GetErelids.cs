using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetErelids
    {
        public required IReadOnlyList<ErelidDto.Simple> Erelids {get; set;}
    }
}