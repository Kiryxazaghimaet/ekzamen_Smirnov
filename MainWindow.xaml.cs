using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ekzamen.Models;

namespace ekzamen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            Authentication();
        }
        private void Authentication()
        {
            string login = txtLog.Text.Trim();
            string password = txtPass.Password.Trim();
            int authId = 0;
            Personal authUser = null;
            if (txtLog.Text=="DEMO"&& txtPass.Password=="DEMO")
            {
                DemoWindow dw = new DemoWindow();
                dw.Show();
                this.Close();
            }
            else if(txtLog.Text != "" && txtPass.Password!="")
            {
                
                using (AutoREntities db = new AutoREntities())
                {
                    authUser = db.Personal.Where(t=>t.PersonalLogin==login && t.PersonalPassword == password).FirstOrDefault();
                    authId = db.Personal.Select(i => i.Id).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Вы авторизовались");
                    ViewWindow vw = new ViewWindow();
                    vw.Show();
                    this.Close();
                }
            }
        }
    }
}
