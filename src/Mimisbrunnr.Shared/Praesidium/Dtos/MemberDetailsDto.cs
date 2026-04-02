using Mimisbrunnr.Shared.Common.Dtos;
using Mimisbrunnr.Shared.Socials.Dtos;

namespace Mimisbrunnr.Shared.Praesidium.Dtos;

public static class MemberDetailsDto
{
    public class Simple
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required SocialDto.Simple[] Socials { get; set; }
    }
    
    public class Detailed : Simple
    {
        public string Quote { get; set; }
        public string Trivia { get; set; }
    }
    
}