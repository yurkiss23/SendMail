using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
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

namespace SendMail
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string url = null;

        public MainWindow()
        {
            InitializeComponent();
            url = $"{ConfigurationManager.AppSettings["baseUrl"]}api/MessageUsers";

            txtSubject.Focus();
        }

        private void mlbd_click(object sender, MouseButtonEventArgs e)
        {
            txtMail.Text = "mail:";
            imgDel.Visibility = Visibility.Hidden;
        }

        private void SelectionChaged_Mail(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
            {
                imgDel.Visibility = Visibility.Visible;
            }
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Content-Type", "application/json");
                string method = "POST";
                string data = JsonConvert.SerializeObject(new
                {
                    ReceiverEmail = txtMail.Text,
                    Title = txtSubject.Text,
                    Body = txtMessage.Text
                });
                //MessageBox.Show(data);
                var result = client.UploadString(url, method, data);
            }
            this.Close();
        }

        private void GotFocus_Subj(object sender, RoutedEventArgs e)
        {
            txtSubject.SelectAll();
        }

        private void GotFocus_Message(object sender, RoutedEventArgs e)
        {
            txtMessage.SelectAll();
        }

        private void GotFocus_Mail(object sender, RoutedEventArgs e)
        {
            txtMail.SelectAll();
        }
    }
}
