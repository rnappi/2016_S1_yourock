using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Yourock.App_code
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }

        public User()
        {
            Status = true;
            Type = AppConfig.TYPE_USER_PLAYER;
        }

        public static List<User> ListByType(string userType)
        {
            List<User> tempUser = new List<User>();
            tempUser = XMLData.LoadXmlData<User>(AppConfig.XML_FILE_USERS, AppConfig.ERROR_LOAD_USERS).FindAll(x => x.Type == userType);
            return tempUser;
        }

        public static bool FindUserByLoginAndPass(string login, string pass, out User user)
        {
            List<User> tempUser = new List<User>();
            tempUser = XMLData.LoadXmlData<User>(AppConfig.XML_FILE_USERS, AppConfig.ERROR_LOAD_USERS).FindAll(x => x.Login == login && x.Password == pass);

            if (tempUser.Count > 0)
            {
                user = tempUser.ElementAt(0);
                return true;
            }
            else
            {
                user = new User();
                return false;
            }
        }

        public void AddToXML()
        {
            List<User> users = XMLData.LoadXmlData<User>(AppConfig.XML_FILE_USERS, AppConfig.ERROR_LOAD_USERS);
            Id = users.Count + 1;
            users.Add(this);
            XMLData.SaveXmlData(users, AppConfig.XML_FILE_USERS, AppConfig.ERROR_SAVE_USERS);
        }
    }
}