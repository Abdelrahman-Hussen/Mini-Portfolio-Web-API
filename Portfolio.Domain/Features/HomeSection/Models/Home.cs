using Portfolio.Common.Helpers;
using Portfolio.Domain.Features.HomeSection.Dtos;
using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.Features.HomeSection.Models
{
    public class Home : EntityWithId
    {
        public TranslatableContent Header { get; set; }
        public TranslatableContent SubHeader { get; set; }
        public TranslatableContent Description { get; set; }
        public string Video { get; set; }

        public void Update(CreateOrUpdateHomeDto dto)
        {
            Header = dto.Header ?? Header;
            SubHeader = dto.SubHeader ?? SubHeader;
            Description = dto.Description ?? Description;
            Video = dto.Video is not null ? UpdateVideo(dto.Video) : Video;
            UpdatedAt = DateTime.UtcNow;
        }

        public string UpdateVideo(IFormFile video)
        {
            if (Video is not null)
                DeleteVideo();

            return FileHelper.Upload(video, FileHelper.Home);
        }

        public void DeleteVideo()
            => FileHelper.Delete(Video, FileHelper.Home);
    }
}