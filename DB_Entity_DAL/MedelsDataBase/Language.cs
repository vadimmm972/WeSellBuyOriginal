//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_Entity_DAL.MedelsDataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Language
    {
        public Language()
        {
            this.Users = new HashSet<User>();
        }
    
        public int id { get; set; }
        public string translate { get; set; }
        public Nullable<int> C_status { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}
