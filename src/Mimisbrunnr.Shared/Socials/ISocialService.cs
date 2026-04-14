using Mimisbrunnr.Shared.Socials.Dtos;

namespace Mimisbrunnr.Shared.Socials;

public interface ISocialService
{
    Task<Result<SocialResponse.GetSocials>> GetSocials(CancellationToken ct);
    Task<Result<SocialDto.Detailed>> GetSocial(int id, CancellationToken ct);
    Task<Result<SocialResponse.GetSocialTypes>> GetSocialTypes(CancellationToken ct);
    Task<Result<SocialTypeDto.Detailed>> GetSocialType(int id, CancellationToken ct);
    Task<Result<SocialResponse.PostSocial>> PostSocial(SocialRequest.PostSocial req, CancellationToken ct);
    Task<Result<SocialResponse.PostSocialType>> PostSocialType(SocialRequest.PostSocialType req, CancellationToken ct);
    Task<Result<SocialResponse.PutSocial>> PutSocial(int id, SocialRequest.PutSocial req, CancellationToken ct);
    Task<Result<SocialResponse.PutSocialType>> PutSocialType(int id, SocialRequest.PutSocialType req, CancellationToken ct);
    Task<Result<SocialResponse.DeleteSocial>> DeleteSocial(int id, CancellationToken ct);
    Task<Result<SocialResponse.DeleteSocialType>> DeleteSocialType(int id, CancellationToken ct);
}