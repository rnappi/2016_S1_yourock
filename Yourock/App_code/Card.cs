using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yourock.App_code
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Sound { get; set; }

        public static List<Card> ListCards()
        {
            List<Card> cards = XMLData.LoadXmlData<Card>(AppConfig.XML_FILE_CARDS, AppConfig.ERROR_LOAD_CARDS);
            return cards;
        }

        public static Card SearchCardById(int Id)
        {
            var cards = ListCards();
            var card = cards.Find(c => c.Id == Id);
            return card;
        }
    }
}