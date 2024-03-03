using Microsoft.AspNetCore.Http;
using SkillSeek.Application.DTOs.Product;
using SkillSeek.Application.Interfaces.Repositories.Base;
using SkillSeek.Application.Interfaces.Services;
using SkillSeek.Domain.Constants;
using SkillSeek.Domain.Entities;

namespace SkillSeek.Infrastructure.Implementation.Services;

public class ProductService : IProductService
{
    private readonly IGenericRepository _genericRepository;
    private readonly IFileUploadService _fileUploadService;

    public ProductService(IGenericRepository genericRepository, IFileUploadService fileUploadService)
    {
        _genericRepository = genericRepository;
        _fileUploadService = fileUploadService;
    }

    public List<ProductDto> GetAllProducts()
    {
        var products = _genericRepository.Get<Product>();

        var services = _genericRepository.Get<Service>();

        var result = from product in products
            join service in services on product.ServiceId equals service.Id
            select new ProductDto()
            {
                Id = product.Id,
                ServiceId = service.Id,
                Service = service.Title,
                ImageURL = product.ImageURL,
                Description = product.Description,
                Name = product.Title,
                Price = product.Price,
                Price25 = product.Price25,
                Price50 = product.Price50
            };

        return result.ToList();
    }

    public ProductDto GetProductById(Guid productId)
    {
        var product = _genericRepository.GetById<Product>(productId);

        var service = _genericRepository.GetById<Service>(product.ServiceId);

        var result = new ProductDto()
        {
            Id = product.Id,
            ServiceId = service.Id,
            Service = service.Title,
            ImageURL = product.ImageURL,
            Description = product.Description,
            Name = product.Title,
            Price = product.Price,
            Price25 = product.Price25,
            Price50 = product.Price50
        };

        return result;
    }

    public void UpsertProduct(ProductDto product)
    {
        var filePath = Constants.FilePath.ProductsImagesPath;

        if (product.Id == Guid.Empty)
        {
            var image = _fileUploadService.UploadFile(product.Image!, filePath);

            var productModel = new Product()
            {
                Title = product.Name,
                Description = product.Description,
                Price = product.Price,
                Price25 = product.Price25,
                Price50 = product.Price50,
                ServiceId = product.ServiceId,
                IsActive = true,
                ImageURL = image
            };

            _genericRepository.Insert(productModel);
        }
        else
        {
            var productModel = _genericRepository.GetById<Product>(product.Id);

            productModel.Title = product.Name;
            productModel.Description = product.Description;
            productModel.Price = product.Price;
            productModel.Price25 = product.Price25;
            productModel.Price50 = product.Price50;
            productModel.ServiceId = product.ServiceId;
            productModel.ImageURL = product.Image != null ? _fileUploadService.UploadFile(product.Image, filePath) : productModel.ImageURL;
            
            _genericRepository.Update(productModel);
        }
    }
}