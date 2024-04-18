using Portfolio.Common.Helpers;
using Portfolio.Domain.Features.Categories.Models;
using Portfolio.Domain.Features.Products.Dtos.Products;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Domain.Features.Products.Models
{
    public class Product : EntityWithId
    {
        public TranslatableContent Name { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public List<string> Images { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductDetails> Details { get; set; }
        public ICollection<ProductExtraDetails> ExtraDetails { get; set; }
        public ICollection<ProductProperties> Properties { get; set; }

        public void Update(UpdateProductDto dto)
        {
            Name = dto.Name ?? Name;
            Price = dto.Price ?? Price;
            Barcode = String.IsNullOrWhiteSpace(dto.Barcode) ? Barcode : dto.Barcode;
            CategoryId = dto.CategoryId ?? CategoryId;
            Images = dto.Images is not null && dto.Images.Any() ? UpdateImages(dto.Images) : Images;
            UpdatedAt = DateTime.UtcNow;
        }

        public List<string> UpdateImages(List<IFormFile> files)
        {
            var images = new List<string>();
            foreach (IFormFile file in files)
            {
                if (Images is not null)
                    DeleteImage();

                images.Add(FileHelper.Upload(file, FileHelper.Product));
            }
            return images;
        }

        public void DeleteImage()
            => Images.ForEach(image => FileHelper.Delete(image, FileHelper.Review));
    }
}
