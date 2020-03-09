using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImgUri { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public Product(string name, string imgUri, decimal price, string description)
        {
            Name = name;
            ImgUri = imgUri;
            Price = price;
            Description = description;
        }
    }
}
