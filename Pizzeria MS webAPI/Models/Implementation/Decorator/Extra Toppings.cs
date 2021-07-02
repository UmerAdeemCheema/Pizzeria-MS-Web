using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pizzeria_MS_webAPI.Models.Implementation.Decorator.Base;
using Pizzeria_MS_webAPI.Models.Interface;

namespace Pizzeria_MS_webAPI.Models.Implementation.Decorator
{
    class Extra_Toppings : PizzaDecorator
    {
        public Extra_Toppings(IPizza pizza)
            : base(pizza)
        {

        }
        public override int getPrice()
        {
            return base.getPrice() + 500;
        }
        public static IPizza create(IPizza i)
        {
            i = new Extra_Toppings(i);
            return i;
        }
    }
}
