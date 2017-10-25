using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSellBuy.Helper
{
    public class StoreObjects
    {
        public StoreInfo GetStoreinfo(StoreInfo store)
        {
            store = new StoreInfo();
            //   var idCustomerUser = Convert.ToInt32(Request.Cookies["AuthenticationSellBuy"].Value);
            int iduser = Convert.ToInt32(HttpContext.Current.Request.Cookies["AuthenticationSellBuy"].Value);
            store.CustomerID = iduser;
            return store;
        }
    }

    public class StoreInfo
    {
        public int CustomerID { get; set; }
        public int ShopId { get; set; }
        public string WishListId { get; set; }
    }

}