using Portfolio.Domain.Features.Products.Dtos.Properties;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Specifications
{
    internal class ProductPropertiesSpecification : BaseSpecification<ProductProperties>
    {
        public static ProductPropertiesSpecification GetAll(ProductPropertiesRequestModel requestModel)
        {
            var spec = new ProductPropertiesSpecification();

            spec.AddCriteria(p => p.ProductId == requestModel.ProductId);

            if (requestModel.ApplyPagination)
                spec.ApplyPaging(PageSize: requestModel.PageSize, requestModel.PageIndex);

            return spec;
        }

        public static ProductPropertiesSpecification GetById(Guid Id)
        {
            var spec = new ProductPropertiesSpecification();

            spec.AddCriteria(x => x.Id == Id);

            return spec;
        }
    }
}