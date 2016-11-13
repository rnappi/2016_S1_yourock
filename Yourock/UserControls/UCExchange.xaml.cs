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
    /// Interaction logic for UCExchange.xaml
    /// </summary>
    public partial class UCExchange : UserControl
    {
        public Album Container { get; set; }
        private Exchange Exchange {get;set;}
        private bool IsChecking { get; set; }
        private UserCard DestinationUserCard { get; set; }
        private UserCard SenderUserCard { get; set; }
        public UCExchange()
        {
            InitializeComponent();
        }

        public UCExchange(Exchange exchange, bool isChecking = false)
        {
            InitializeComponent();
            Exchange = exchange;
            IsChecking = isChecking;
            DestinationUserCard = UserCard.SearchById(Exchange.DestinationUserCardID);
            SenderUserCard = UserCard.SearchById(Exchange.SenderUserCardID);
            var destinationCard = new UCCard(Card.SearchCardById(DestinationUserCard.CardID), false, false);
            var senderCard = new UCCard(Card.SearchCardById(SenderUserCard.CardID), false, false);

            if (IsChecking)
            {
                DestinationContainer.Children.Add(senderCard);
                SenderContainer.Children.Add(destinationCard);
            }
            else
            {
                DestinationContainer.Children.Add(destinationCard);
                SenderContainer.Children.Add(senderCard);
            }
        }

        private void CloseUCExchange()
        {
            Container.RemoveExchangeView(this, IsChecking);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (IsChecking)
            {
                Exchange.Status = "cancel";
                var senderUserID = SenderUserCard.UserID;
                var destUserID = DestinationUserCard.UserID;

                SenderUserCard.UserID = destUserID;
                SenderUserCard.Status = "unused";
                SenderUserCard.Merge();

                DestinationUserCard.UserID = senderUserID;
                DestinationUserCard.Status = "unused";
                DestinationUserCard.Merge();

                Exchange.Status = "approved";
            } 
            Exchange.Merge();
            CloseUCExchange();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (IsChecking)
            {
                SenderUserCard.Status = "free";
                SenderUserCard.Merge();

                DestinationUserCard.Status = "free";
                DestinationUserCard.Merge();

                Exchange.Status = "cancel";
                Exchange.Merge();
            }
            CloseUCExchange();
        }
    }
}