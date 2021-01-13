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
    /// Logika interakcji dla klasy EmployeeBranchWindow.xaml
    /// </summary>
    public partial class EmployeeBranchWindow : Window
    {
        public EmployeeBranchWindow(Employee loggedEmployee)
        {
            InitializeComponent();
            LoadEmployeeBranchWindow(loggedEmployee);
        }

        public void LoadEmployeeBranchWindow(Employee loggedEmployee)
        {
            Employee employee = null;
            Branch branch = null;

            StackPanel sp = new StackPanel
            {
                Height = 320,
            };

            using (var context = new SystemObsługiBankuDBEntities())
            {
                employee = context.Employee
                    .Single(x => x.AuthorizationCode == loggedEmployee.AuthorizationCode);
                branch = context.Branch
                    .Single(x => x.ID == employee.BranchID);
            }

            UIButton btnBack = new UIButton("Powrót");

            sp.Children.Add(new UIEmployeeDockPanel("Nazwa oddziału", branch.BranchName.Trim()));
            sp.Children.Add(new UIEmployeeDockPanel("Adres", branch.Adress.Trim()));
            sp.Children.Add(new UIEmployeeDockPanel("Miasto", branch.City.Trim()));
            sp.Children.Add(new UIEmployeeDockPanel("Kod pocztowy", branch.PostalCode.Trim()));
            sp.Children.Add(new UIButtonsDockPanel(btnBack));

            employeeBranchWindow.Children.Add(sp);

            btnBack.Click += DeleteWindow;

            void DeleteWindow(object o, EventArgs ev) => Close();
        }
    }
}
