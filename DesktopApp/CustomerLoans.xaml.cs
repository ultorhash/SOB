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
            StackPanel sp = new StackPanel
            {
                Height = 320,
            };

            List<Loan> loans = new List<Loan>();
            using (var context = new SystemObsługiBankuDBEntities())
            {
                loans = context.Loan.Where(x => x.CustomerID == customer.ID).ToList();
            }

            UICustomerDockPanel description = new UICustomerDockPanel(
                new string[6] { "Kwota ( ZŁ )", "Procent", "Pożyczono", "Spłata do", "Do spłaty ( ZŁ )", "Pozostało dni" });
            
            sp.Children.Add(description);

            List<UICustomerDockPanel> dockPanelsAccounts = new List<UICustomerDockPanel>();
            foreach (var item in loans)
            {
                var x = new UICustomerDockPanel(item.Balance, item.PercentValue, item.StartDate, item.EndDate);
                dockPanelsAccounts.Add(x);
                sp.Children.Add(x);
            }

            UIButton btnBack = new UIButton("Powrót");
            UIButtonsDockPanel buttons = new UIButtonsDockPanel(btnBack) { Margin = new Thickness(0, 10, 0, 0) };
            
            sp.Children.Add(buttons);
            customerLoans.Children.Add(sp);

            btnBack.Click += DeleteWindow;

            void DeleteWindow(object o, EventArgs ev) => Close();
        }
    }
}
