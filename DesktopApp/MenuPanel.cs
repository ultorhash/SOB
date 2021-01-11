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
        public void LoadMenuPanel(Employee employee)
        {
            UILabel lblDateTime = new UILabel();
            UILabel lblEmployee = new UILabel
            {
                Content = $"Zalogowany: {employee.FirstName} {employee.LastName}",
            };

            UILabel lblSessionTime = new UILabel
            {
                Content = "Timer",
            };

            OperationButton btnCustomerService = new OperationButton("Obsługa klienta");
            OperationButton btnCustomerAdd = new OperationButton("Dodawanie klienta");
            OperationButton btnCustomerDelete = new OperationButton("Usuwanie klienta");
            OperationButton btnBranchInfo = new OperationButton("Informacje o oddziale");
            OperationButton btnEmployeeInfo = new OperationButton("Twoje dane");
            OperationButton btnEmployeeSettings = new OperationButton("Ustawienia");

            UIButton btnLogout = new UIButton("Wyloguj");

            mainWindow.Children.Add(lblDateTime);
            mainWindow.Children.Add(lblEmployee);
            mainWindow.Children.Add(lblSessionTime);
            mainWindow.Children.Add(btnCustomerService);
            mainWindow.Children.Add(btnCustomerAdd);
            mainWindow.Children.Add(btnCustomerDelete);
            mainWindow.Children.Add(btnBranchInfo);
            mainWindow.Children.Add(btnEmployeeInfo);
            mainWindow.Children.Add(btnEmployeeSettings);
            mainWindow.Children.Add(btnLogout);

            Grid.SetColumn(lblEmployee, 0);
            Grid.SetRow(lblEmployee, 0);

            Grid.SetColumn(lblEmployee, 2);
            Grid.SetRow(lblEmployee, 0);

            Grid.SetColumn(lblSessionTime, 4);
            Grid.SetRow(lblSessionTime, 0);

            Grid.SetColumn(btnCustomerService, 0);
            Grid.SetRow(btnCustomerService, 1);

            Grid.SetColumn(btnCustomerAdd, 0);
            Grid.SetRow(btnCustomerAdd, 2);

            Grid.SetColumn(btnCustomerDelete, 0);
            Grid.SetRow(btnCustomerDelete, 3);

            Grid.SetColumn(btnBranchInfo, 4);
            Grid.SetRow(btnBranchInfo, 1);

            Grid.SetColumn(btnEmployeeInfo, 4);
            Grid.SetRow(btnEmployeeInfo, 2);

            Grid.SetColumn(btnEmployeeSettings, 4);
            Grid.SetRow(btnEmployeeSettings, 3);

            Grid.SetColumn(btnLogout, 4);
            Grid.SetRow(btnLogout, 6);

            btnCustomerDelete.Click += DeleteCustomer;
            btnLogout.Click += Logout;
            btnCustomerAdd.Click += AddCustomerPanel;
            btnEmployeeInfo.Click += EmployeeInfoWindow;

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Ticker;
            dt.Start();

            void Ticker(object sender, EventArgs e)
            {
                lblDateTime.Content = "Dzień: " + DateTime.Now.ToString("dd/MM/yyyy") +
                                      "\nGodzina: " + DateTime.Now.ToString("HH:mm");
            }
        }
    }
}
