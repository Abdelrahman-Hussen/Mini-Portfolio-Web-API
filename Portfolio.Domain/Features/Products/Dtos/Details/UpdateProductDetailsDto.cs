namespace Portfolio.Domain.Features.Products.Dtos.Details
{
    public class UpdateProductDetailsDto
    {
        public Guid Id { get; set; }
        public TranslatableContent Content { get; set; }
    }
}
