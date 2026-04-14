using Mimisbrunnr.Shared.Socials;

namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class DeleteMemberSocial
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class DeleteMemberSocial : SocialRequest.PostSocial
    {
        
    }
}