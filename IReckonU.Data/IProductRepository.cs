using System.Collections.Generic;
using IReckonU.Data.Models;

namespace IReckonU.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product Find(string key);
        void Add(IEnumerable<Product> products);
    }
}
