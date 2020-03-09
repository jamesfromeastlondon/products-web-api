using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Image Uri required")]
        public string ImgUri { get; set; }

        [Required(ErrorMessage = "Price required")]
        public decimal Price { get; set; }

        /// <summary>Optional description of the product</summary>
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
