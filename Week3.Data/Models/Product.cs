namespace Week3.Data.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Category Category { get; set; }

        public ProductFeature ProductFeature { get; set; }
    }
}