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
    
    public partial class Category
    {
        public Category()
        {
            this.Magazines = new HashSet<Magazine>();
            this.Products = new HashSet<Product>();
            this.SubCategories = new HashSet<SubCategory>();
        }
    
        public int id { get; set; }
        public string name_category { get; set; }
    
        public virtual ICollection<Magazine> Magazines { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
