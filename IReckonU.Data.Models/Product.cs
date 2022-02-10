using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IReckonU.Data.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Key { get; set; }
        public string ArticleCode { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string DeliveredIn { get; set; }
        public string Target { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
    }
}
