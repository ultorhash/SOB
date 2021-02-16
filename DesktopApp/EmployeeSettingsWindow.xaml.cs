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

        private void LoadEmployeeSettingsWindow()
        {
            StackPanel sp = new StackPanel
            {
                Height = 320,
            };

            AppButton.ActionButton btnBack = new AppButton.ActionButton("Powrót");

            AppButton.ThemeButton btnTheme1 = new AppButton.ThemeButton(Brushes.Black);
            AppButton.ThemeButton btnTheme2 = new AppButton.ThemeButton(Brushes.DarkGray);
            AppButton.ThemeButton btnTheme3 = new AppButton.ThemeButton(Brushes.DimGray);
            AppButton.ThemeButton btnTheme4 = new AppButton.ThemeButton(Brushes.SlateGray);
            AppButton.ThemeButton btnTheme5 = new AppButton.ThemeButton(Brushes.DarkSlateGray);

            btnTheme1.Click += ChangeTheme;
            btnTheme2.Click += ChangeTheme;
            btnTheme3.Click += ChangeTheme;
            btnTheme4.Click += ChangeTheme;
            btnTheme5.Click += ChangeTheme;
            btnBack.Click += DeleteWindow;

            sp.Children.Add(new AppDockPanel.ColorsDockPanel("Motyw", btnTheme1, btnTheme2, btnTheme3, btnTheme4, btnTheme5));
            sp.Children.Add(new AppDockPanel.ButtonsDockPanel(new int[4] { 0, 15, 0, 0 }, btnBack));

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
