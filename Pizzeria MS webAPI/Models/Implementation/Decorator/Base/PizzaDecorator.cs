using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pizzeria_MS_webAPI.Models.Interface;

namespace Pizzeria_MS_webAPI.Models.Implementation.Decorator.Base
{
    class PizzaDecorator : IPizza
    {
        IPizza pizza;
        public PizzaDecorator(IPizza _pizza)
        {
            pizza = _pizza;
        }

        public virtual int getPrice()
        {
            if (pizza == null)
            {
                return 0;
            }
            else
            {
                return pizza.getPrice();
            }
        }
    }
}

