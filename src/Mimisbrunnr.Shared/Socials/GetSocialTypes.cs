using Mimisbrunnr.Shared.Socials.Dtos;

namespace Mimisbrunnr.Shared.Socials;

public partial class SocialResponse
{
    public class GetSocialTypes
    {
        public required IReadOnlyList<SocialTypeDto.Simple> Types { get; set; }
    }
}