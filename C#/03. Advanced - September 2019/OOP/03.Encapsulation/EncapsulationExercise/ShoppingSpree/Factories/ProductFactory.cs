using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree.Factories
{
    public static class ProductFactory
    {
        public static void Create(string[] elements, List<Product> products)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                string[] currentProductsProps = elements[i]
                    .Split("=")
                    .ToArray();

                string name = currentProductsProps[0];
                double cost = double.Parse(currentProductsProps[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }
        }
    }
}
