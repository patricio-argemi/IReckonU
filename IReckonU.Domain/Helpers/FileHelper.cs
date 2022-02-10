using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using IReckonU.Domain.Models;

namespace IReckonU.Domain.Helpers
{
    public static class FileHelper
    {
        public static IEnumerable<Product> ExtractProductsFromCsv(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
                throw new FileNotFoundException("File path is missing.");

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<ProductMap>();

            var records = csv.GetRecords<Product>();
            var productList = records.ToHashSet();

            if (!productList.Any()) 
                throw new ApplicationException("Parsing failed or there are no registers to fetch in the file.");

            return productList;
        }
    }
}
