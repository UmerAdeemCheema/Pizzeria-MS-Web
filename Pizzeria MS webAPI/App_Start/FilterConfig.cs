﻿using System.Web;
using System.Web.Mvc;

namespace Pizzeria_MS_webAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
