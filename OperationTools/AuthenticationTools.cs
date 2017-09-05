using DB_Entity_DAL.DB_Operations;
using DB_Entity_DAL.MedelsDataBase;
using OperationTools.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OperationTools
{

    public class UserInfoTools
    {
        public string userSurname { get; set; }
        public string userName { get; set; }
        public string userPhotoProfile { get; set; }
        public string userMail { get; set; }

    }

    public class AuthenticationTools
    {
        // Add new uesr for database 
        //      return res =  
        //  
        //
        private DB_User dbUser = new DB_User();
        private User user = null;
        private AllUrlPuth url = new AllUrlPuth();
        public string RegisterUser(string _surname, string _name, string _lastname
            , string _phone, string _email, string _login
            , string _password, int _idcountry, int _idRegion
            , int _idSity, string _photo
            )
        {

            string checkUser = dbUser.searchUser(_login, _email, _phone);

            if (checkUser == "")
            {
                user = new User
                {
                    name_first = _surname,
                    name_last = _lastname,
                    name_middle = _name,
                    phone = _phone,
                    mail = _email,
                    id_country = _idcountry,
                    id_region = _idRegion,
                    id_sity = _idSity,
                    C_status = 1,
                    active = 1,
                    id_language = 1,
                    C_image = _photo.ToString(),
                    date_register = String.Format("{0:d.M.yyyy HH:mm:ss}", DateTime.Now),
                    C_login = _login.ToString(),
                    C_password = _password.ToString()
                };

                dbUser.InsertUser(user);
                return "";
            }
            else
            {
                return checkUser;
            }



        }


        public string SignInUserTools(string _login, string _password)
        {
            string resultSignIn = dbUser.SignInUserCheckDataBase(_login, _password);
            //if (resultSignIn.IndexOf("success") != -1)
            //{
            //    string[] split = resultSignIn.Split('/');
            //    split[0].Replace("id=", " ");
            //    string id = split[0].Replace("id=", " ").Trim();

            //    //Cookie aCookie = new Cookie();
            //    //aCookie.Name = "Authentication";
            //    //aCookie.Value = id;
            //    //HttpWebResponse s = new HttpWebResponse();
            //    //s.Cookies.Add(aCookie);

            //    resultSignIn = split[1].Replace("success", " ");
            //    // HttpCookie aCookie = new HttpCookie("Authentication");
            //}
            return resultSignIn.Trim();
        }

        public UserInfoTools GetInfoUser(int id)
        {
            UserInfoTools usInfo = null;

            var userInfo = dbUser.GetUser(id);

            if (userInfo != null)
            {
                usInfo = new UserInfoTools
                {
                    userSurname = userInfo.name_first,
                    userName = userInfo.name_middle,
                    userPhotoProfile = url.photoProfileUserPuth +  userInfo.C_image,
                    userMail = userInfo.mail

                };
            }

            return usInfo;
        }
    }
}
