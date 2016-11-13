using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Yourock.App_code
{
    public class UserCardExchange
    {
        [XmlAttribute("USerID")]
        public int UserID { get; set; }

        [XmlAttribute("CardID")]
        public int CardID { get; set; }

        [XmlAttribute("AllowExchange")]
        public bool AllowExchange { get; set; }

        public static List<UserCardExchange> ListAll()
        {
            return XMLData.LoadXmlData<UserCardExchange>(AppConfig.XML_FILE_USER_CARD_EXCHANGE, AppConfig.ERROR_LOAD_USER_CARD_EXCHANGE);
        }

        public static UserCardExchange SearchByUserAndCard(int userID, int cardID)
        {
            var list = ListAll();
            int index = list.FindIndex(i => i.UserID == userID && i.CardID == cardID);
            if (index >= 0)
            {
                return list.ElementAt(index);
            }
            else
            {
                return new UserCardExchange();
            }      
        }

        public static List<UserCardExchange> ListByUser(int userID)
        {
            var list = ListAll().FindAll(i => i.UserID == userID);
            return list;
        }

        public void Merge()
        {
            var list = ListAll();
            int index = list.FindIndex(i => i.UserID == UserID && i.CardID == CardID);
            if (index != -1)
            {
                list[index] = this;
            }
            else
            {
                list.Add(this);
            }
            XMLData.SaveXmlData(list, AppConfig.XML_FILE_USER_CARD_EXCHANGE, AppConfig.ERROR_SAVE_USER_CARD_EXCHANGE);
        }
    }
}
