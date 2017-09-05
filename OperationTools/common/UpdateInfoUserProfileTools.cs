using DB_Entity_DAL.DB_Operations;
using DB_Entity_DAL.MedelsDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationTools.common
{
    public class UserInfo
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
    }

    public class UpdateInfoUserProfileTools
    {
        DB_User dbuser = new DB_User();
        private AllUrlPuth url = new AllUrlPuth();
        public UserInfo GetAllInfoUser(int id)
        {
            UserInfo user = null;
            var usInfo = dbuser.GetUser(id);
            var direction = dbuser.GetDirection(id);
            if(usInfo != null)
            {
                user = new UserInfo
                {
                    Surname = usInfo.name_first,
                    Name = usInfo.name_middle,
                    LastName = usInfo.name_last,
                    Phone = usInfo.phone,
                    Mail = usInfo.mail,
                    Login = usInfo.C_login,
                    Password = usInfo.C_password,
                    Country = direction[0],
                    Region = direction[1],
                    City = direction[2],
                    Image = url.photoProfileUserPuth+ usInfo.C_image

                };
            }

            return user;
        }


      

        public string UpdateInfoProfileByParamsTools(int _param, int _id, string _infoupdate)
        {
               string strResult = "";
            switch(_param)
            {
                case 1:
                    strResult = dbuser.UpdateInfoSurnameProfile(_id, _infoupdate);
                    break;
                case 2:
                    strResult = dbuser.UpdateInfoNameProfile(_id, _infoupdate);
                    break;
                case 3:
                    strResult = dbuser.UpdateLastNameProfile(_id, _infoupdate);
                    break;
                case 4:
                    strResult = dbuser.UpdatePhoneProfile(_id, _infoupdate);
                    break;
                case 5:
                    strResult = dbuser.UpdateMailProfile(_id, _infoupdate);
                    break;
                case 6:
                    strResult = dbuser.UpdateLoginProfile(_id, _infoupdate);
                    break;
                case 7:
                    strResult = dbuser.UpdatePasswordProfile(_id, _infoupdate);
                    break;
                case 8:
                    strResult = dbuser.UpdateImageProgile(_id, _infoupdate);
                    break;
            }

       
            return strResult;
        }


        public string UpdateLocationProfileTools(int _idUser , int _idCountry, int _idRegion, int _idCity)
        {
            string strResult = "";
            strResult = dbuser.UpdateLocationProfile(_idUser, _idCountry, _idRegion, _idCity);
            return strResult;
        }


        public string UpdatAllInfoUserProfileTools(int _iduser , string _surname, string _name, string _lastname
            , string _phone, string _mail, string _login
            , string _password, int _idCountry, int _idRegion
            , int _idCity , string _image)
        {
            User userNew = new User
            {
                name_first = _surname,
                name_middle = _name,
                name_last = _lastname,
                phone = _phone,
                mail = _mail,
                C_login = _login,
                C_password = _password,
                id_country = _idCountry,
                id_region = _idRegion,
                id_sity = _idCity,
                C_image = _image,
                C_status = 1,
                active = 1,
                id_language = 1,
                date_register = ""

            };

            dbuser.UpdateUser(_iduser, userNew);
            return "";
        }

    }
}
