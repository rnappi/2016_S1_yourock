using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Yourock.App_code
{
    public class Log
    {
        [XmlAttribute("UserID")]
        public int UserID { get; set; }

        [XmlAttribute("AccessDate")]
        public DateTime AccessDate { get; set; }

        public Log()
        {
            AccessDate = DateTime.Now;
        }

        public Log(int userID)
        {
            UserID = userID;
            AccessDate = DateTime.Now;
        }

        public static List<Log> LoadAll()
        {
            return XMLData.LoadXmlData<Log>(AppConfig.XML_FILE_LOGS, AppConfig.ERROR_LOAD_LOGS);
        }

        public bool WasLoggedToday()
        {
            List<Log> logs = LoadAll();
            return logs.Exists(x => x.UserID == UserID && x.AccessDate.Date == AccessDate.Date);
        }

        public void AddDayLog()
        {
            List<Log> logs = LoadAll();
            logs.Add(this);
            XMLData.SaveXmlData(logs, AppConfig.XML_FILE_LOGS, AppConfig.ERROR_LOAD_LOGS);
        }
    }
}