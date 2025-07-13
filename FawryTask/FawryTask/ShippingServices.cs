using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public  class ShippingServices: IShippingServices
    {
        public double TotalWeight {  get; set; }
        List<ShippableProduct> ShippableProducts { get; set; }
        public ShippingServices(List<ShippableProduct> shippableProducts) { 
           ShippableProducts = shippableProducts;
            TotalWeight = 0;
        }


        public string GetName(Product product)
        {
            return product.Name;
        }

        public double GetWeight()
        {
            double totalShippableProductWeight = 0;
            totalShippableProductWeight += ShippableProducts.Sum(e => e.Weight* Math.Max(1,e.Quantity));
            //Console.WriteLine($"here is total weight{totalShippableProductWeight}");
            return TotalWeight =Math.Ceiling( totalShippableProductWeight/1000.0);
        }

        public double CalcShippingFees()
        {
            const double kiloShippinRate = 10.0;
            return (kiloShippinRate * TotalWeight);
        }
    }
}
