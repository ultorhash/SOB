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
    /// Logika interakcji dla klasy CustomerNewAccount.xaml
    /// </summary>
    public partial class CustomerNewAccount : Window
    {
        public CustomerNewAccount(Customer customer, Employee loggedEmployee)
        {
            InitializeComponent();
            LoadNewAccountWindow(customer, loggedEmployee);
        }

        public void LoadNewAccountWindow(Customer customer, Employee loggedEmployee)
        {
            StackPanel sp = new StackPanel
            {
                Height = 320,
            };

            UIButton btnBack = new UIButton("Powrót");
            UIButton btnApply = new UIButton("Zatwierdź");

            UICustomerDockPanel accountName = new UICustomerDockPanel("Nazwa konta", 30);
            UICustomerDockPanel accountMoney = new UICustomerDockPanel("Kwota ( ZŁ )", 7);
            UICustomerDockPanel accountOpenDate = new UICustomerDockPanel("Od dnia", new DatePicker());
            UICustomerDockPanel accountCloseDate = new UICustomerDockPanel("Do dnia", new DatePicker());

            UIButtonsDockPanel buttons = new UIButtonsDockPanel(btnBack, btnApply) { Margin = new Thickness(0, 15, 0, 0) };

            sp.Children.Add(accountName);
            sp.Children.Add(accountMoney);
            sp.Children.Add(accountOpenDate);
            sp.Children.Add(accountCloseDate);
            sp.Children.Add(buttons);
            customerNewAccount.Children.Add(sp);

            btnApply.Click += ConfirmNewAccount;
            btnBack.Click += DeleteWindow;

            void ConfirmNewAccount(object o, EventArgs ev)
            {
                int element = 1;
                CreateNewAccount
                (
                    customer,
                    loggedEmployee,
                    (TextBox)accountName.Children[element],
                    (TextBox)accountMoney.Children[element],
                    (DatePicker)accountOpenDate.Children[element],
                    (DatePicker)accountCloseDate.Children[element]
                );
            }

            void DeleteWindow(object o, EventArgs ev) => Close();
        }

        public void CreateNewAccount(Customer customer, Employee loggedEmployee, TextBox accountName, TextBox accountMoney, params DatePicker[] dates)
        {
            DateTime date1 = dates[0].SelectedDate.Value.Date;
            DateTime date2 = dates[1].SelectedDate.Value.Date;
            int result = DateTime.Compare(date1, date2);

            if (accountName.Text == "" ||
                accountMoney.Text == "" ||
                dates[0].SelectedDate == null ||
                dates[1].SelectedDate == null)
            {
                ShowError("Wprowadzono niekompletne dane!");
            }
            else if (result >= 0) ShowError("Podana data zakończenia jest dniem przeszłym!");
            else if (date1 >= DateTime.Now) ShowError("Data założenia nie może być większa od dzisiejszego dnia!");
            else
            {
                bool isValidMoney = true;
                decimal balance = 0;

                try { balance = Convert.ToDecimal(accountMoney.Text); }
                catch (FormatException)
                {
                    MessageBox.Show
                    (
                        "Wprowadzona wartość pieniężna jest nieprawidłowa!",
                        "Informacja",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );

                    isValidMoney = false;
                }

                string name = accountName.Text;
                string openDate = dates[0].SelectedDate.Value.Date.ToString("yyyy/MM/dd");
                string closeDate = dates[1].SelectedDate.Value.Date.ToString("yyyy/MM/dd");

                if (isValidMoney)
                {
                    using (var context = new SystemObsługiBankuDBEntities())
                    {
                        context.Account.Add(new Account
                        {
                            Balance = balance,
                            AccountName = name,
                            OpenDate = Convert.ToDateTime(openDate),
                            CloseDate = Convert.ToDateTime(closeDate),
                            CustomerID = customer.ID,
                            BranchID = loggedEmployee.BranchID,
                        });

                        context.SaveChanges();
                        MessageBox.Show
                        (
                            "Konto zostało dodane pomyślnie.",
                            "Informacja",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information
                        );
                    }
                }
            }
            Close();
        }

        public void ShowError(string msg)
        {
            MessageBox.Show
            (
                msg,
                "Informacja",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }
}
