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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Yourock.App_code;
using Yourock.UserControls;

namespace Yourock.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            txtLogin.Focus();
        }

        #region Methods
        public void CleanFormData()
        {
            txtLogin.Text = "";
            txtPassword.Password = "";
            txtLogin.Focus();
        }
        #endregion

        #region Events
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (User.FindUserByLoginAndPass(txtLogin.Text, txtPassword.Password, out AppControl.AppUser))
            {
                AppControl.IsUserLogged = true;
                if (AppControl.AppUser.Type == AppConfig.TYPE_USER_ADMIN)
                {
                    AppControl.Switch(new AdminUser());
                }
                else
                {
                    Log log = new Log(AppControl.AppUser.Id);
                    AppControl.BonusUserCards = new List<UserCard>();

                    if (!log.WasLoggedToday())
                    {
                        AppControl.BonusUserCards = UserCard.Shuffle(AppControl.AppUser.Id);
                        log.AddDayLog();
                    }

                    AppControl.Switch(new Album());
                }
            }
            else
            {
                AppControl.IsUserLogged = false;
                CleanFormData();

                // anima os campos do form
                Storyboard anFail = FindResource("login_fail") as Storyboard;
                anFail.Begin();

                if (pnlErrorMessage.Visibility == Visibility.Hidden)
                {
                    Storyboard anBtnFail = FindResource("btn_login_fail") as Storyboard;
                    anBtnFail.Completed += new EventHandler(ShowErrorMessage);
                    anBtnFail.Begin();
                }
            }
        }

        private void ShowErrorMessage(object sender, EventArgs e)
        {
            pnlErrorMessage.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
