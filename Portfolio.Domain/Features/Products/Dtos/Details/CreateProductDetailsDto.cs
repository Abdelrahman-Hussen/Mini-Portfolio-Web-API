namespace Portfolio.Domain.Features.Products.Dtos.Details
{
    public class CreateProductDetailsDto
    {
        public TranslatableContent Content { get; set; }
        public Guid ProductId { get; set; }
    }
}
