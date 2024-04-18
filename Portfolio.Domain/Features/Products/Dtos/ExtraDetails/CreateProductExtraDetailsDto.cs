namespace Portfolio.Domain.Features.Products.Dtos.ExtraDetails
{
    public class CreateProductExtraDetailsDto
    {
        public TranslatableContent Title { get; set; }
        public TranslatableContent Description { get; set; }
        public Guid ProductId { get; set; }
    }
}
