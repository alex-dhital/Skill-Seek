using SkillSeek.Application.DTOs.Service;

namespace SkillSeek.Application.Interfaces.Services;

public interface IServiceService
{
    List<ServiceDto> GetAllServices();

    ServiceDto GetServiceById(Guid serviceId);

    void UpsertService(ServiceDto service);
}