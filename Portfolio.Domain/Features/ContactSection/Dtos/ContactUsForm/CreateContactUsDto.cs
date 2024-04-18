namespace Portfolio.Domain.Features.ContactSection.Dtos.ContactUsForm
{
    public class CreateContactUsDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
