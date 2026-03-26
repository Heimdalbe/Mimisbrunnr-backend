using Mimmisbrunnr.Shared.Praesidium.Dtos;

namespace Mimmisbrunnr.Shared.Praesidium;

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
    
    Task<PraesidiumResponse.PostPraesidiumMember> PostPraesidiumMember(PraesidiumRequest.PostPraesidiumMember req, CancellationToken cancellationToken);

    Task<PraesidiumResponse.PostPraesidiumRole> PostPraesidiumRole(PraesidiumRequest.PostPraesidiumRole req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.PostSuperSchacht> PostSuperSchacht(PraesidiumRequest.PostSuperSchacht req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.PostErelid> PostErelid(PraesidiumRequest.PostErelid req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.PostLustrumLid> PostLustrumLid(PraesidiumRequest.PostLustrumLid req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.PutPraesidiumMember> PutPraesidiumMember(int id, PraesidiumRequest.PutPraesidiumMember req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.PutPraesidiumRole> PutPraesidiumRole(int id, PraesidiumRequest.PutPraesidiumRole req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.PutSuperSchacht> PutSuperSchacht(int id, PraesidiumRequest.PutSuperSchacht req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.PutErelid> PutErelid(int id, PraesidiumRequest.PutErelid req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.PutLustrumLid> PutLustrumLid(int id, PraesidiumRequest.PutLustrumLid req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.DeletePraesidiumMember> DeletePraesidiumMember(int id, CancellationToken ct);
    
    Task<PraesidiumResponse.DeletePraesidiumRole> DeletePraesidiumRole(int id, CancellationToken ct);
    
    Task<PraesidiumResponse.DeleteSuperSchacht> DeleteSuperSchacht(int id, CancellationToken ct);
    
    Task<PraesidiumResponse.DeleteErelid> DeleteErelid(int id, CancellationToken ct);
    
    Task<PraesidiumResponse.DeleteLustrumlid> DeleteLustrumLid(int id, CancellationToken ct);
}