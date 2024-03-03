using SkillSeek.Application.DTOs.Service;
using SkillSeek.Application.Interfaces.Repositories.Base;
using SkillSeek.Application.Interfaces.Services;
using SkillSeek.Domain.Entities;

namespace SkillSeek.Infrastructure.Implementation.Services;

public class ServiceService : IServiceService
{
    private readonly IGenericRepository _genericRepository;

    public ServiceService(IGenericRepository genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public List<ServiceDto> GetAllServices()
    {
        var services = _genericRepository.Get<Service>();

        return services.Select(x => new ServiceDto()
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            BasePrice = x.BasePrice
        }).ToList();
    }

    public ServiceDto GetServiceById(Guid serviceId)
    {
        var service = _genericRepository.GetById<Service>(serviceId);

        return new ServiceDto()
        {
            Id = service.Id,
            Title = service.Title,
            Description = service.Description,
            BasePrice = service.BasePrice
        };
    }

    public void UpsertService(ServiceDto service)
    {
        if (service.Id == Guid.Empty)
        {
            var serviceModel = new Service()
            {
                Title = service.Title,
                Description = service.Description,
                BasePrice = service.BasePrice,
                IsActive = true,
            };

            _genericRepository.Insert(serviceModel);
        }
        else
        {
            var serviceModel = _genericRepository.GetById<Service>(service.Id);

            serviceModel.Title = service.Title;
            serviceModel.Description = service.Description;
            serviceModel.BasePrice = service.BasePrice;

            _genericRepository.Update(serviceModel);
        }
    }
}