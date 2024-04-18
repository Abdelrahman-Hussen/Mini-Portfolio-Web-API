using Portfolio.Domain.Features.HomeSection.Models;

namespace Portfolio.Application.Features.HomeSection.Specifications
{
    internal class HomeSpecification : BaseSpecification<Home>
    {
        public static HomeSpecification Get()
        {
            var spec = new HomeSpecification();

            return spec;
        }
    }
}
