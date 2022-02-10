using CsvHelper.Configuration;

namespace IReckonU.Domain.Models
{
    public sealed class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            this.Map(m => m.Key);
            this.Map(m => m.ColorCode);
            this.Map(m => m.Description);
            this.Map(m => m.Price);
            this.Map(m => m.DiscountPrice);
            this.Map(m => m.DeliveredIn);
            this.Map(m => m.Size);
            this.Map(m => m.Color);
            this.Map(m => m.ArticleCode).Name("ArtikelCode");
            this.Map(m => m.Target).Name("Q1");
        }
    }
}
