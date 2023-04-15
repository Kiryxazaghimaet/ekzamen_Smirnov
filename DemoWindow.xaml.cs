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
using ekzamen.Models;

namespace ekzamen
{
    /// <summary>
    /// Логика взаимодействия для DemoWindow.xaml
    /// </summary>
    public partial class DemoWindow : Window
    {
        public DemoWindow()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            var list = AutoREntities.GetContext().Order.ToList();
            orderList.ItemsSource = list;
        }
    }
}
