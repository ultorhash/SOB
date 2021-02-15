using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public partial class MainWindow
    {
        public void EmployeeLoginPanel()
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

            Label lblLoginError = new Label
            {
                Content = "",
                FontWeight = FontWeights.Bold,
                Background = Brushes.SteelBlue,
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

            AppButton.ActionButton btnExit = new AppButton.ActionButton("Wyjście");
            AppButton.ActionButton btnLogin = new AppButton.ActionButton("Zaloguj");

            mainWindow.Children.Add(lblTitleApp);
            mainWindow.Children.Add(spLoginBox);
            mainWindow.Children.Add(spInfoBox);
            mainWindow.Children.Add(lblLoginError);

            Grid.SetColumn(lblTitleApp, 2); Grid.SetRow(lblTitleApp, 1);
            Grid.SetColumn(spInfoBox, 2); Grid.SetRow(spInfoBox, 3);
            Grid.SetColumn(spLoginBox, 2); Grid.SetRow(spLoginBox, 4);
            Grid.SetColumn(lblLoginError, 2); Grid.SetRow(lblLoginError, 5);

            spInfoBox.Children.Add(lblInfoEmployee);
            spInfoBox.Children.Add(pbLogin);

            spLoginBox.Children.Add(dpLoginBox);

            dpLoginBox.Children.Add(btnExit);
            dpLoginBox.Children.Add(btnLogin);

            btnExit.Click += ExitApp;
            btnLogin.Click += LoginApp;
        }

        public void ExitApp(object sender, EventArgs e) => Close();
        public async void LoginApp(object sender, EventArgs e)
        {
            StackPanel sp = (StackPanel)mainWindow.Children[2];
            PasswordBox pb = (PasswordBox)sp.Children[1];
            Label lbl = (Label)mainWindow.Children[3];

            loggedEmployee = await FindEmployee(pb.Password, lbl);

            if (loggedEmployee != null) LoadMenuPanel(loggedEmployee);
            else
            {
                lbl.Foreground = Brushes.DarkRed;
                lbl.Content = "Nieprawidłowy identyfikator! Spróbuj ponownie.";
            }
        }

        public async Task<Employee> FindEmployee(string password, Label label)
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = null;

            label.Foreground = Brushes.White;
            label.Content = "Logowanie...";

            using (var context = new SystemObsługiBankuDBEntities())
            {
                return await Task.Run(() => employee = context.Employee.SingleOrDefault(x => x.AuthorizationCode == password));
            }
        }

        public void DeleteLoginPanel()
        {
            for (int i = mainWindow.Children.Count - 1; i >= 0; i--) mainWindow.Children.RemoveAt(i);
        }
    }
}
