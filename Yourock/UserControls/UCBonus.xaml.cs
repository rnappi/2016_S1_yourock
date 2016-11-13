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

namespace Yourock.UserControls
{
    /// <summary>
    /// Interaction logic for UCBonus.xaml
    /// </summary>
    public partial class UCBonus : UserControl
    {
        public Grid grdContainer { get; set; }
        public UCBonus()
        {
            InitializeComponent();
        }

        public void ShowCards(List<UserCard> userCards)
        {
            foreach (var item in userCards)
            {
                var cardData = Card.SearchCardById(item.CardID);
                var card = new UCCard(cardData, false);
                ListCards.Children.Add(card);
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            grdContainer.Children.Remove(this);
        }
    }
}