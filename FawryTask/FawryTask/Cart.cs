using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    internal class Cart
    {
        public int Id { get; set; }
        internal Dictionary<ShippableProduct, int> ShippableProducts { get; set; }
        internal Dictionary<Product, int> Products { get; set; }



        public Cart(int id)
        {
            Id = id;
            Products = new Dictionary<Product, int>();
            ShippableProducts = new Dictionary<ShippableProduct, int>();
        }


        public void AddItem(Product product, int count)
        {
            if (product == null) return;
            if(product.Quantity < count)
            {
                Console.WriteLine($"We can't Provide all this quantity of {product.Name}, We just Have {product.Quantity} {product.Name}s ");
                count = product.Quantity;
                return;
            }

            if (product is ShippableProduct shippableProduct)
            {
                shippableProduct.Quantity -= count;
                ShippableProducts[shippableProduct] = ShippableProducts.GetValueOrDefault(shippableProduct, 0) + count; // explicit Casting
            }
            else
            {
                product.Quantity -= count;
                Products[product] = Products.GetValueOrDefault(product, 0) + count;

            }
        }


        public void RemoveItem(Product product)
        {
            if (product == null) return;
            if (product is ShippableProduct shippableProduct)
            {
                if (!ShippableProducts.ContainsKey(shippableProduct)) return;
                ShippableProducts.Remove(shippableProduct);
                shippableProduct.Quantity += ShippableProducts[shippableProduct];
            }
            else
            {
                if (!Products.ContainsKey(product)) return;
                Products.Remove(product);
                product.Quantity += Products[product];  
            }
        }

        public bool isEmpty()
        {
            return Products.Count == 0 && ShippableProducts.Count == 0 ;
        }

        public double GetPricesWithoutShippingFees()
        {
           double CartCostWithoutShippingFees =0;
            
           CartCostWithoutShippingFees = ShippableProducts.Sum(e => e.Key.Price* Math.Max(1, e.Key.Quantity)) +
                                         Products.Sum(e => e.Key.Price* Math.Max(1, e.Key.Quantity));

            return CartCostWithoutShippingFees;
        }

    }
}
