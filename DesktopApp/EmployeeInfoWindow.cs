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
        public void EmployeeInfoWindow(object sender, EventArgs e)
        {
            Employee employee = null;
            Window employeeInfoWindow = new Window
            {
                Title = "Informacje o pracowniku",
                Width = 400,
                Height = 320,
                Background = Brushes.DeepSkyBlue,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize,
            };

            using (var context = new SystemObsługiBankuDBEntities())
            {
                employee = context.Employee
                    .Single(x => x.AuthorizationCode == loggedEmployee.AuthorizationCode);
            }

            StackPanel sp = new StackPanel
            {
                Height = 320,
            };

            UIButton btnBack = new UIButton("Powrót");

            sp.Children.Add(new UIEmployeeInfoDockPanel("Imię", employee.FirstName));
            sp.Children.Add(new UIEmployeeInfoDockPanel("Nazwisko", employee.LastName));
            sp.Children.Add(new UIEmployeeInfoDockPanel("Twój identyfikator", employee.AuthorizationCode));
            sp.Children.Add(new UIEmployeeInfoDockPanel("Data zatrudnienia", employee.HireDate.ToString("dd/MM/yyyy")));
            sp.Children.Add(new UIEmployeeInfoDockPanel("Numer oddziału", employee.BranchID.ToString()));
            sp.Children.Add(new UIButtonsDockPanel(btnBack));

            btnBack.Click += DeleteInfoWindow;

            employeeInfoWindow.Content = sp;
            employeeInfoWindow.Show();

            void DeleteInfoWindow(object o, EventArgs ev) => employeeInfoWindow.Close();
        }
    }
}
