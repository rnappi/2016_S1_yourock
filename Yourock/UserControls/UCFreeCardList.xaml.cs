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
    /// Interaction logic for UCFreeCardList.xaml
    /// </summary>
    public partial class UCFreeCardList : UserControl
    {
        public UCAlbum TargetList { get; set; }
        public UCFreeCardList()
        {
            InitializeComponent();
        }

        public void LoadCards()
        {
            FreeCardsList.Children.Clear();
            var cards = UserCard.ListUnused();
            foreach (var item in cards)
            {
                var card = new UCCard(Card.SearchCardById(item.CardID), false, true);
                card.TargetList = TargetList;
                card.SourceList = this;
                FreeCardsList.Children.Add(card);
            }
        }
    }
}