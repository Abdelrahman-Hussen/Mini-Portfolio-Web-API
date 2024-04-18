using Portfolio.Domain.Features.ContactSection.Models;

namespace Portfolio.Application.Features.ContactSection.Specifications
{
    internal class ContactUsSpecification : BaseSpecification<ContactUs>
    {
        public static ContactUsSpecification GetAll(RequestModel requestModel)
        {
            var spec = new ContactUsSpecification();

            if (requestModel.ApplyPagination)
                spec.ApplyPaging(PageSize: requestModel.PageSize, requestModel.PageIndex);

            return spec;
        }

        public static ContactUsSpecification GetById(Guid Id)
        {
            var spec = new ContactUsSpecification();

            spec.AddCriteria(x => x.Id == Id);

            return spec;
        }
    }
}
