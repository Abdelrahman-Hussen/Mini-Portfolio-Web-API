namespace Portfolio.Domain.Features.Products.Dtos.ExtraDetails
{
    public class UpdateProductExtraDetailsDto
    {
        public Guid Id { get; set; }
        public TranslatableContent Title { get; set; }
        public TranslatableContent Description { get; set; }
    }
}
