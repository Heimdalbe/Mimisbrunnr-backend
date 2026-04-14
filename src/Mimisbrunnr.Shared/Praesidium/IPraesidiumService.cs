using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Shared.Praesidium;

public interface IPraesidiumService
{
    Task<Result<PraesidiumResponse.GetPraesidiumOfYear>> GetPraesidiumOfYear(int year, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumTermDto.Detailed>> GetPraesidiumTermDetailed(int id, CancellationToken cancellationToken = default);
   
    Task<Result<PraesidiumResponse.GetYears>> GetPraesidiumYears(CancellationToken cancellationToken = default);

    Task<Result<PraesidiumResponse.GetSuperSchachts>> GetSuperSchachts(CancellationToken cancellationToken = default);

    Task<Result<SuperSchachtDto.Detailed>> GetSuperSchachtDetailed(int id, CancellationToken cancellationToken = default);

    Task<Result<PraesidiumResponse.GetErelids>> GetErelids(CancellationToken cancellationToken = default);

    Task<Result<ErelidDto.Detailed>> GetErelidDetailed(int id, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumResponse.GetLustrumLids>> GetLustrumLids(int year, CancellationToken cancellationToken = default);

    Task<Result<LustrumLidDto.Detailed>> GetLustrumlidDetailed(int id, CancellationToken cancellationToken = default);

    Task<Result<PraesidiumResponse.GetYears>> GetLustrumYears(CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumResponse.PostPraesidiumMember>> PostPraesidiumMember(PraesidiumRequest.PostPraesidiumMember req, CancellationToken cancellationToken = default);

    Task<Result<PraesidiumResponse.PostPraesidiumRole>> PostPraesidiumRole(PraesidiumRequest.PostPraesidiumRole req, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumResponse.PostSuperSchacht>> PostSuperSchacht(PraesidiumRequest.PostSuperSchacht req, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumResponse.PostErelid>> PostErelid(PraesidiumRequest.PostErelid req, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumResponse.PostLustrumLid>> PostLustrumLid(PraesidiumRequest.PostLustrumLid req, CancellationToken cancellationToken = default);

    Task<Result<PraesidiumResponse.PostMemberSocial>> PostMemberSocial(int id, PraesidiumRequest.PostMemberSocial req, CancellationToken ct);
    
    Task<Result<PraesidiumResponse.PutPraesidiumMember>> PutPraesidiumMember(int id, PraesidiumRequest.PutPraesidiumMember req, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumResponse.PutPraesidiumRole>> PutPraesidiumRole(int id, PraesidiumRequest.PutPraesidiumRole req, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumResponse.PutSuperSchacht>> PutSuperSchacht(int id, PraesidiumRequest.PutSuperSchacht req, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumResponse.PutErelid>> PutErelid(int id, PraesidiumRequest.PutErelid req, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumResponse.PutLustrumLid>> PutLustrumLid(int id, PraesidiumRequest.PutLustrumLid req, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumResponse.DeletePraesidiumMember>> DeletePraesidiumMember(int id, CancellationToken ct = default);
    
    Task<Result<PraesidiumResponse.DeletePraesidiumRole>> DeletePraesidiumRole(int id, CancellationToken ct = default);
    
    Task<Result<PraesidiumResponse.DeleteSuperSchacht>> DeleteSuperSchacht(int id, CancellationToken ct = default);
    
    Task<Result<PraesidiumResponse.DeleteErelid>> DeleteErelid(int id, CancellationToken ct = default);
    
    Task<Result<PraesidiumResponse.DeleteLustrumlid>> DeleteLustrumLid(int id, CancellationToken ct = default);

    Task<Result<PraesidiumResponse.DeleteMemberSocial>> DeleteMemberSocial(int memberId, int socialId, CancellationToken ct);
}