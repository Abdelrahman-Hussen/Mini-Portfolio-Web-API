namespace Portfolio.Domain.Features.ContactSection.Models
{
    public class ContactUs : EntityWithId
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
