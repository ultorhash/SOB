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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DesktopApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadLoginPanel();
        }

        public void LoadLoginPanel()
        {
            StackPanel spLoginBox = new StackPanel { VerticalAlignment = VerticalAlignment.Center };
            StackPanel spInfoBox = new StackPanel { VerticalAlignment = VerticalAlignment.Center };
            DockPanel dpLoginBox = new DockPanel { HorizontalAlignment = HorizontalAlignment.Center };

            Label lblTitleApp = new Label
            {
                Content = "System Obsługi Banku",
                Background = Brushes.DeepSkyBlue,
                Foreground = Brushes.White,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                FontSize = 24,
            };

            Label lblInfoEmployee = new Label
            {
                Content = "Zaloguj się do systemu używając swojego indentyfikatora",
                Background = Brushes.DeepSkyBlue,
                Foreground = Brushes.White,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
            };

            PasswordBox pbLogin = new PasswordBox
            {
                Password = "3#frTK4!45oRR9",
                PasswordChar = '*',
                FontSize = 18,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Bottom,
                FontWeight = FontWeights.Bold,
                Padding = new Thickness(6),
            };

            UIButton btnExit = new UIButton
            {
                Content = "Wyjście",
                Margin = new Thickness(20, 20, 10, 20),
            };

            UIButton btnLogin = new UIButton
            {
                Content = "Zaloguj",
                Margin = new Thickness(10, 20, 20, 20),
            };

            mainWindow.Children.Add(lblTitleApp);
            mainWindow.Children.Add(spLoginBox);
            mainWindow.Children.Add(spInfoBox);

            Grid.SetColumn(lblTitleApp, 2);
            Grid.SetRow(lblTitleApp, 1);

            Grid.SetColumn(spInfoBox, 2);
            Grid.SetRow(spInfoBox, 3);

            Grid.SetColumn(spLoginBox, 2);
            Grid.SetRow(spLoginBox, 4);

            spInfoBox.Children.Add(lblInfoEmployee);
            spInfoBox.Children.Add(pbLogin);

            spLoginBox.Children.Add(dpLoginBox);

            dpLoginBox.Children.Add(btnExit);
            dpLoginBox.Children.Add(btnLogin);

            btnExit.Click += ExitApp;
            btnLogin.Click += LoginApp;
        }

        public void ExitApp(object sender, EventArgs e) => Close();
        public void LoginApp(object sender, EventArgs e)
        {
            StackPanel sp = (StackPanel)mainWindow.Children[2];
            PasswordBox pb = (PasswordBox)sp.Children[1];
            FindEmployee(pb.Password);
        }

        public void FindEmployee(string password)
        {
            List<Employee> employees = new List<Employee>();
            using (var context = new SystemObsługiBankuDBEntities())
            {
                employees = context.Employee
                    .Where(x => x.AuthorizationCode == password)
                    .ToList();
            }

            if (employees.Count != 0)
            {
                DeleteLoginPanel();
                LoadMenuPanel(employees.First());
            }
        }

        public void DeleteLoginPanel()
        {
            for (int i = mainWindow.Children.Count - 1; i >= 0; i--) mainWindow.Children.RemoveAt(i);
        }

        public void LoadMenuPanel(Employee employee)
        {
            Label lblEmployee = new Label
            {
                Content = $"Zalogowany: {employee.FirstName} {employee.LastName}",
                Background = Brushes.DeepSkyBlue,
                Foreground = Brushes.White,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                FontSize = 12,
            };

            Label lblSessionTime = new Label
            {
                Content = "Timer",
                Background = Brushes.DeepSkyBlue,
                Foreground = Brushes.White,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                FontSize = 12,
            };

            OperationButton btnCustomerService = new OperationButton("Obsługa klienta");
            OperationButton btnCustomerDelete = new OperationButton("Usuwanie klienta");
            OperationButton btnBranchInfo = new OperationButton("Informacje o oddziale");
            OperationButton btnEmployeeInfo = new OperationButton("Twoje dane");

            UIButton btnLogout = new UIButton
            {
                Content = "Wyloguj",
                Margin = new Thickness(0, 0, 10, 0),
            };

            mainWindow.Children.Add(lblEmployee);
            mainWindow.Children.Add(lblSessionTime);
            mainWindow.Children.Add(btnCustomerService);
            mainWindow.Children.Add(btnCustomerDelete);
            mainWindow.Children.Add(btnBranchInfo);
            mainWindow.Children.Add(btnEmployeeInfo);
            mainWindow.Children.Add(btnLogout);

            Grid.SetColumn(lblEmployee, 2);
            Grid.SetRow(lblEmployee, 0);

            Grid.SetColumn(lblSessionTime, 4);
            Grid.SetRow(lblSessionTime, 0);

            Grid.SetColumn(btnCustomerService, 0);
            Grid.SetRow(btnCustomerService, 1);

            Grid.SetColumn(btnCustomerDelete, 0);
            Grid.SetRow(btnCustomerDelete, 2);

            Grid.SetColumn(btnBranchInfo, 0);
            Grid.SetRow(btnBranchInfo, 3);

            Grid.SetColumn(btnEmployeeInfo, 0);
            Grid.SetRow(btnEmployeeInfo, 4);

            Grid.SetColumn(btnLogout, 4);
            Grid.SetRow(btnLogout, 6);

            btnLogout.Click += Logout;
        }

        public void Logout(object sender, EventArgs e)
        {
            MessageBoxResult confirm = MessageBox.Show
            (
                "Zakoćzyć sesję?",
                "Potwierdzenie",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (confirm == MessageBoxResult.Yes)
            {
                DeleteMenuPanel();
                LoadLoginPanel();
            }
        }

        public void DeleteMenuPanel()
        {
            for (int i = mainWindow.Children.Count - 1; i >= 0; i--) mainWindow.Children.RemoveAt(i);
        }
    }
}
