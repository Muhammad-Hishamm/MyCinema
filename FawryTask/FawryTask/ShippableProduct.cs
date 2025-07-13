using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public class ShippableProduct:Product 
    {
        public double Weight { get; set; }

        public ShippableProduct(int id, string name, double price,int quantity, DateOnly? expiredate,double weight)
            :base( id,  name,  price,quantity, expiredate)
        {
            Weight = weight;
        }
    }
}
