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
    /// Logika interakcji dla klasy EmployeeSettingsWindow.xaml
    /// </summary>
    public partial class EmployeeSettingsWindow : Window
    {
        public EmployeeSettingsWindow()
        {
            InitializeComponent();
            LoadEmployeeSettingsWindow();
        }

        public void LoadEmployeeSettingsWindow()
        {
            StackPanel sp = new StackPanel
            {
                Height = 320,
            };

            UIButton btnBack = new UIButton("Powrót");

            Button btnTheme1 = new Button
            {
                Width = 30, Height = 30,
                Margin = new Thickness(5),
                Background = Brushes.DarkGray,
                Cursor = Cursors.Cross
            };

            Button btnTheme2 = new Button
            {
                Width = 30, Height = 30,
                Margin = new Thickness(5),
                Background = Brushes.DimGray, Cursor = Cursors.Cross
            
            };

            Button btnTheme3 = new Button
            {
                Width = 30, Height = 30,
                Margin = new Thickness(5),
                Background = Brushes.SteelBlue,
                Cursor = Cursors.Cross
            };

            Button btnTheme4 = new Button
            {
                Width = 30,
                Height = 30,
                Margin = new Thickness(5),
                Background = Brushes.LemonChiffon,
                Cursor = Cursors.Cross
            };

            btnTheme1.Click += ChangeTheme;
            btnTheme2.Click += ChangeTheme;
            btnTheme3.Click += ChangeTheme;
            btnTheme4.Click += ChangeTheme;
            btnBack.Click += DeleteWindow;

            sp.Children.Add(new UIEmployeeDockPanel("Motyw", btnTheme1, btnTheme2, btnTheme3, btnTheme4));
            sp.Children.Add(new UIButtonsDockPanel(btnBack));

            employeeSettingsWindow.Children.Add(sp);

            void ChangeTheme(object sender, EventArgs e)
            {
                Button btn = (Button)sender;

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).Background = btn.Background;
                    }
                }
            }

            void DeleteWindow(object sender, EventArgs e) => Close();
        }
    }
}
