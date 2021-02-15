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
    /// Logika interakcji dla klasy CustomerRepaymentLoan.xaml
    /// </summary>
    public partial class CustomerRepaymentLoan : Window
    {
        public CustomerRepaymentLoan(Customer customer)
        {
            InitializeComponent();
            LoadRepaymentLoanWindow(customer);
        }

        public void LoadRepaymentLoanWindow(Customer customer)
        {
            StackPanel sp = new StackPanel
            {
                Height = 320,
            };

            AppButton.ActionButton btnBack = new AppButton.ActionButton("Powrót");
            AppButton.ActionButton btnApply = new AppButton.ActionButton("Spłać");

            List<Loan> loans = new List<Loan>();
            using (var context = new SystemObsługiBankuDBEntities())
            {
                loans = context.Loan.Where(x => x.CustomerID == customer.ID).ToList();
            }

            List<UICustomerDockPanel> dockPanelsLoans = new List<UICustomerDockPanel>();
            foreach (var item in loans)
            {
                var x = new UICustomerDockPanel(
                    ("Kwota początkowa " + Math.Round(item.Balance, 2).ToString() + " + " +
                     Math.Round(item.Balance * (item.PercentValue / ((item.EndDate - item.StartDate).Days)) *
                     (DateTime.Now - item.StartDate).Days)).ToString() + " odsetki ( ZŁ )", true);

                dockPanelsLoans.Add(x);
                sp.Children.Add(x);
            }

            AppDockPanel.ButtonsDockPanel buttons = new AppDockPanel.ButtonsDockPanel(new int[4] { 0, 40, 0, 0 }, btnBack, btnApply);

            sp.Children.Add(buttons);
            customerRepaymentLoan.Children.Add(sp);

            btnApply.Click += DeleteLoan;
            btnBack.Click += DeleteWindow;

            void DeleteLoan(object o, EventArgs ev) => RepaymentLoanAction(dockPanelsLoans, customer);
            void DeleteWindow(object o, EventArgs ev) => Close();
        }

        public void RepaymentLoanAction(List<UICustomerDockPanel> loans, Customer customer)
        {
            bool isDeleted = false;

            for (int i = 0; i < loans.Count; i++)
            {
                var checkbox = loans[i].Children[0] as CheckBox;
                var totalAmount = loans[i].Children[1] as Label;

                var startAmount = totalAmount.ToString().Substring(0, totalAmount.ToString().IndexOf("+")).Trim();

                using (var context = new SystemObsługiBankuDBEntities())
                {
                    if (checkbox.IsChecked == true)
                    {
                        var customerLoan = context.Loan.First(x => x.CustomerID == customer.ID);
                        context.Loan.Remove(customerLoan);
                        isDeleted = true;

                        context.SaveChanges();
                        ShowInfoMessage
                        (
                            $"Pożyczka została spłacona.",
                            MessageBoxImage.Information
                        );
                    }
                }
            }

            if (!isDeleted) ShowInfoMessage($"Nie wybrano żadnej pożyczki do spłaty.", MessageBoxImage.Information);
            else Close();
        }

        public void ShowInfoMessage(string msg, MessageBoxImage icon = MessageBoxImage.Error)
        {
            MessageBox.Show(msg, "Informacja", MessageBoxButton.OK, icon);
        }
    }
}
