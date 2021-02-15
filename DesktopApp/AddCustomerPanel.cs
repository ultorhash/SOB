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
        public void AddCustomerPanel(object sender, EventArgs e)
        {
            StackPanel sp = new StackPanel
            {
                Width = 400,
                Background = Brushes.DeepSkyBlue,
                Margin = new Thickness(0, -120, 0, -120),
            };

            AppButton.ActionButton btnCancel = new AppButton.ActionButton("Anuluj");
            AppButton.ActionButton btnConfirm = new AppButton.ActionButton("Zatwierdź");

            UICustomerDockPanel dpCustomerID = new UICustomerDockPanel("Numer PESEL", 11);
            UICustomerDockPanel dpCustomerFN = new UICustomerDockPanel("Imię", 30);
            UICustomerDockPanel dpCustomerLN = new UICustomerDockPanel("Nazwisko", 30);
            UICustomerDockPanel dpCustomerBD = new UICustomerDockPanel("Data urodzenia", new DatePicker());
            UICustomerDockPanel dpCustomerGender = new UICustomerDockPanel("Płeć ( M / K )", 1);
            UICustomerDockPanel dpCustomerAdress = new UICustomerDockPanel("Ulica", 50);
            UICustomerDockPanel dpCustomerCity = new UICustomerDockPanel("Miasto", 30);
            AppDockPanel.ButtonsDockPanel buttons = new AppDockPanel.ButtonsDockPanel(new int[4] { 0, 15, 0, 0 }, btnCancel, btnConfirm);

            btnCancel.Click += DeletePanel;
            btnConfirm.Click += ConfirmCustomerAdd;

            mainWindow.Children.Add(sp);
            sp.Children.Add(dpCustomerID);
            sp.Children.Add(dpCustomerFN);
            sp.Children.Add(dpCustomerLN);
            sp.Children.Add(dpCustomerBD);
            sp.Children.Add(dpCustomerGender);
            sp.Children.Add(dpCustomerAdress);
            sp.Children.Add(dpCustomerCity);
            sp.Children.Add(buttons);

            Grid.SetColumn(sp, 2);
            Grid.SetRow(sp, 3);

            void DeletePanel(object o, EventArgs ev) => mainWindow.Children.RemoveAt(mainWindow.Children.Count - 1);
            void ConfirmCustomerAdd(object o, EventArgs ev)
            {
                int element = 1;
                AddCustomer
                (
                    (DatePicker)dpCustomerBD.Children[element],
                    (TextBox)dpCustomerID.Children[element],
                    (TextBox)dpCustomerFN.Children[element],
                    (TextBox)dpCustomerLN.Children[element],
                    (TextBox)dpCustomerGender.Children[element],
                    (TextBox)dpCustomerAdress.Children[element],
                    (TextBox)dpCustomerCity.Children[element]
                );

                mainWindow.Children.RemoveAt(mainWindow.Children.Count - 1);
            }
        }

        public void AddCustomer(DatePicker bd, params TextBox[] tbxs)
        {
            bool isFieldEmpty = false;

            foreach (var item in tbxs)
            {
                if (item.Text == "")
                {
                    ShowError();

                    isFieldEmpty = true;
                    break;
                }
            }

            if (!isFieldEmpty)
            {
                string birthDate = bd.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
                string id = tbxs[0].Text;
                string firstName = tbxs[1].Text;
                string lastName = tbxs[2].Text;
                string gender = tbxs[3].Text;
                string adress = tbxs[4].Text;
                string city = tbxs[5].Text;

                using (var context = new SystemObsługiBankuDBEntities())
                {
                    context.Customer.Add(new Customer
                    {
                        ID = id,
                        FirstName = firstName,
                        LastName = lastName,
                        BirthDate = Convert.ToDateTime(birthDate),
                        Gender = gender,
                        Adress = adress,
                        City = city,
                    });

                    context.SaveChanges();
                }

                MessageBoxResult confirm = MessageBox.Show
                (
                    "Operacja zakończona pomyślnie.",
                    "Wynik operacji",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            }
        }

        public void ShowError()
        {
            MessageBox.Show
            (
                "Wprowadzono niekompletne dane!",
                "Informacja",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }
}
