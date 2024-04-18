using Portfolio.Common.Helpers;
using Portfolio.Domain.Features.Categories.Dtos;
using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.Features.Categories.Models
{
    public class Category : EntityWithId
    {
        public TranslatableContent Name { get; set; }
        public TranslatableContent Description { get; set; }
        public string Image { get; set; }

        public void Update(UpdateCategoryDto dto)
        {
            Name = dto.Name ?? Name;
            Description = dto.Description ?? Description;
            Image = dto.Image is not null ? UpdateImage(dto.Image) : Image;
            UpdatedAt = DateTime.UtcNow;
        }

        public string UpdateImage(IFormFile image)
        {
            if (Image is not null)
                DeleteImage();

            return FileHelper.Upload(image, FileHelper.Category);
        }

        public void DeleteImage()
            => FileHelper.Delete(Image, FileHelper.Category);
    }
}
