using Mimmisbrunnr.Shared.Praesidium.Dtos;

namespace Mimmisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetLustrumLids
    {
        public required IReadOnlyList<LustrumLidDto.Simple> LustrumLids {get; set;}
    }
}