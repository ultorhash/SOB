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
        private void DeleteCustomerPanel(object sender, EventArgs e)
        {
            AppOtherControls.PeselTextBox[] numberInput = new AppOtherControls.PeselTextBox[11];
            for (int i = 0; i < numberInput.Length; i++) numberInput[i] = new AppOtherControls.PeselTextBox();

            StackPanel sp = new StackPanel
            {
                Width = 400,
                Background = Brushes.DeepSkyBlue,
                Margin = new Thickness(0, -120, 0, -120),
            };

            AppButton.ActionButton btnCancel = new AppButton.ActionButton("Anuluj");
            AppButton.ActionButton btnConfirm = new AppButton.ActionButton("Zatwierdź");

            Label lblTitle = new Label
            {
                Content = "Podaj numer PESEL klienta do usunięcia",
                Background = Brushes.DodgerBlue,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
            };

            Label lblWarning = new Label
            {
                Content = "UWAGA, brak możliwości cofnięcia operacji!",
                Background = Brushes.PaleVioletRed,
                Foreground = Brushes.Maroon,
                FontWeight = FontWeights.Bold,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
            };

            DockPanel dpMain = new DockPanel
            {
                Height = 200,
                Background = Brushes.LightGray,
            };

            DockPanel dpNumbers = new DockPanel
            { 
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            foreach (var item in numberInput)
            {
                dpNumbers.Children.Add(item);
            }

            AppDockPanel.ButtonsDockPanel dpButtons = new AppDockPanel.ButtonsDockPanel(new int[4] { 0, 15, 0, 0 }, btnCancel, btnConfirm);

            btnCancel.Click += DeletePanel;
            btnConfirm.Click += DeleteCustomer;

            mainWindow.Children.Add(sp);
            dpMain.Children.Add(dpNumbers);
            sp.Children.Add(lblTitle);
            sp.Children.Add(lblWarning);
            sp.Children.Add(dpMain);
            sp.Children.Add(dpButtons);

            Grid.SetColumn(sp, 2);
            Grid.SetRow(sp, 3);

            void DeletePanel(object o, EventArgs ev) => mainWindow.Children.RemoveAt(mainWindow.Children.Count - 1);
            void DeleteCustomer(object o, EventArgs ev)
            {
                bool isSuccess = true;
                string customerNumber = null;
                var numbers = ControlFinder.FindVisualChildren<TextBox>(mainWindow.Children[mainWindow.Children.Count - 1]);

                foreach (var item in numbers)
                {
                    customerNumber += item.Text;
                }

                using (var context = new SystemObsługiBankuDBEntities())
                {
                    try
                    {
                        var accounts = context.Account.Where(x => x.CustomerID == customerNumber).ToList();
                        if (accounts.Count != 0)
                        {
                            foreach (var item in accounts)
                            {
                                context.Account.Remove(item);
                            }
                        }

                        var loans = context.Loan.Where(x => x.CustomerID == customerNumber).ToList();
                        if (accounts.Count != 0)
                        {
                            foreach (var item in loans)
                            {
                                context.Loan.Remove(item);
                            }
                        }

                        context.Customer.Remove(context.Customer.Single(x => x.ID == customerNumber));
                        context.SaveChanges();
                    }
                    catch (InvalidOperationException) { isSuccess = false; }                   
                }

                MessageBoxResult confirm = MessageBox.Show
                (
                    isSuccess == true ? "Operacja zakończona pomyślnie.":
                    "Operacja zakończona niepowodzeniem. \nBrak klienta o danym numerze PESEL.",
                    "Wynik operacji",
                    MessageBoxButton.OK,
                    isSuccess == true ? MessageBoxImage.Information : MessageBoxImage.Error
                );

                if (isSuccess) mainWindow.Children.RemoveAt(mainWindow.Children.Count - 1);
            }
        }
    }
}
