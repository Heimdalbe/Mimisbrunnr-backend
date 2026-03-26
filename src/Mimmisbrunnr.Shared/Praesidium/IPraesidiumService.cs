using Mimmisbrunnr.Shared.Praesidium.Dtos;

namespace Mimmisbrunnr.Shared.Praesidium;

public interface IPraesidiumService
{
    Task<Result<PraesidiumResponse.GetPraesidiumOfYear>> GetPraesidiumOfYear(int year, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumTermDto.Detailed>> GetPraesidiumTermDetailed(int id, CancellationToken cancellationToken = default);
   
    Task<Result<PraesidiumResponse.GetYears>> GetPraesidiumYears(CancellationToken cancellationToken = default);

    Task<Result<PraesidiumResponse.GetSuperSchachts>> GetSuperschachts(CancellationToken cancellationToken = default);

    Task<Result<SuperSchachtDto.Detailed>> GetSuperschachtDetailed(int id, CancellationToken cancellationToken = default);

    Task<Result<PraesidiumResponse.GetErelids>> GetErelids(CancellationToken cancellationToken = default);

    Task<Result<ErelidDto.Detailed>> GetErelidDetailed(int id, CancellationToken cancellationToken = default);
    
    Task<Result<PraesidiumResponse.GetLustrumLids>> GetLustrumLids(int year, CancellationToken cancellationToken = default);

    Task<Result<LustrumLidDto.Detailed>> GetLustrumlidDetailed(int id, CancellationToken cancellationToken = default);

    Task<Result<PraesidiumResponse.GetYears>> GetLustrumYears(CancellationToken cancellationToken = default);
    
    Task<PraesidiumResponse.PostPraesidiumMember> PostPraesidiumMember(PraesidiumRequest.PostPraesidiumMember member, CancellationToken cancellationToken);

    Task<PraesidiumResponse.PostPraesidiumRole> PostPraesidiumRole(PraesidiumRequest.PostPraesidiumRole req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.PostSuperSchacht> PostSuperSchacht(PraesidiumRequest.PostSuperSchacht req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.PostErelid> PostErelid(PraesidiumRequest.PostErelid req, CancellationToken cancellationToken);
    
    Task<PraesidiumResponse.PostLustrumLid> PostLustrumLid(PraesidiumRequest.PostLustrumLid req, CancellationToken cancellationToken);
}