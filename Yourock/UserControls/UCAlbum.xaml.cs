using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Yourock.App_code;
using Yourock.Pages;

namespace Yourock.UserControls
{
    /// <summary>
    /// Interaction logic for UCAlbum.xaml
    /// </summary>
    public partial class UCAlbum : UserControl
    {
        private Canvas ListHeader { get; set; }
        public Album Container { get; set; }
        public UCAlbum()
        {
            InitializeComponent();
            ListHeader = cvHeader;
        }

        public void LoadCards()
        {
            CardList.Children.Clear();
            CardList.Children.Add(ListHeader);
            var cards = Card.ListCards();
            foreach (var c in cards)
            {
                var userCards = UserCard.ListByCardAndStatus(c.Id, "album");
                var exchangeUserCards = UserCard.ListByCardAndStatus(c.Id, "exchange");
                if (userCards.Count > 0)
                {
                    var ucCard = new UCCard(c);
                    CardList.Children.Add(ucCard);
                }
                else if (exchangeUserCards.Count > 0)
                {
                    var ucCard = new UCEmptyCard(c, true);
                    ucCard.Container = Container;
                    CardList.Children.Add(ucCard);
                }
                else
                {
                    var ucCard = new UCEmptyCard(c);
                    ucCard.Container = Container;
                    CardList.Children.Add(ucCard);
                }
            }
        }
    }
}
