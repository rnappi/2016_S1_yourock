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
    /// Interaction logic for UCCard.xaml
    /// </summary>
    public partial class UCCard : UserControl
    {
        private Card Card { get; set; }
        private int NumRepeated { get; set; }
        private bool ShowCheckbox { get; set; }
        private bool ShowPasteButton;
        public UCAlbum TargetList { get; set; }
        public UCFreeCardList SourceList { get; set; }

        public UCCard()
        {
            InitializeComponent();
        }

        public UCCard(Card card, bool showCheckbox = true, bool showPasteButton = false)
        {
            InitializeComponent();
            Card = card;
            ShowCheckbox = showCheckbox;
            ShowPasteButton = showPasteButton;
            LoadCardData();
        }

        private void LoadCardData()
        {
            // aplica a imagem ao card
            if (!String.IsNullOrWhiteSpace(Card.Image))
                ImageBox.Source = new ImageSourceConverter().ConvertFromString(AppConfig.IMAGE_DIRECTORY + Card.Image) as ImageSource;

            txtTitle.Text = Card.Name;
            NumRepeated = UserCard.ListRepeated(Card.Id).Count();
            txtRepeated.Text = "repetida(s): " + NumRepeated.ToString();

            if (ShowCheckbox)
            {
                ShowExchangeCheck();
                if (ShowExchange())
                    VerifyExchange();
            }
            else
                HiddeExchangeCheck();


            if (ShowPasteButton)
                ShowPasteBtn();
            else
                HiddePasteBtn();
        }

        private bool ShowExchange()
        {
            if (NumRepeated > 0 && ShowCheckbox)
            {
                cbChange.Opacity = 1;
                cbChange.IsEnabled = true;
                return true;
            }
            else
            {
                cbChange.Opacity = .4;
                cbChange.IsEnabled = false;
                return false;
            }
        }

        private void VerifyExchange()
        {
            var userCardExchange = UserCardExchange.SearchByUserAndCard(AppControl.AppUser.Id, Card.Id);
            cbChange.IsChecked = userCardExchange.AllowExchange;
        }

        private void cbChange_Click(object sender, RoutedEventArgs e)
        {
            var userCardExchange = new UserCardExchange();
            userCardExchange.UserID = AppControl.AppUser.Id;
            userCardExchange.CardID = Card.Id;
            userCardExchange.AllowExchange = cbChange.IsChecked.Value;
            userCardExchange.Merge();
        }

        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            var ucList = UserCard.ListByCardAndStatus(Card.Id, "unused");
            var userCard = ucList.ElementAt(0);
            userCard.UpdateStatus("album");
            SourceList.LoadCards();
            TargetList.LoadCards();
        }

        public void HiddePasteBtn()
        {
            btnPaste.Visibility = Visibility.Hidden;
        }

        public void HiddeExchangeCheck()
        {
            cbChange.Visibility = Visibility.Hidden;
        }

        public void ShowExchangeCheck()
        {
            cbChange.Visibility = Visibility.Visible;
            btnPaste.Visibility = Visibility.Hidden;
        }

        public void ShowPasteBtn()
        {
            btnPaste.Visibility = Visibility.Visible;
            cbChange.Visibility = Visibility.Hidden;
        }
    }
}