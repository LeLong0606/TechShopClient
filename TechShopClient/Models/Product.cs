using System.ComponentModel.DataAnnotations;

namespace TechShopClient.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [StringLength(75)]
        public string productCode { get; set; } = string.Empty;
        [StringLength(255)]
        public string productName { get; set; } = string.Empty;
        [StringLength(500)]
        public string productDescription { get; set; } = string.Empty;
        public int price { get; set; }
        public int quantity { get; set; }
        public string imagePath { get; set; } = string.Empty;
    }

}
