using Catalog.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Catalog.Api.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreConfiguredProduct());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProduct()
        {
            return new List<Product>()
            {
                new Product
                {
                    Name = "IPhone X",
                    Summary = "asd",
                    Description = "bzzzzz"                }

            };
        }
    }
}