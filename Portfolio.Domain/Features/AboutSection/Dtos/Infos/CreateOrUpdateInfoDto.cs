namespace Portfolio.Domain.Features.AboutSection.Dtos.Infos
{
    public class CreateOrUpdateInfoDto
    {
        public TranslatableContent? Title { get; set; }
        public TranslatableContent? Slogan { get; set; }
    }
}
