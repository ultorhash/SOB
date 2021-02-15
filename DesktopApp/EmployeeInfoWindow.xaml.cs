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
    /// Logika interakcji dla klasy EmployeeInfoWindow.xaml
    /// </summary>
    public partial class EmployeeInfoWindow : Window
    {
        public EmployeeInfoWindow(Employee loggedEmployee)
        {
            InitializeComponent();
            LoadEmployeeInfoWindow(loggedEmployee);
        }

        public void LoadEmployeeInfoWindow(Employee loggedEmployee)
        {
            Employee employee = null;

            StackPanel sp = new StackPanel
            {
                Height = 320,
            };

            using (var context = new SystemObsługiBankuDBEntities())
            {
                employee = context.Employee
                    .Single(x => x.AuthorizationCode == loggedEmployee.AuthorizationCode);
            }

            AppButton.ActionButton btnBack = new AppButton.ActionButton("Powrót");

            sp.Children.Add(new AppDockPanel.DescriptionDockPanel("Imię", employee.FirstName.Trim()));
            sp.Children.Add(new AppDockPanel.DescriptionDockPanel("Nazwisko", employee.LastName.Trim()));
            sp.Children.Add(new AppDockPanel.DescriptionDockPanel("Twój identyfikator", employee.AuthorizationCode.Trim()));
            sp.Children.Add(new AppDockPanel.DescriptionDockPanel("Data zatrudnienia", employee.HireDate.ToString("dd/MM/yyyy").Trim()));
            sp.Children.Add(new AppDockPanel.ButtonsDockPanel(new int[4] { 0, 15, 0, 0 }, btnBack));

            employeeInfoWindow.Children.Add(sp);

            btnBack.Click += DeleteWindow;

            void DeleteWindow(object o, EventArgs ev) => Close();
        }
    }
}
