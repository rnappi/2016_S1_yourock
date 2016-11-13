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

namespace Yourock.Pages
{
    /// <summary>
    /// Interaction logic for AdminUser.xaml
    /// </summary>
    public partial class AdminUser : Page
    {
        public Dictionary<string, string> UserTypes = new Dictionary<string, string>();
        public AdminUser()
        {
            InitializeComponent();
            UserTypes.Add(AppConfig.TYPE_USER_ADMIN, "Administrador");
            UserTypes.Add(AppConfig.TYPE_USER_PLAYER, "Jogador");
            cblType.ItemsSource = UserTypes;
            cblType.DisplayMemberPath = "Value";
            cblType.SelectedValuePath = "Key";
        }

        public void ClearInputs()
        {
            txtLogin.Text = "";
            txtPassword.Password = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password) || cblType.SelectedValue == null)
            {
                txtError.Foreground = new SolidColorBrush(Color.FromRgb(207, 29, 29));
                txtError.Text = "ERRO: Todos os campos devem ser preenchidos.";
                txtLogin.Focus();
                ClearInputs();
            }
            else
            {
                User user = new User();
                user.Login = login;
                user.Password = password;
                user.Type = cblType.SelectedValue.ToString();
                user.AddToXML();
                txtError.Foreground = new SolidColorBrush(Color.FromRgb(24, 193, 70));
                txtError.Text = "SUCESSO: Cadastro realizado com sucesso!";
                ClearInputs();
            }
        }
    }
}