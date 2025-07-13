using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public class Product
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal double Price { get; set; }
        internal int Quantity { get; set; }
        internal DateOnly? ExpireDate { get; set; } 

        public Product(int id,string name, double price,int quantity,DateOnly ? expiredate) { 
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            ExpireDate = expiredate;        
        }

        public override string ToString() {
            return $"{Id} : {Name} : {Price} : {Quantity} : {ExpireDate} ";
        }

        internal bool IsExpired()
        {
            if (ExpireDate == null) return false;
            var today = DateOnly.FromDateTime(DateTime.Now);
            return ExpireDate < today;
        }

        internal void IncreaseQuantity(int quantity)
        {
            if (quantity <= 0) return;
            this.Quantity += quantity;
            return;
        }

        internal void DecreaseQuantity(int quantity)
        {
            if (quantity <= 0) return;
            this.Quantity -= quantity;
            return;
        }

        internal bool IsExist()
        {
            return this.Quantity != 0;
        }


    }
}
