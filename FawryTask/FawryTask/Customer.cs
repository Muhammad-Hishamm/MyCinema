using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    internal class Customer
    {
        public int Id { get; set; }
        public double Balance { get; set; }

        public Customer(int id, double balance)
        {
            Id = id;
            Balance = balance;
        }

    }
}
