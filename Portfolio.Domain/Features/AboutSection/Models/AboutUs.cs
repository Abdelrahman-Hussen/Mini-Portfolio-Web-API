using Portfolio.Common.Helpers;
using Portfolio.Domain.Features.AboutSection.Dtos.About;
using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.Features.AboutSection.Models
{
    public class AboutUs : EntityWithId
    {
        public TranslatableContent Header { get; set; }
        public TranslatableContent Description { get; set; }
        public string Image { get; set; }

        public void Update(CreateOrUpdateAboutUsDto dto)
        {
            Header = dto.Header ?? Header;
            Description = dto.Description ?? Description;
            Image = dto.Image is not null ? UpdateImage(dto.Image) : Image;
            UpdatedAt = DateTime.UtcNow;
        }

        public string UpdateImage(IFormFile image)
        {
            if (Image is not null)
                DeleteImage();

            return FileHelper.Upload(image, FileHelper.AboutUs);
        }

        public void DeleteImage()
            => FileHelper.Delete(Image, FileHelper.AboutUs);

    }
}
