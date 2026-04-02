using Mimisbrunnr.Shared.Socials;

namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PostMemberSocial
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PostMemberSocial : SocialRequest.PostSocial
    {
        
    }
}