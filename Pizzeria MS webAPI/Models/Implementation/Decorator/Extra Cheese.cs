using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pizzeria_MS_webAPI.Models.Implementation.Decorator.Base;
using Pizzeria_MS_webAPI.Models.Interface;

namespace Pizzeria_MS_webAPI.Models.Implementation.Decorator
{
    class Extra_Cheese : PizzaDecorator
    {
        public Extra_Cheese(IPizza pizza)
            : base(pizza)
        {

        }
        public override int getPrice()
        {
            return base.getPrice() + 400;
        }
        public static IPizza create(IPizza i)
        {
            i = new Extra_Cheese(i);
            return i;
        }
    }
}
