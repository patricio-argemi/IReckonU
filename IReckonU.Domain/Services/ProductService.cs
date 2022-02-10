using System.Collections.Generic;
using System.IO;
using System.Linq;
using IReckonU.Data;
using IReckonU.Domain.Helpers;
using IReckonU.Domain.Interfaces;
using IReckonU.Domain.Models;
using Newtonsoft.Json;

namespace IReckonU.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Get()
        {
            var result = this.productRepository.Get();
            return result.Select(this.CreateDomainProduct);
        }

        public Product Find(string key)
        {
            var result = this.productRepository.Find(key);
            return this.CreateDomainProduct(result);
        }

        public void Add(IEnumerable<Product> products)
        {
            var newProducts = products.Select(this.CreateDataProduct);
            this.productRepository.Add(newProducts);
        }

        public void ImportFromFile(string inputPath, string outputPath)
        {
            var extractedProducts = FileHelper.ExtractProductsFromCsv(inputPath);

            this.Add(extractedProducts);
            File.WriteAllText(outputPath, JsonConvert.SerializeObject(extractedProducts));
        }

        private Product CreateDomainProduct(Data.Models.Product product)
        {
            return new Product
            {
                Key = product.Key,
                ArticleCode = product.ArticleCode,
                ColorCode = product.ColorCode,
                Description = product.Description,
                Price = product.Price,
                DiscountPrice = product.DiscountPrice,
                DeliveredIn = product.DeliveredIn,
                Target = product.Target,
                Size = product.Size,
                Color = product.Color
            };
        }

        private Data.Models.Product CreateDataProduct(Product product)
        {
            return new Data.Models.Product
            {
                Key = product.Key,
                ArticleCode = product.ArticleCode,
                ColorCode = product.ColorCode,
                Description = product.Description,
                Price = product.Price,
                DiscountPrice = product.DiscountPrice,
                DeliveredIn = product.DeliveredIn,
                Target = product.Target,
                Size = product.Size,
                Color = product.Color
            };
        }
    }
}
