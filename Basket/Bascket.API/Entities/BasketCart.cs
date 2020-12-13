using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bascket.API.Entities
{
    public class BasketCart
    {
        public string UserName { get; set; }
        public List<BascketCartItem> Items { get; set; }

        public BasketCart()
        {

        }

        public BasketCart(string userName )
        {
            this.UserName = userName;
        }


        public decimal TotalPrice
        {
            get{
                decimal totalPrice = 0;
                foreach(var item in Items)
                {
                    totalPrice += item.Quantity * item.Price;
                }
                return totalPrice;
            }
        }
    }

 
}
