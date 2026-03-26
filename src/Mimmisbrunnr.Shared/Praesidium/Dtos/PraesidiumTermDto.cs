using Mimmisbrunnr.Shared.Common;
using Mimmisbrunnr.Shared.Common.Dtos;

namespace Mimmisbrunnr.Shared.Praesidium.Dtos;

public class PraesidiumTermDto
{
    public class Simple
    {
        public required int Id { get; set; }
        public required MemberDetailsDto.Simple Member { get; set; }
        public required PraesidiumRoleDto.Simple Role { get; set; }
        public required ImageDto.Simple Image { get; set; }
        public required int Year { get; set; }
        
    }
    
    public class Detailed
    {
        public required int Id { get; set; }
        public required MemberDetailsDto.Detailed Member { get; set; }
        public required PraesidiumRoleDto.Detailed Role { get; set; }
        public required ImageDto.Simple Image { get; set; }
        public required int Year { get; set; }
    }
}