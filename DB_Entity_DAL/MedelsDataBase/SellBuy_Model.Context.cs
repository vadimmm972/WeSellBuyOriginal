﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Sell_BuyEntities : DbContext
    {
        public Sell_BuyEntities()
            : base("name=Sell_BuyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LastView> LastViews { get; set; }
        public virtual DbSet<Magazine> Magazines { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<UserMagazine> UserMagazines { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<City> Cities { get; set; }
    }
}