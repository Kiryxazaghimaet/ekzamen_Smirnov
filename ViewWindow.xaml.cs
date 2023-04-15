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
    /// Логика взаимодействия для ViewWindow.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {
        Models.AutoREntities db = new Models.AutoREntities();
        public ViewWindow()
        {
            InitializeComponent();

        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetData(tbSearch.Text, cmbFilter.Text);
        }
        private void GetData(string search = "", string filter = "")
        {
            var data = AppData.DB.Order.ToList();
            int countBefore = data.Count;
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                data = data.Where(c => c.Auto.StateNumber.ToLower().Contains(search.ToLower())
                || c.Auto.Client.FullName.ToLower().Contains(search.ToLower())).ToList();
            }
            if (filter != "Все")
            {
                data = data.Where(c => c.Status.StatusName == filter).ToList();
            }
            int countAfter = data.Count;
            dgOrders.ItemsSource = data;
            tblCountRecord.Text = $"{countAfter} из {countBefore}";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            GetData(tbSearch.Text, cmbFilter.Text);
        }
        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetData(tbSearch.Text, ((ComboBoxItem)cmbFilter.SelectedValue).Content.ToString());
        }
    }
}
