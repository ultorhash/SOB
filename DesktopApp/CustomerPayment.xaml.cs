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
    /// Logika interakcji dla klasy CustomerPayment.xaml
    /// </summary>
    public partial class CustomerPayment : Window
    {
        public CustomerPayment(Customer customer)
        {
            InitializeComponent();
            LoadCustomerPaymentWindow(customer);
        }

        private void LoadCustomerPaymentWindow(Customer customer)
        {
            StackPanel sp = new StackPanel
            {
                Height = 320,
            };

            List<Account> accounts = new List<Account>();
            using (var context = new SystemObsługiBankuDBEntities())
            {
                accounts = context.Account.Where(x => x.CustomerID == customer.ID).ToList();
            }

            AppDockPanel.MultiLabelDockPanel description = new AppDockPanel.MultiLabelDockPanel(
                new string[6] { "Akcja", "Wpłata", "Wypłata", "Nazwa konta", "Aktualny stan", "Kwota ( ZŁ )" });

            AppButton.ActionButton btnBack = new AppButton.ActionButton("Powrót");
            AppButton.ActionButton btnApply = new AppButton.ActionButton("Zatwierdź");
            AppDockPanel.ButtonsDockPanel buttons = new AppDockPanel.ButtonsDockPanel(new int[4] { 0, 10, 0, 0 }, btnBack, btnApply);

            sp.Children.Add(description);

            List<AppDockPanel.AccountInfoDockPanel> dockPanelsAccounts = new List<AppDockPanel.AccountInfoDockPanel>();
            foreach (var item in accounts)
            {
                var x = new AppDockPanel.AccountInfoDockPanel(item.AccountName, item.Balance);
                dockPanelsAccounts.Add(x);
                sp.Children.Add(x);
            }

            sp.Children.Add(buttons);
            customerPayment.Children.Add(sp);

            btnApply.Click += CustomerPaymentTransaction;
            btnBack.Click += DeleteWindow;

            void CustomerPaymentTransaction(object o, EventArgs ev) => ApplyTransaction(dockPanelsAccounts);
            void DeleteWindow(object o, EventArgs ev) => Close();
        }

        private void ApplyTransaction(List<AppDockPanel.AccountInfoDockPanel> accounts)
        {
            decimal money = 0;

            for (int i = 0; i < accounts.Count; i++)
            {
                var checkbox = accounts[i].Children[0] as CheckBox;
                var radioIn = accounts[i].Children[1] as RadioButton;
                var radioOut = accounts[i].Children[2] as RadioButton;

                var accountName = accounts[i].Children[3] as Label;
                var accountMoney = accounts[i].Children[4] as Label;
                var inputMoney = accounts[i].Children[5] as TextBox;

                if (inputMoney.Text.Length == 0)
                {
                    ShowInfoMessage("Niepodano wartości pieniężnej.");
                    break;
                }
                else
                {
                    try { money = decimal.Parse(inputMoney.Text); }
                    catch(InvalidOperationException)
                    {
                        ShowInfoMessage("Podana kwota jest nieprawidłowa.");
                        break;
                    }

                    using (var context = new SystemObsługiBankuDBEntities())
                    {
                        var customerAccount = context.Account.Single(x => x.AccountName == accountName.Content.ToString());
                        if ((Convert.ToInt32(inputMoney.Text) <= money) && radioOut.IsChecked == true && checkbox.IsChecked == true)
                        {
                            customerAccount.Balance -= Convert.ToDecimal(inputMoney.Text);
                            context.SaveChanges();
                            ShowInfoMessage
                            (
                                $"Operacja dla konta {accountName.Content.ToString().Trim()} " +
                                $"zakończona pomyślnie.", MessageBoxImage.Information
                            );
                        }
                        if (radioIn.IsChecked == true && checkbox.IsChecked == true)
                        {
                            customerAccount.Balance += Convert.ToDecimal(inputMoney.Text);
                            context.SaveChanges();
                            ShowInfoMessage
                            (
                                $"Operacja dla konta {accountName.Content.ToString().Trim()} " +
                                $"zakończona pomyślnie.", MessageBoxImage.Information
                            );
                        }
                    }
                }
            }

            Close();
        }

        private void ShowInfoMessage(string msg, MessageBoxImage icon = MessageBoxImage.Error)
        {
            MessageBox.Show(msg, "Informacja", MessageBoxButton.OK, icon);
        }
    }
}
