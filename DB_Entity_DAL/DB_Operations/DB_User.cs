using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Entity_DAL.MedelsDataBase;
using NLog;

namespace DB_Entity_DAL.DB_Operations
{
    public class DB_User
    {
        private OperationslogError nLog = new OperationslogError();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public string searchUser(string _login , string email , string phone) // check info who register user
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    StringBuilder ErrorMessage = new StringBuilder();
                    var  user = db.Users.FirstOrDefault(x => x.C_login == _login);
                    if (user != null)
                    {
                        if(user.C_login == _login)
                        {
                            ErrorMessage.Append("Пользователь стаким логином уже существует \n");
                        }
                        if(user.mail == email)
                        {
                            ErrorMessage.Append("Пользователь стаким емейлом уже существует \n");
                        }
                        if(user.phone == phone)
                        {
                            ErrorMessage.Append("Пользователь стаким номером телефона уже существует \n");
                        }
                        return ErrorMessage.ToString();
                    }
                    else
                    {
                        return "";
                    }
                    
                }
            }
            catch (Exception e)
            {
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> searchUser :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "",  0);
                return "error";
            }
           
        }

        public string SignInUserCheckDataBase(string _login , string _password) // Sign In  
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    //StringBuilder ErrorMessage = new StringBuilder();
                    var user = db.Users.FirstOrDefault(u => u.C_login == _login && u.C_password == _password);
                    if (user == null)
                    {
                        return "Неверный логин или пароль";
                    }
                    else
                    {
                        return "id=" + user.id +"/success Добро пожаловать " + user.name_first + " " + user.name_middle;
                    }

                }
            }
            catch (Exception e)
            {
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> SignInUserCheckDataBase :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);
                return e.Message;
            }
        }

        public bool InsertUser(User user)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> InsertUser :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);
                return false;
            }
        }


        public string UpdateInfoSurnameProfile(int _iduser  , string _newsurname)
        {
            string getResult = "";
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var result = db.Users.SingleOrDefault(u => u.id == _iduser);
                if (result != null)
                {
                    result.name_first = _newsurname;
                    db.SaveChanges();
                    getResult = "Фамилия успешно изменена на " + _newsurname;
                }
              
            }
            catch (Exception e)
            {
                getResult = "Error !";
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> UpdateInfoSurnameProfile :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);
              
            }
            return getResult;
        }



        public string UpdateInfoNameProfile(int _iduser, string _newname)
        {
            string strResult = "";
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var result = db.Users.SingleOrDefault(u => u.id == _iduser);
                if (result != null)
                {
                    result.name_middle = _newname;
                    db.SaveChanges();
                    strResult = "Имья успешно изменена на " + _newname;
                }

            }
            catch (Exception e)
            {
                strResult = "Error !";
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> UpdateInfoNameProfile :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);

            }

            return strResult;
        }

        public string UpdateLastNameProfile(int _iduser, string newlastname)
        {
            string strResult = "";
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var result = db.Users.SingleOrDefault(u => u.id == _iduser);
                if (result != null)
                {
                    result.name_last = newlastname;
                    db.SaveChanges();
                    strResult = "Отчество успешно изменена на " + newlastname;
                }

            }
            catch (Exception e)
            {
                strResult = "Error !";
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> UpdateLastNameProfile :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);

            }
            return strResult;
        }


        public string UpdatePhoneProfile(int _iduser, string newphone)
        {
            string strResult = "";
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var result = db.Users.SingleOrDefault(u => u.id == _iduser);
                if (result != null)
                {
                    result.phone = newphone;
                    db.SaveChanges();
                    strResult = "Номер телефона успешно изменен на " + newphone;
                }

            }
            catch (Exception e)
            {
                strResult = "Error !";
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> UpdatePhoneProfile :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);

            }
            return strResult;
        }


        public string UpdateMailProfile(int _iduser, string newmail)
        {
            string strResult = "";
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var result = db.Users.SingleOrDefault(u => u.id == _iduser);
                if (result != null)
                {
                    result.phone = newmail;
                    db.SaveChanges();
                    strResult = "Почта успешно изменена на " + newmail;
                }

            }
            catch (Exception e)
            {
                strResult = "Error !";
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> UpdateMailProfile :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);

            }
            return strResult;
        }



        public string UpdateLoginProfile(int _iduser, string newlogin)
        {
            string strResult = "";
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var result = db.Users.SingleOrDefault(u => u.id == _iduser);
                if (result != null)
                {
                    var user = db.Users.FirstOrDefault(x => x.C_login == newlogin);
                     if (user != null)
                     {
                        strResult = "Пользователь стаким логином уже существует \n";
                     }
                     else
                     {
                         result.C_login = newlogin;
                         db.SaveChanges();
                         strResult = "Логин успешно изменен на " + newlogin;
                     }
                  
                }

            }
            catch (Exception e)
            {
                strResult = "Error !";
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> UpdateLoginProfile :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);

            }
            return strResult;
        }


        public string UpdatePasswordProfile(int _iduser, string newpasword)
        {
            string strResult = "";
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var result = db.Users.SingleOrDefault(u => u.id == _iduser);
                if (result != null)
                {
                    result.C_password = newpasword;
                    db.SaveChanges();
                    strResult = "Пароль успешно изменен на " + newpasword;
                }

            }
            catch (Exception e)
            {
                strResult = "Error !";
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> UpdatePasswordProfile :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);

            }
            return strResult;
        }


        public string UpdateImageProfile(int _iduser, string newimage)
        {
            string strResult = "";
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var result = db.Users.SingleOrDefault(u => u.id == _iduser);
                if (result != null)
                {
                    result.C_image = newimage;
                    db.SaveChanges();
                    strResult = "Фото успешно изменено на " + newimage;
                }

            }
            catch (Exception e)
            {
                strResult = "Error !";
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> UpdateImageProfile :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);

            }
            return strResult;
        }



        public string UpdateLocationProfile(int _iduser, int _idCountry, int _idRegion, int _idCity)
        {
            string strResult = "";
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var result = db.Users.SingleOrDefault(u => u.id == _iduser);
                if (result != null)
                {
                    result.id_country = _idCountry;
                    result.id_region = _idRegion;
                    result.id_sity = _idCity;
                    db.SaveChanges();
                    strResult = "Даные успешно изменены";
                }

            }
            catch (Exception e)
            {
                strResult = "Error !";
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> UpdateLocationProfile :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);

            }
            return strResult;
        }

        public string UpdateImageProgile(int _iduser, string _imageName)
        {
            string strResult = "";
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var result = db.Users.SingleOrDefault(u => u.id == _iduser);
                if (result != null)
                {
                    result.C_image = _imageName;
               
                    db.SaveChanges();
                    strResult = "Фото успешно изменено";
                }

            }
            catch (Exception e)
            {
                strResult = "Error !";
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_User -> UpdateImageProgile :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);

            }
            return strResult;
        }


        public string UpdateUser(int id, User user)
        {

            try
            {

                Sell_BuyEntities db = new Sell_BuyEntities();
                User u = db.Users.Find(id);
                u.name_first = user.name_first;
                u.name_last = user.name_last;
                u.name_middle = user.name_middle;
                u.phone = user.phone;
                u.mail = user.mail;
                u.id_country = user.id_country;
                u.id_region = user.id_region;
                u.id_sity = user.id_sity;
                //u.C_status = user.C_status;
                //u.active = user.active;
                u.id_language = user.id_language;
                u.C_image = user.C_image;
                //u.date_register = user.date_register;
                u.C_login = user.C_login;
                u.C_password = user.C_password;
                db.SaveChanges();
                return "Информация изменена";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

        public string DeleteUser(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                User user = db.Users.Find(id);

                db.Users.Attach(user);
                db.Users.Remove(user);
                db.SaveChanges();

                return user.name_last + "was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public User GetUser(int id)
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    User user = db.Users.Find(id);
                      //var  user = db.Users.FirstOrDefault(x => x.id == id);


                    var us = (from u in db.Users
                              where u.id == id
                              select u).ToList();

                    return user;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<string> GetDirection(int id)
        {
            Sell_BuyEntities db = new Sell_BuyEntities();
            List<string> userDirection = new List<string>();
             var us = (from u in db.Users
                              where u.id == id
                              select u).ToList();

             userDirection.Add(us[0].Country.name_country);
             userDirection.Add(us[0].Region.name_region);
             userDirection.Add(us[0].City.name_sity);
             return userDirection;
        }

        public List<User> GetallUsers()
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    List<User> user = (from x in db.Users
                                       select x).ToList();
                    return user;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
