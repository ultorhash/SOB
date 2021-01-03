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
            EmployeeLoginPanel();
        }

        public void EmployeeLoginPanel()
        {
            Label appNameLabel = new Label
            {
                Content = "Zaloguj się do systemu",
                Background = Brushes.Black,
                Foreground = Brushes.White,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };

            mainWindow.Children.Add(appNameLabel);
            Grid.SetColumn(appNameLabel, 2);
            Grid.SetRow(appNameLabel, 3);
        }
    }
}
