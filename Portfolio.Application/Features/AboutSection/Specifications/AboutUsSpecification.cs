using Portfolio.Domain.Features.AboutSection.Models;

namespace Portfolio.Application.Features.AboutSection.Specifications
{
    internal class AboutUsSpecification : BaseSpecification<AboutUs>
    {
        public static AboutUsSpecification Get()
        {
            var spec = new AboutUsSpecification();

            return spec;
        }
    }
}
