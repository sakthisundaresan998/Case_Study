using System;
using System.Collections.Generic;
using System.Linq;
using LINQ;

namespace LinqCodeTemplate
{
    internal class Problem1
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            // Query 1: Products with category "FMCG"
            var fmcgProducts = products.Where(p => p.ProCategory == "FMCG").ToList();
            Console.WriteLine("\nFMCG Products:");
            foreach (var item in fmcgProducts)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // Query 2: Products with category "Grain"
            var grainProducts = products.Where(p => p.ProCategory == "Grain").ToList();
            Console.WriteLine("\nGrain Products:");
            foreach (var item in grainProducts)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // Query 3: Sort by Product Code
            var sortByProCode = products.OrderBy(p => p.ProCode).ToList();
            Console.WriteLine("\nProducts sorted by ProCode:");
            foreach (var item in sortByProCode)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // Query 4: Sort by Product Category
            var sortByProCategory = products.OrderBy(p => p.ProCategory).ToList();
            Console.WriteLine("\nProducts sorted by Category:");
            foreach (var item in sortByProCategory)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // Query 5: Sort by MRP Ascending
            var sortByProMrp = products.OrderBy(p => p.ProMrp).ToList();
            Console.WriteLine("\nProducts sorted by MRP (Asc):");
            foreach (var item in sortByProMrp)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // Query 6: Sort by MRP Descending
            var sortByDescProMrp = products.OrderByDescending(p => p.ProMrp).ToList();
            Console.WriteLine("\nProducts sorted by MRP (Desc):");
            foreach (var item in sortByDescProMrp)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // Query 7: Group by Category
            var grpByProCategory = products.GroupBy(p => p.ProCategory).ToList();
            Console.WriteLine("\nProducts grouped by Category:");
            foreach (var group in grpByProCategory)
            {
                Console.WriteLine($"\nCategory: {group.Key}");
                foreach (var item in group)
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            // Query 8: Group by MRP
            var grpByProMrp = products.GroupBy(p => p.ProMrp).ToList();
            Console.WriteLine("\nProducts grouped by MRP:");
            foreach (var group in grpByProMrp)
            {
                Console.WriteLine($"\nMRP: {group.Key}");
                foreach (var item in group)
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            // Query 9: Highest MRP in FMCG
            var highestPriceInFmcg = products.Where(p => p.ProCategory == "FMCG").Max(p => p.ProMrp);
            Console.WriteLine("\nHighest Price in FMCG: " + highestPriceInFmcg);

            // Query 10: Count Total Products
            Console.WriteLine("\nTotal Products: " + products.Count);

            // Query 11: Count Products in FMCG
            Console.WriteLine("Total FMCG Products: " + products.Count(p => p.ProCategory == "FMCG"));

            // Query 12: Max MRP
            Console.WriteLine("Maximum Product MRP: " + products.Max(p => p.ProMrp));

            // Query 13: Min MRP
            Console.WriteLine("Minimum Product MRP: " + products.Min(p => p.ProMrp));

            // Query 14: Are all products below Rs.30?
            Console.WriteLine(products.All(p => p.ProMrp < 30) ? "All products are below 30" : "Not all products are below 30");

            // Query 15: Is any product below Rs.30?
            Console.WriteLine(products.Any(p => p.ProMrp < 30) ? "There are products below 30" : "No products are below 30");

            Console.ReadLine();
        }
    }
}
