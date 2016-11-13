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
    /// Interaction logic for UCEmptyCard.xaml
    /// </summary>
    public partial class UCEmptyCard : UserControl
    {
        public int Id { get; set; }
        public Card Card { get; set; }
        public Album Container { get; set; }

        public UCEmptyCard()
        {
            InitializeComponent();
        }

        public UCEmptyCard(Card card, bool isExchange = false)
        {
            InitializeComponent();
            Card = card;
            txtTitle.Text = Card.Name;

            if (isExchange)
            {
                btnLogin.Visibility = Visibility.Hidden;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var exchange = new Exchange(Card.Id);
            if (exchange.Match())
            {
                Container.CreateExchangeView(exchange);
            }
        }
    }
}