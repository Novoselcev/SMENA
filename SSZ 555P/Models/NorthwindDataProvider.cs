using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace SSZ.Models {
    public static class NorthwindDataProvider {
        const string NorthwindDataContextKey = "DXNorthwindDataContext";

        public static NorthwindDataContext DB {
            get {
                if (HttpContext.Current.Items[NorthwindDataContextKey] == null)
                    HttpContext.Current.Items[NorthwindDataContextKey] = new NorthwindDataContext();
                return (NorthwindDataContext)HttpContext.Current.Items[NorthwindDataContextKey];
            }
        }

        public static IEnumerable GetCustomers() {
            return from customer in DB.Customers select customer;
        }
    }
}