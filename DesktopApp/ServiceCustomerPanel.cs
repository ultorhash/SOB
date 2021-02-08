﻿using System;
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

            Expander accountMenu = new Expander
            {
                Header = "Konto klienta",
                Background = Brushes.LightGray,
                Padding = new Thickness(10),
                FontWeight = FontWeights.Bold,
            };

            Expander loanMenu = new Expander
            {
                Header = "Pożyczki klienta",
                Background = Brushes.LightGray,
                Padding = new Thickness(10),
                FontWeight = FontWeights.Bold,
            };

            DropDownButton btnCreateAccount = new DropDownButton("Zakładanie konta");
            DropDownButton btnPayment = new DropDownButton("Wpłata / wypłata");
            DropDownButton btnDeleteAccount = new DropDownButton("Usuń konto");
            DropDownButton btnNewLoan = new DropDownButton("Nowa pożyczka");
            DropDownButton btnActualLoan = new DropDownButton("Aktualne pożyczki");
            DropDownButton btnRepaymentLoan = new DropDownButton("Spłać pożyczkę");

            UIButtonsDockPanel customerAccount = new UIButtonsDockPanel(btnCreateAccount, btnPayment, btnDeleteAccount);
            UIButtonsDockPanel customerLoan = new UIButtonsDockPanel(btnNewLoan, btnActualLoan, btnRepaymentLoan);

            accountMenu.Content = customerAccount;
            loanMenu.Content = customerLoan;

            Label lblTitle = new Label
            {
                Content = $"Operacje dla klienta {customer.FirstName} {customer.LastName}",
                Background = Brushes.DodgerBlue,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
            };

            UIButtonsDockPanel dpButton = new UIButtonsDockPanel(btnCancel);

            btnCreateAccount.Click += NewAccountWindow;
            btnPayment.Click += PaymentWindow;
            btnDeleteAccount.Click += DeleteAccountWindow;

            btnNewLoan.Click += NewLoanWindow;
            btnActualLoan.Click += ActualLoanWindow;
            btnRepaymentLoan.Click += RepaymentLoanWindow;

            btnCancel.Click += DeletePanel;

            mainWindow.Children.Add(sp);
            sp.Children.Add(lblTitle);
            sp.Children.Add(accountMenu);
            sp.Children.Add(loanMenu);
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
                        $"Klient posiada maksymalną ilość kont ( {accounts.Count} ).",
                        "Informacja",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                }
            }

            void PaymentWindow(object o, EventArgs ev)
            {
                List<Account> accounts = new List<Account>();
                using (var context = new SystemObsługiBankuDBEntities())
                {
                    accounts = context.Account.Where(x => x.CustomerID == customer.ID).ToList();
                }

                if (accounts.Count > 0)
                {
                    CustomerPayment customerPayment = new CustomerPayment(customer);
                    customerPayment.Show();
                }
                else
                {
                    MessageBox.Show
                    (
                        $"Klient nie posiada jeszcze konta.",
                        "Informacja",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                }
            }

            void DeleteAccountWindow(object o, EventArgs ev)
            {
                List<Account> accounts = new List<Account>();
                using (var context = new SystemObsługiBankuDBEntities())
                {
                    accounts = context.Account.Where(x => x.CustomerID == customer.ID).ToList();
                }

                if (accounts.Count > 0)
                {
                    CustomerDeleteAccount customerDeleteWindow = new CustomerDeleteAccount(customer);
                    customerDeleteWindow.Show();
                }
                else
                {
                    MessageBox.Show
                    (
                        $"Klient nie posiada kont do usunięcia.",
                        "Informacja",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                }
            }

            void NewLoanWindow(object o, EventArgs ev)
            {
                List<Loan> loans = new List<Loan>();
                using (var context = new SystemObsługiBankuDBEntities())
                {
                    loans = context.Loan.Where(x => x.CustomerID == customer.ID).ToList();
                }

                if (loans.Count < 2)
                {
                    CustomerNewLoan customerNewLoan = new CustomerNewLoan(customer);
                    customerNewLoan.Show();
                }
                else
                {                
                    MessageBox.Show
                    (
                        $"Klient posiada maksymalną ilość pożyczek ( {loans.Count} ).",
                        "Informacja",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                }
            }

            void ActualLoanWindow(object o, EventArgs ev)
            {
                List<Loan> loans = new List<Loan>();
                using (var context = new SystemObsługiBankuDBEntities())
                {
                    loans = context.Loan.Where(x => x.CustomerID == customer.ID).ToList();
                }

                if (loans.Count > 0)
                {
                    CustomerLoans customerLoans = new CustomerLoans(customer);
                    customerLoans.Show();
                }
                else
                {
                    MessageBox.Show
                    (
                        $"Klient nie posiada aktualnie pożyczek.",
                        "Informacja",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                }
            }

            void RepaymentLoanWindow(object o, EventArgs e)
            {
                List<Loan> loans = new List<Loan>();
                using (var context = new SystemObsługiBankuDBEntities())
                {
                    loans = context.Loan.Where(x => x.CustomerID == customer.ID).ToList();
                }

                if (loans.Count > 0)
                {
                    CustomerRepaymentLoan customerRepaymentLoan = new CustomerRepaymentLoan(customer);
                    customerRepaymentLoan.Show();
                }
                else
                {
                    MessageBox.Show
                    (
                        $"Klient nie posiada aktualnie pożyczek do spłacenia.",
                        "Informacja",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                }
            }

            void DeletePanel(object o, EventArgs ev) => mainWindow.Children.RemoveAt(mainWindow.Children.Count - 1);
        }
    }
}
