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

namespace DesktopApp
{
    /// <summary>
    /// Logika interakcji dla klasy CustomerLoans.xaml
    /// </summary>
    public partial class CustomerLoans : Window
    {
        public CustomerLoans(Customer customer)
        {
            InitializeComponent();
            LoadCustomerLoansWindow(customer);
        }

        public void LoadCustomerLoansWindow(Customer customer)
        {
            MessageBox.Show("xD");
        }
    }
}
