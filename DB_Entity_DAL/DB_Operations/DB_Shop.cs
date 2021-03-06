﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Entity_DAL.MedelsDataBase;

namespace DB_Entity_DAL.DB_Operations
{
    public class DB_Shop
    {
        OperationslogError nLog = new OperationslogError();
        public bool InsertUserShop(Shop us_m)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.Shops.Add(us_m);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_Shop -> InsertUserShop :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);
                return false;
            }
        }

        public List<Shop> GeAllShopsByUserId(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var shops = db.Shops.Where(x => x.id_user == id).Select(x => x).ToList();
                if (shops != null)
                {
                    return shops;
                }
                return null;
            }
            catch (Exception e)
            {
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_Shop -> GeAllShopsByUserId :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);
                return null;
            }
        }

        public string RemoveShopById(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();

                var shopList = db.Shops.Where(s => s.id_magazine == id).ToList();
                if (shopList != null && shopList.Count != 0)
                {
                    db.Shops.RemoveRange(shopList);
                    db.SaveChanges();
                    return "OK";
                }
                else
                {
                    return "Магазин не найден";
                }

                //var shops = db.Shops.Find(0);
                //if (shops != null)
                //{
                //    db.Shops.Attach(shops);
                //    db.Shops.Remove(shops);
                //    db.SaveChanges();
                //    return "OK";
                //}
                //else
                //{
                //    return "Магазин не найден";
                //}
              
            }
            catch (Exception e)
            {
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_Shop -> RemoveShopById :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);
                return "Ошибка при удалении,обратитесь за помощью к администрации сайта";
            }
           
        }
    }
}
