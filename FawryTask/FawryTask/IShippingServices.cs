using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public interface IShippingServices
    {
        public string GetName(Product products);
        public double GetWeight( );
    }
}
