using Mimmisbrunnr.Shared.Praesidium.Dtos;

namespace Mimmisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetSuperSchachts
    {
        public required IReadOnlyList<SuperSchachtDto.Simple> Schachts {get; set;}
    }
}