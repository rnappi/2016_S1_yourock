using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Yourock.App_code
{
    public class Exchange
    {
        [XmlAttribute("ID")]
        public int ID;

        [XmlAttribute("SenderUserID")]
        public int SenderUserID { get; set; }

        [XmlAttribute("SenderUserCardID")]
        public int SenderUserCardID { get; set; }

        [XmlAttribute("DestinationUserID")]
        public int DestinationUserID { get; set; }

        [XmlAttribute("DestinationUserCardID")]
        public int DestinationUserCardID { get; set; }

        [XmlAttribute("Status")]
        public string Status;

        [XmlIgnoreAttribute]
        public int WantedCardID { get; set; }

        [XmlIgnoreAttribute]
        public UserCard SenderUserCard { get; set; }

        [XmlIgnoreAttribute]
        public UserCard DestinationtUserCard { get; set; }

        public Exchange(){}

        public Exchange(int wantedCardID)
        {
            ID = ListAll().Count + 1;
            WantedCardID = wantedCardID;
            Status = "waiting";
        }

        public bool Match()
        {
            var senderExchangeUserCards = UserCard.ListFreeToExchange(AppControl.AppUser.Id);
            var players = User.ListByType("user");
            foreach (var player in players)
            {
                // procura se existe alguem com a carta desejada pelo sender
                var destinationExchangeUserCards = UserCard.ListFreeToExchange(player.Id);
                if (destinationExchangeUserCards.Any(uc => uc.CardID == WantedCardID))
                {
                    // verifico se existe alguma carta do sender que serve para o destination
                    var destinationUserCards = UserCard.ListByUser(player.Id);
                    foreach (var sendExUserCard in senderExchangeUserCards)
                    {
                        if ( !(destinationUserCards.Any(x => x.CardID == sendExUserCard.CardID)) )
                        {
                            SenderUserCard = sendExUserCard;
                            DestinationtUserCard = destinationExchangeUserCards.Find(x => x.CardID == WantedCardID);
                            SenderUserID = SenderUserCard.UserID;
                            SenderUserCardID = SenderUserCard.ID;
                            DestinationUserID = DestinationtUserCard.UserID;
                            DestinationUserCardID = DestinationtUserCard.ID;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static List<Exchange> ListAll()
        {
            var exchanges = XMLData.LoadXmlData<Exchange>(AppConfig.XML_FILE_EXCHANGE, AppConfig.ERROR_LOAD_EXCHANGE);
            return exchanges;
        }

        public void Merge()
        {
            var list = ListAll();
            var index = list.FindIndex(x => x.ID == ID);
            if (index >= 0)
            {
                list[index] = this;
            }
            else
            {
                SenderUserCard.UpdateStatus("exchange");
                DestinationtUserCard.UpdateStatus("exchange");
                list.Add(this);
            }
            XMLData.SaveXmlData(list, AppConfig.XML_FILE_EXCHANGE, AppConfig.ERROR_SAVE_EXCHANGE);
        }

        public static List<Exchange> searchByUserAndStatus(int userID, string status)
        {
            return ListAll().FindAll(x => x.DestinationUserID == userID && x.Status == status);
        }
    }
}