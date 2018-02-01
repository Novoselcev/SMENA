using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.Mvc;

namespace SSZ.Helper
{
    public class HelperMainGrid
    {
        public static string GetOPerRouteUrlStart()
        {
            return DevExpressHelper.GetUrl(new {
                Controller = "Home",
                Action = " StatrtStatus"
            });
        }
    }
}