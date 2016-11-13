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
using Yourock.UserControls;

namespace Yourock.Pages
{
    /// <summary>
    /// Interaction logic for Album.xaml
    /// </summary>
    public partial class Album : Page
    {
        private UserControl CenterList { get; set; }
        private UserControl SideList { get; set; }
        public Album()
        {
            InitializeComponent();
            CrateAlbum();
            CreateFreeCardList();
            if (AppControl.BonusUserCards.Count > 0)
            {
                CreateBonusView();
            }

            CheckExchange();
        }

        public void CrateAlbum()
        {
            var appAlbum = new UCAlbum();
            appAlbum.Container = this;
            appAlbum.LoadCards();
            CenterList = appAlbum;
            AlbumContainer.Children.Clear();
            AlbumContainer.Children.Add(CenterList);
        }

        public void CreateFreeCardList()
        {
            var freeCardList = new UCFreeCardList();
            freeCardList.TargetList = (UCAlbum)CenterList;
            freeCardList.LoadCards();
            SideList = freeCardList;
            SideListContainer.Children.Clear();
            SideListContainer.Children.Add(SideList);
        }

        public void CreateBonusView()
        {
            var bonusView = new UCBonus();
            bonusView.ShowCards(AppControl.BonusUserCards);
            bonusView.grdContainer = grdConatiner;
            grdConatiner.Children.Add(bonusView);
        }

        public void CreateExchangeView(Exchange exchange, bool isChecking = false)
        {
            var exchangeView = new UCExchange(exchange, isChecking);
            exchangeView.Container = this;
            grdConatiner.Children.Add(exchangeView);
        }

        public void RemoveExchangeView(UCExchange exchangeView, bool checkEchange = false)
        {
            grdConatiner.Children.Remove(exchangeView);
            if (checkEchange)
            {
                CheckExchange();
            }
            CrateAlbum();
            CreateFreeCardList();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CreateFreeCardList();
        }

        public void CheckExchange()
        {
            var exchanges = Exchange.searchByUserAndStatus(AppControl.AppUser.Id, "waiting");
            if (exchanges.Count > 0)
            {
                CreateExchangeView(exchanges[0], true);
            }
        }
    }
}