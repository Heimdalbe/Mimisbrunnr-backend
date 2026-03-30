using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetLustrumLids
    {
        public required IReadOnlyList<LustrumLidDto.Simple> LustrumLids {get; set;}
    }
}