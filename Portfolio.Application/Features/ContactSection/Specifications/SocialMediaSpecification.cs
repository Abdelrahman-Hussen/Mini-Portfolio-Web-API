using Portfolio.Domain.Features.ContactSection.Models;

namespace Portfolio.Application.Features.ContactSection.Specifications
{
    internal class SocialMediaSpecification : BaseSpecification<SocialMedia>
    {
        public static SocialMediaSpecification Get()
        {
            var spec = new SocialMediaSpecification();

            return spec;
        }
    }
}
