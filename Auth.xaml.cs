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
using System.Windows.Shapes;

namespace ekzamen
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        int k = 0;
        int authId = 0;
        public Auth()
        {
            InitializeComponent();
        }
        private void btnauth_Click(object sender, RoutedEventArgs e)
        {
            Authentication();
        }
        private void Authentication()
        {
            if (txtLog.Text == "DEMO" && txtPass.Password == "DEMO")
            {
                DemoWindow dw = new DemoWindow();
                dw.Show();
                this.Close();
            }
            else if (txtLog.Text != "")
            {
                Personal authUser = null;
                authUser = new Personal();
                using (AutoREntities db = new AutoREntities())
                {
                    string login = txtLog.Text.Trim();
                    string password = txtPass.Password.Trim();
                    authUser = db.Personal.Where(b => b.PersonalLogin == login && b.PersonalPassword == password).FirstOrDefault();
                    authId = db.Personal.Select(i => i.Id).FirstOrDefault();

                }
                if (authUser != null)
                {
                    MessageBox.Show("Вы авторизовались");
                    MainWindow mw = new MainWindow(authUser);
                    mw.Show();
                    this.Close();
                    k--;
                }
            }
        }
    }
}
