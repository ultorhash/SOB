using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace DesktopApp
{
    public partial class MainWindow
    {
        public void ServiceCustomerPanel(Customer customer)
        {
            StackPanel sp = new StackPanel
            {
                Width = 400,
                Height = 300,
                Background = Brushes.DeepSkyBlue,
                Margin = new Thickness(0, -120, 0, -120),
            };

            UIButton btnCancel = new UIButton("Powrót");

            Menu menuAccount = new Menu
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.DeepSkyBlue,
                Margin = new Thickness(0, 20, 0, 0),
            };

            Menu menuLoan = new Menu
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.DeepSkyBlue,
                Margin = new Thickness(0, 20, 0, 80),
            };

            MenuItem miAccount = new MenuItem
            {
                Header = "Konto",
                Padding = new Thickness(10),
                Background = Brushes.DodgerBlue, 
                FontWeight = FontWeights.Bold,
            };

            MenuItem miLoan = new MenuItem
            {
                Header = "Pożyczka",
                Padding = new Thickness(10),
                Background = Brushes.DodgerBlue,
                FontWeight = FontWeights.Bold,
            };

            DropDownButton btnCreateAccount = new DropDownButton("Zakładanie konta");
            DropDownButton btnPaymentIn = new DropDownButton("Wpłata");
            DropDownButton btnPaymentOut = new DropDownButton("Wypłata");
            DropDownButton btnDeleteAccount = new DropDownButton("Usuń konto");
            DropDownButton btnNewLoan = new DropDownButton("Nowa pożyczka");
            DropDownButton btnActualLoan = new DropDownButton("Aktualne pożyczki");
            DropDownButton btnRepaymentLoan = new DropDownButton("Spłać pożyczkę");

            miAccount.Items.Add(btnCreateAccount);
            miAccount.Items.Add(btnPaymentIn);
            miAccount.Items.Add(btnPaymentOut);
            miAccount.Items.Add(btnDeleteAccount);

            miLoan.Items.Add(btnNewLoan);
            miLoan.Items.Add(btnActualLoan);
            miLoan.Items.Add(btnRepaymentLoan);

            menuAccount.Items.Add(miAccount);
            menuLoan.Items.Add(miLoan);

            Label lblTitle = new Label
            {
                Content = $"Operacje dla klienta {customer.FirstName} {customer.LastName}",
                Background = Brushes.DodgerBlue,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
            };

            UIButtonsDockPanel dpButton = new UIButtonsDockPanel(btnCancel);

            btnCreateAccount.Click += NewAccountWindow;
            btnCancel.Click += DeletePanel;

            mainWindow.Children.Add(sp);
            sp.Children.Add(lblTitle);
            sp.Children.Add(menuAccount);
            sp.Children.Add(menuLoan);
            sp.Children.Add(dpButton);

            Grid.SetColumn(sp, 2);
            Grid.SetRow(sp, 3);

            void NewAccountWindow(object o, EventArgs ev)
            {
                List<Account> accounts = new List<Account>();
                using (var context = new SystemObsługiBankuDBEntities())
                {
                    accounts = context.Account.Where(x => x.CustomerID == customer.ID).ToList();
                }

                if (accounts.Count < 2)
                {
                    CustomerNewAccount customerNewAccount = new CustomerNewAccount(customer, loggedEmployee);
                    customerNewAccount.Show();
                }
                else
                {
                    MessageBox.Show
                    (
                        $"Użytkownik posiada maksymalną ilość kont ( {accounts.Count} ).",
                        "Informacja",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }
            }

            void DeletePanel(object o, EventArgs ev) => mainWindow.Children.RemoveAt(mainWindow.Children.Count - 1);
        }
    }
}
