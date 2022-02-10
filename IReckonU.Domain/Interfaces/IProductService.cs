using System.Collections.Generic;
using IReckonU.Domain.Models;

namespace IReckonU.Domain.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> Get();
        Product Find(string key);
        void ImportFromFile(string inputPath, string outputPath);
    }
}
