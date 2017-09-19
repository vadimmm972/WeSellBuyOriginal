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
    
    public partial class User
    {
        public User()
        {
            this.Baskets = new HashSet<Basket>();
            this.Comments = new HashSet<Comment>();
            this.LastViews = new HashSet<LastView>();
            this.Shops = new HashSet<Shop>();
            this.Magazines = new HashSet<Magazine>();
        }
    
        public int id { get; set; }
        public string name_first { get; set; }
        public string name_last { get; set; }
        public string name_middle { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
        public Nullable<int> id_country { get; set; }
        public Nullable<int> id_region { get; set; }
        public Nullable<int> id_sity { get; set; }
        public Nullable<int> C_status { get; set; }
        public Nullable<int> active { get; set; }
        public Nullable<int> id_language { get; set; }
        public string C_image { get; set; }
        public string date_register { get; set; }
        public string C_login { get; set; }
        public string C_password { get; set; }
    
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Country Country { get; set; }
        public virtual Language Language { get; set; }
        public virtual ICollection<LastView> LastViews { get; set; }
        public virtual Region Region { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }
    }
}
