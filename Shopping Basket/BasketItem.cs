using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Basket
{
    public class BasketItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public BasketItem(string Name, int Quantity, double Price)
        {
            this.Name = Name;
            this.Quantity = Quantity;
            this.Price = Price;
        }
        public override string ToString()
        {
            return $"{Name} {Quantity,28} {"£", 23} {Price}";
        }
    }
}
