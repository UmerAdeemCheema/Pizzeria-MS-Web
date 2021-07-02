using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pizzeria_MS_webAPI.Models.Interface;

namespace Pizzeria_MS_webAPI.Models.Implementation
{
    class ThinCrust : IPizza
    {
        public int getPrice()
        {
            return 400;
        }
        public static IPizza create(IPizza i)
        {
            i = new ThinCrust();
            return i;
        }
    }
}
