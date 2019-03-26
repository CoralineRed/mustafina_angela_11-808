using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContrLinq
{
    class Program
    {
        public static IEnumerable<int> Task1(IEnumerable<int> nums)
        {
            int ind = 1;
            return nums
                .Select(n => n * ind++)
                .Where(n => n > 9 && n < 100)
                .Reverse();
        }

        public static void Task3(IEnumerable<Product> products, IEnumerable<Discount> discounts,
            IEnumerable<Price> prices, IEnumerable<Purchase> purchases)
        {
            var prodDict = products.ToDictionary(x => x.VendorCode, x => x.Category);
            File.WriteAllLines("out.txt", products
                .Select(prod => prod.Category)
                .SelectMany(cat => purchases
                    .GroupBy(purch => purch.StoreName)
                    .Select(group => group.Where(x => prodDict[x.VendorCode] == cat)
                    .Select(sn => cat + sn.
                    )
                
                );


                //.Distinct()
                //.OrderBy(s => s)
                //.SelectMany(s => purchases
                //    .Select(p => p.StoreName)
                //    .Distinct()
                //    .
                //    )
                //);
        }

        static void Main(string[] args)
        {
        }
    }

    public static class Extentions
    {
        public static IEnumerable<Tuple<TItem1, TItem2>> JoinIf<TItem1, TItem2>(
            this IEnumerable<TItem1> that,
            IEnumerable<TItem2> other,
            Func<TItem1, TItem2, bool> func)
        {
            return that
                .SelectMany(first => other
                    .Select(second => Tuple.Create(first, second)))
                .Where(pair => func(pair.Item1, pair.Item2));
        }
    }

    public class Product
    {
        public readonly string Category;
        public readonly string ProducingCountry;
        public readonly string VendorCode;

        public Product(string vendorCode, string category, string produsingCountry)
        {
            VendorCode = vendorCode;
            Category = category;
            ProducingCountry = produsingCountry;
        }
    }

    public class Discount
    {
        public readonly int ConsumerId;
        public readonly string StoreName;
        public readonly int DiscountInPercents;

        public Discount(int consumerId, string storeName, int discountInPercents)
        {
            ConsumerId = consumerId;
            StoreName = storeName;
            DiscountInPercents = discountInPercents;
        }
    }

    public class Price
    {
        public readonly string VendorCode;
        public readonly string StoreName;
        public readonly string PriceInRubles;

        public Price(string vendorCode, string storeName, string priceInRubles)
        {
            VendorCode = vendorCode;
            StoreName = storeName;
            PriceInRubles = priceInRubles;
        }
    }

    public class Purchase
    {
        public readonly int ConsumerId;
        public readonly string VendorCode;
        public readonly string StoreName;

        public Purchase(int consumerId, string vendorCode, string storeName)
        {
            ConsumerId = consumerId;
            VendorCode = vendorCode;
            StoreName = storeName;
        }
    }
}
