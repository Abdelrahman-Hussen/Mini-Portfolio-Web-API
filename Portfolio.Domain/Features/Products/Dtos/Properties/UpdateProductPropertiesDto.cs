namespace Portfolio.Domain.Features.Products.Dtos.Properties
{
    public class UpdateProductPropertiesDto
    {
        public Guid Id { get; set; }
        public TranslatableContent Name { get; set; }
        public string Value { get; set; }
    }
}
