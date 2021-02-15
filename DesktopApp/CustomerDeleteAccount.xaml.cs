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
    /// Logika interakcji dla klasy CustomerDeleteAccount.xaml
    /// </summary>
    public partial class CustomerDeleteAccount : Window
    {
        public CustomerDeleteAccount(Customer customer)
        {
            InitializeComponent();
            LoadDeleteAccountWindow(customer);
        }

        public void LoadDeleteAccountWindow(Customer customer)
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

            List<UICustomerDockPanel> dockPanelsAccounts = new List<UICustomerDockPanel>();
            foreach (var item in accounts)
            {
                var x = new UICustomerDockPanel(item.AccountName, true);
                dockPanelsAccounts.Add(x);
                sp.Children.Add(x);
            }

            AppButton.ActionButton btnBack = new AppButton.ActionButton("Powrót");
            AppButton.ActionButton btnApply = new AppButton.ActionButton("Zatwierdź");

            AppDockPanel.ButtonsDockPanel buttons = new AppDockPanel.ButtonsDockPanel(new int[4] { 0, 30, 0, 0 }, btnBack, btnApply);

            sp.Children.Add(buttons);
            customerDeleteAccount.Children.Add(sp);

            btnApply.Click += DeleteCustomerAccount;
            btnBack.Click += DeleteWindow;

            void DeleteCustomerAccount(object o, EventArgs ev) => DeleteAccount(dockPanelsAccounts);
            void DeleteWindow(object o, EventArgs ev) => Close();
        }

        public void DeleteAccount(List<UICustomerDockPanel> accounts)
        {
            bool isDeleted = false;

            for (int i = 0; i < accounts.Count; i++)
            {
                var checkbox = accounts[i].Children[0] as CheckBox;
                var accountName = accounts[i].Children[1] as Label;

                using (var context = new SystemObsługiBankuDBEntities())
                {
                    if (checkbox.IsChecked == true)
                    {
                        var customerAccount = context.Account.Single(x => x.AccountName == accountName.Content.ToString());
                        context.Account.Remove(customerAccount);
                        isDeleted = true;

                        context.SaveChanges();
                        ShowInfoMessage
                        (
                            $"Konto {accountName.Content.ToString().Trim()} zostało usunięte.",
                            MessageBoxImage.Information
                        );
                    }
                }
            }

            if (!isDeleted) ShowInfoMessage($"Nie wybrano żadnego konta.", MessageBoxImage.Information);
            else Close();
        }

        public void ShowInfoMessage(string msg, MessageBoxImage icon = MessageBoxImage.Error)
        {
            MessageBox.Show(msg, "Informacja", MessageBoxButton.OK, icon);
        }
    }
}
