using DB_Entity_DAL.DB_Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationTools.common
{
   public class ManagerTools
    {
       DB_User dbUser = new DB_User();
       public string CheckPassTools(int _id,string _pass)
       {
           if(dbUser.CheckPassProfile(_id,_pass))
           {
               return "success";
           }
           return "Please Sign In";
       }
    }
}
