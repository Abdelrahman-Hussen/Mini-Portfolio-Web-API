using Portfolio.Domain.Features.ContactSection.Dtos.SocailMeadias;

namespace Portfolio.Domain.Features.ContactSection.Models
{
    public class SocialMedia : EntityWithId
    {
        public string WhatsAppPhone { get; set; }
        public string WhatsAppLink { get; set; }
        public string Facebook { get; set; }
        public string X { get; set; }
        public string Instagram { get; set; }

        public void Update(CreateOrUpdateSocialMediaDto dto)
        {
            WhatsAppPhone = String.IsNullOrWhiteSpace(dto.WhatsAppPhone) ? WhatsAppPhone : dto.WhatsAppPhone;
            WhatsAppLink = String.IsNullOrWhiteSpace(dto.WhatsAppLink) ? WhatsAppLink : dto.WhatsAppLink;
            Facebook = String.IsNullOrWhiteSpace(dto.Facebook) ? Facebook : dto.Facebook;
            X = String.IsNullOrWhiteSpace(dto.X) ? X : dto.X;
            Instagram = String.IsNullOrWhiteSpace(dto.Instagram) ? Instagram : dto.Instagram;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
