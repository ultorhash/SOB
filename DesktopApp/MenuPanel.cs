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
        private void LoadMenuPanel(Employee employee)
        {
            loggedEmployee = employee;
            DeleteLoginPanel();

            string day = DateTime.Now.ToString("dddd");
            string month = DateTime.Now.ToString("MMMM");

            AppLabel.DescriptionLabel lblCustomer = new AppLabel.DescriptionLabel("Strefa klienta");
            AppLabel.DescriptionLabel lblTime = new AppLabel.DescriptionLabel("Data: " + DateTime.Now.Day + " " + month + " " + day);
            AppLabel.DescriptionLabel lblLogged = new AppLabel.DescriptionLabel($"Zalogowany: {employee.FirstName} {employee.LastName}");
            AppLabel.DescriptionLabel lblSessionTime = new AppLabel.DescriptionLabel(null);
            AppLabel.DescriptionLabel lblEmployee = new AppLabel.DescriptionLabel("Strefa pracownika");

            AppButton.MenuButton btnCustomerService = new AppButton.MenuButton("Obsługa klienta");
            AppButton.MenuButton btnCustomerAdd = new AppButton.MenuButton("Dodawanie klienta");
            AppButton.MenuButton btnCustomerDelete = new AppButton.MenuButton("Usuwanie klienta");
            AppButton.MenuButton btnBranchInfo = new AppButton.MenuButton("Informacje o oddziale");
            AppButton.MenuButton btnEmployeeInfo = new AppButton.MenuButton("Twoje dane");
            AppButton.MenuButton btnEmployeeSettings = new AppButton.MenuButton("Ustawienia");

            AppButton.ActionButton btnLogout = new AppButton.ActionButton("Wyloguj");

            SetSessionTimer();

            mainWindow.Children.Add(lblCustomer);
            mainWindow.Children.Add(lblSessionTime);
            mainWindow.Children.Add(lblLogged);
            mainWindow.Children.Add(lblTime);
            mainWindow.Children.Add(lblEmployee);
            mainWindow.Children.Add(btnCustomerService);
            mainWindow.Children.Add(btnCustomerAdd);
            mainWindow.Children.Add(btnCustomerDelete);
            mainWindow.Children.Add(btnBranchInfo);
            mainWindow.Children.Add(btnEmployeeInfo);
            mainWindow.Children.Add(btnEmployeeSettings);
            mainWindow.Children.Add(btnLogout);

            Grid.SetColumn(lblCustomer, 0); Grid.SetRow(lblCustomer, 0);
            Grid.SetColumn(lblTime, 1); Grid.SetRow(lblTime, 0);
            Grid.SetColumn(lblLogged, 2); Grid.SetRow(lblLogged, 0);
            Grid.SetColumn(lblSessionTime, 3); Grid.SetRow(lblCustomer, 0);
            Grid.SetColumn(lblEmployee, 4); Grid.SetRow(lblEmployee, 0);
            Grid.SetColumn(btnCustomerService, 0); Grid.SetRow(btnCustomerService, 1);
            Grid.SetColumn(btnCustomerAdd, 0); Grid.SetRow(btnCustomerAdd, 2);
            Grid.SetColumn(btnCustomerDelete, 0); Grid.SetRow(btnCustomerDelete, 3);
            Grid.SetColumn(btnBranchInfo, 4); Grid.SetRow(btnBranchInfo, 1);
            Grid.SetColumn(btnEmployeeInfo, 4); Grid.SetRow(btnEmployeeInfo, 2);
            Grid.SetColumn(btnEmployeeSettings, 4); Grid.SetRow(btnEmployeeSettings, 3);
            Grid.SetColumn(btnLogout, 4); Grid.SetRow(btnLogout, 6);

            btnCustomerService.Click += ServiceCustomerNumberPanel;
            btnCustomerAdd.Click += AddCustomerPanel;
            btnCustomerDelete.Click += DeleteCustomerPanel;
            btnBranchInfo.Click += OpenEmployeeBranchWindow;
            btnEmployeeInfo.Click += OpenEmployeeInfoWindow;
            btnEmployeeSettings.Click += OpenEmployeeSettingsWindow;
            btnLogout.Click += Logout;

            void OpenEmployeeBranchWindow(object sender, EventArgs e)
            {
                EmployeeBranchWindow employeeBranchWindow = new EmployeeBranchWindow(loggedEmployee);
                employeeBranchWindow.Show();
            }

            void OpenEmployeeInfoWindow(object sender, EventArgs e)
            {
                EmployeeInfoWindow employeeInfoWindow = new EmployeeInfoWindow(loggedEmployee);
                employeeInfoWindow.Show();
            }

            void OpenEmployeeSettingsWindow(object sender, EventArgs e)
            {
                EmployeeSettingsWindow employeeSettingsWindow = new EmployeeSettingsWindow();
                employeeSettingsWindow.Show();
            }

            void SetSessionTimer()
            {
                DispatcherTimer clock = new DispatcherTimer();

                clock.Interval = new TimeSpan(0, 0, 1);
                clock.Tick += TimerTick;
                clock.Start();
            }

            void TimerTick(object sender, EventArgs e)
            {
                var child = lblSessionTime.Content = new TextBlock()
                {
                    Text = "Godzina: " + DateTime.Now.ToLongTimeString().ToString(),
                    FontSize = 15,
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                };
            }
        }
    }
}
