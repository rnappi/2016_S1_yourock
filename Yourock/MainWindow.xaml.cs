using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using Yourock.App_code;
using Yourock.Pages;

namespace Yourock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialiazeApplication();
            AppControl.MainPage = this;
            AppControl.Switch(new Login());
        }

        public void InitialiazeApplication()
        {
            // verifica se o arquivo de usuários não existe ou está vazio e cria
            if (!File.Exists(AppConfig.XML_FILE_USERS) || new FileInfo(AppConfig.XML_FILE_USERS).Length == 0)
            {
                User adminDefault = new User();
                adminDefault.Id = 1;
                adminDefault.Login = "admin";
                adminDefault.Password = "admin";
                adminDefault.Type = AppConfig.TYPE_USER_ADMIN;

                List<User> adminUsers = new List<User>();
                adminUsers.Add(adminDefault);
                XMLData.SaveXmlData(adminUsers, AppConfig.XML_FILE_USERS, AppConfig.ERROR_SAVE_USERS);
            }

            // verifica se o arquivo de logs não existe e cria
            if (!File.Exists(AppConfig.XML_FILE_LOGS))
            {
                List<Log> listLog = new List<Log>();
                XMLData.SaveXmlData(listLog, AppConfig.XML_FILE_LOGS, AppConfig.ERROR_LOAD_LOGS);
            }

            // verifica se o arquivo de cards não existe e cria
            if (!File.Exists(AppConfig.XML_FILE_CARDS))
            {
                List<Card> listCard = new List<Card>();
                for (int i = 1; i <= AppConfig.NUMBER_OF_CARDS; i++)
                {
                    Card card = new Card();
                    card.Id = i;
                    listCard.Add(card);
                }
                XMLData.SaveXmlData(listCard, AppConfig.XML_FILE_CARDS, AppConfig.ERROR_SAVE_CARDS);
            }
        }

        public void Navigate(Page nextPage)
        {
            this.frmContainer.Content = nextPage;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}