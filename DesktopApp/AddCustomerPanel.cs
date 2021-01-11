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
        public void AddCustomerPanel(object sender, EventArgs e)
        {
            StackPanel sp = new StackPanel
            {
                Width = 400,
                Background = Brushes.DeepSkyBlue,
                Margin = new Thickness(0, -120, 0, -120),
            };

            UIButton btnCancel = new UIButton("Anuluj");
            UIButton btnConfirm = new UIButton("Zatwierdź");

            UIAddCustomerDockPanel dpCustomerID = new UIAddCustomerDockPanel("Numer PESEL", 11);
            UIAddCustomerDockPanel dpCustomerFN = new UIAddCustomerDockPanel("Imię", 30);
            UIAddCustomerDockPanel dpCustomerLN = new UIAddCustomerDockPanel("Nazwisko", 30);
            UIAddCustomerDockPanel dpCustomerBD = new UIAddCustomerDockPanel("Data urodzenia", new DatePicker());
            UIAddCustomerDockPanel dpCustomerGender = new UIAddCustomerDockPanel("Płeć ( M / K )", 1);
            UIAddCustomerDockPanel dpCustomerAdress = new UIAddCustomerDockPanel("Ulica", 50);
            UIAddCustomerDockPanel dpCustomerCity = new UIAddCustomerDockPanel("Miasto", 30);
            UIButtonsDockPanel dpButtons = new UIButtonsDockPanel(btnCancel, btnConfirm);

            btnCancel.Click += DeleteCustomerAdd;
            btnConfirm.Click += ConfirmCustomerAdd;

            mainWindow.Children.Add(sp);
            sp.Children.Add(dpCustomerID);
            sp.Children.Add(dpCustomerFN);
            sp.Children.Add(dpCustomerLN);
            sp.Children.Add(dpCustomerBD);
            sp.Children.Add(dpCustomerGender);
            sp.Children.Add(dpCustomerAdress);
            sp.Children.Add(dpCustomerCity);
            sp.Children.Add(dpButtons);

            Grid.SetColumn(sp, 2);
            Grid.SetRow(sp, 3);

            void DeleteCustomerAdd(object o, EventArgs ev) => mainWindow.Children.RemoveAt(mainWindow.Children.Count - 1);
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
                    MessageBoxResult confirm = MessageBox.Show
                    (
                        "Wprowadzono niekompletne dane!",
                        "Informacja",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );

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
            }
        }
    }
}
