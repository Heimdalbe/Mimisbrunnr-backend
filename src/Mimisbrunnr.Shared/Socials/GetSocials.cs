using Mimisbrunnr.Shared.Socials.Dtos;

namespace Mimisbrunnr.Shared.Socials;

public partial class SocialResponse
{
    public class GetSocials
    {
        public required IReadOnlyList<SocialDto.Simple> Types { get; set; }
    }
}