using Mimisbrunnr.Shared.Common.Dtos;

namespace Mimisbrunnr.Shared.Praesidium.Dtos;

public static class SuperSchachtDto
{
    public class Simple
    {
        public required int Id { get; set; }
        public required MemberDetailsDto.Simple Member { get; set; }
        public required ImageDto.Simple Image { get; set; }
        public required int Year { get; set; }
    }
    
    public class Detailed
    {
        public required int Id { get; set; }
        public required MemberDetailsDto.Detailed Member { get; set; }
        public required ImageDto.Simple Image { get; set; }
        public required int Year { get; set; }
    }
}