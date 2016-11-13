using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Yourock.App_code
{
    public class UserCard
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("UserID")]
        public int UserID { get; set; }

        [XmlAttribute("CardID")]
        public int CardID { get; set; }

        [XmlAttribute("Status")]
        public string Status { get; set; }

        public UserCard() {}

        public UserCard(int userID, int cardID)
        {
            ID = ListAll().Count + 1;
            UserID = userID;
            CardID = cardID;
            Status = SetStatus();
        }

        public static List<UserCard> ListAll()
        {
            var userCards = XMLData.LoadXmlData<UserCard>(AppConfig.XML_FILE_USER_CARD, AppConfig.ERROR_LOAD_CARDS);
            return userCards;
        }

        public static List<UserCard> ListByUser(int userID)
        {
            var userCards = XMLData.LoadXmlData<UserCard>(AppConfig.XML_FILE_USER_CARD, AppConfig.ERROR_LOAD_CARDS);
            return userCards.FindAll(uc => uc.UserID == userID);
        }

        public static List<UserCard> ListByCardAndStatus(int cardID, string status)
        {
            var userCards = ListByUser(AppControl.AppUser.Id);
            return userCards.FindAll(uc => uc.CardID == cardID && uc.Status == status);     
        }

        public static List<UserCard> ListRepeated(int cardID)
        {
            var userCards = ListByUser(AppControl.AppUser.Id);
            return userCards.FindAll(uc => uc.CardID == cardID 
                                           && (uc.Status == "free"));
        }

        public static List<UserCard> ListUnused()
        {
            var userCards = ListByUser(AppControl.AppUser.Id);
            var unused = userCards.GroupBy(i => i.CardID)
                                  .Select(g => g.First())
                                  .Where(i => i.Status == "unused")
                                  .ToList();
            return unused;
        }

        public static List<UserCard> ListFreeToExchange(int userID)
        {
            var exchangeCardsPermissions = UserCardExchange.ListByUser(userID).Where(c => c.AllowExchange == true).ToList();
            var userCards = UserCard.ListByUser(userID).Where(c => c.Status == "free").ToList();
            var list = (from userCard in userCards
                        join permission in exchangeCardsPermissions
                        on userCard.CardID equals permission.CardID
                        select new { userCard }).ToList();
            var exchangeUserCard = new List<UserCard>();
            foreach (var item in list)
            {
                exchangeUserCard.Add(item.userCard);
            }

            return exchangeUserCard;
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
                list.Add(this);
            }
            XMLData.SaveXmlData(list, AppConfig.XML_FILE_USER_CARD, AppConfig.ERROR_SAVE_USER_CARDS);
        }

        public static List<UserCard> Shuffle(int userID)
        {
            var bonusCard = new List<UserCard>();
            var cards = Card.ListCards();
            var random = new Random();
            for (int i = 0; i < AppConfig.BONUS_CARDS; i++)
            {
                var card = cards.ElementAt(random.Next(cards.Count));
                var userCard = new UserCard(userID, card.Id);
                userCard.Merge();
                bonusCard.Add(userCard);
            }
            return bonusCard;
        }

        public void UpdateStatus(string status)
        {
            Status = status;
            Merge();
        }

        private string SetStatus()
        {
            if (ListByUser(AppControl.AppUser.Id).Any(c => c.CardID == CardID))
            {
                return "free";
            }
            else
            {
                return "unused";
            }
        }

        public static UserCard SearchById(int userCardID)
        {
            return ListAll().Find(x => x.ID == userCardID);
        }
    }
}