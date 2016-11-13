using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Yourock.App_code;

namespace Yourock
{
    public static class AppControl
    {
        public static MainWindow MainPage;
        public static User AppUser;
        public static List<User> Users { get; set; }
        public static List<Card> Cards { get; set; }
        public static bool IsUserLogged = false;
        public static List<UserCard> BonusUserCards { get; set; }
        public static void Switch(Page newPage)
        {
            MainPage.Navigate(newPage);
        }
    }
}