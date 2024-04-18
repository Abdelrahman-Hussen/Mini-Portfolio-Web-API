using Portfolio.Domain.Features.AboutSection.Dtos.Infos;

namespace Portfolio.Domain.Features.AboutSection.Models
{
    public class Info : EntityWithId
    {
        public TranslatableContent Title { get; set; }
        public TranslatableContent Slogan { get; set; }

        public void Update(CreateOrUpdateInfoDto dto)
        {
            Title = dto.Title ?? Title;
            Slogan = dto.Slogan ?? Slogan;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
