using Portfolio.Domain.Features.ContactSection.Models;

namespace Portfolio.Application.Features.ContactSection.Specifications
{
    internal class ContactInfoSpecification : BaseSpecification<ContactInfo>
    {
        public static ContactInfoSpecification Get()
        {
            var spec = new ContactInfoSpecification();

            return spec;
        }
    }
}
