using Mimmisbrunnr.Shared.Common;
using Mimmisbrunnr.Shared.Common.Dtos;

namespace Mimmisbrunnr.Shared.Praesidium.Dtos;

public static class ErelidDto
{
    public class Simple
    {
        public required int Id { get; set; }
        public required MemberDetailsDto.Simple Member { get; set; }
        public required ImageDto.Simple Image { get; set; }
    }

    public class Detailed
    {
        public required int Id { get; set; }
        public required MemberDetailsDto.Detailed Member { get; set; }
        public required ImageDto.Simple Image { get; set; }
    }
}