using Portfolio.Domain.Features.AboutSection.Models;

namespace Portfolio.Application.Features.AboutSection.Specifications
{
    internal class InfoSpecification : BaseSpecification<Info>
    {
        public static InfoSpecification Get()
        {
            var spec = new InfoSpecification();

            return spec;
        }
    }
}
