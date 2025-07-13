namespace FawryTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShippableProduct cheese = new ShippableProduct(1, "Cheese", 100, 5, new DateOnly(2025, 7, 10), 200);
            ShippableProduct biscuits = new ShippableProduct(2, "Biscuits", 150, 5, new DateOnly(2025, 9, 10), 350);
            ShippableProduct tv = new ShippableProduct(3, "TV", 500, 5, null, 1000);
            Product scratchCard = new Product(4, "scratchCard", 100, 5, null);
            Product gameCard = new Product(5, "gameCard", 200, 5, null);

            Customer customer = new Customer(1, 10000);
            Customer poorCustomer = new Customer(2, 50);

            Cart cart = new Cart(1);
            cart.AddItem(cheese, 5);
            cart.AddItem(cheese, 0);
            cart.AddItem(tv, 1);
            cart.AddItem(scratchCard, 1);
            cart.AddItem(gameCard, 1);

            CheckOut(customer, cart);
        }

        public static void CheckOut(Customer customer, Cart cart)
        {
            double PriceWithoutShippingFees = cart.GetPricesWithoutShippingFees();
            ShippingServices shippingServices = new ShippingServices(cart.ShippableProducts.Keys.ToList());
            shippingServices.GetWeight();
            double ShippingFees = shippingServices.CalcShippingFees();

            if (ShippingFees + PriceWithoutShippingFees > customer.Balance)
            {
                Console.WriteLine($"You have not enough Balace to complete the Process");
                return;
            }
            if (cart.isEmpty())
            {
                Console.WriteLine($"The Cart is Empty");
                return;
            }


            Console.WriteLine("CONSOLE OUTPUT");
            // for shippable products
            Console.WriteLine("** Shipment notice **");
            foreach (var item in cart.ShippableProducts)
            {
                Console.WriteLine($"{item.Value}x {item.Key.Name} {item.Key.Weight * Math.Max(1, item.Key.Quantity)}g");
            }
            Console.WriteLine();
            Console.WriteLine($"Total package weight {shippingServices.TotalWeight}kg");

            // for all products
            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.ShippableProducts)
            {
                Console.WriteLine($"{item.Value}x {item.Key.Name} {item.Key.Price * Math.Max(1, item.Key.Quantity)}");
            }
            foreach (var item in cart.Products)
            {
                Console.WriteLine($"{item.Value}x {item.Key.Name} {item.Key.Price * Math.Max(1, item.Key.Quantity)}");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine();

            customer.Balance -= (ShippingFees + PriceWithoutShippingFees);
            Console.WriteLine($"Subtotal {PriceWithoutShippingFees}");
            Console.WriteLine($"Shipping {ShippingFees}");
            Console.WriteLine($"Amount {PriceWithoutShippingFees + ShippingFees}");
        }
    }
}

/* 
 * Sample Ourput
 CONSOLE OUTPUT
** Shipment notice **
2x Cheese 400g
1x Biscuits 700g
Total package weight 1.1kg
** Checkout receipt **
2x Cheese 200
1x Biscuits 150
----------------------
Subtotal 350
Shipping 30
Amount 380

 */