using Portfolio.Domain.Features.ContactSection.Dtos.ContactInfos;

namespace Portfolio.Domain.Features.ContactSection.Models
{
    public class ContactInfo : EntityWithId
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FAX { get; set; }

        public void Update(CreateOrUpdateContactInfoDto dto)
        {
            Phone = String.IsNullOrWhiteSpace(dto.Phone) ? Phone : dto.Phone;
            Email = String.IsNullOrWhiteSpace(dto.Email) ? Email : dto.Email;
            FAX = String.IsNullOrWhiteSpace(dto.FAX) ? FAX : dto.FAX;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
