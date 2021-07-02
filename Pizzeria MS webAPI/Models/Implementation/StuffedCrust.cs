using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pizzeria_MS_webAPI.Models.Interface;

namespace Pizzeria_MS_webAPI.Models.Implementation
{
    class StuffedCrust : IPizza
    {
        public int getPrice()
        {
            return 1000;
        }
        public static IPizza create(IPizza i)
        {
            i = new StuffedCrust();
            return i;
        }
    }
}
