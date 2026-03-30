using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetSuperSchachts
    {
        public required IReadOnlyList<SuperSchachtDto.Simple> Schachts {get; set;}
    }
}