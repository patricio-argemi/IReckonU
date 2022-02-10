using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IReckonU.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using Domain = IReckonU.Domain.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = this.productService.Get();
            return products.Select(this.CreateProduct);
        }

        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            try
            {
                var product = this.productService.Find(key);
                return this.Ok(this.CreateProduct(product));
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return this.NotFound();
            }
        }

        [HttpGet]
        [Route("import")]
        public IActionResult Import()
        {
            const string resourcesFolder = "Resources";
            const string fileName = "iru-assignment-2018";

            var currentDirectory = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDirectory, resourcesFolder, String.Concat(fileName, ".csv"));
            var outputPath = Path.Combine(currentDirectory, resourcesFolder, String.Concat(fileName, ".json"));

            try
            {
                this.productService.ImportFromFile(filePath, outputPath);
                return this.Ok("Products imported successfully.");
            }
            catch (Exception e)
            {
                var message = e.InnerException != null
                    ? e.InnerException.Message
                    : e.Message;

                switch (e)
                {
                    case FileNotFoundException _:
                        return this.NotFound(message);
                    case ApplicationException _:
                        return this.Problem(message);
                    case DbUpdateException _:
                        return this.ValidationProblem(message);
                    default:
                        throw;
                }
            }
        }

        private Product CreateProduct(Domain.Product product)
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
    }
}
