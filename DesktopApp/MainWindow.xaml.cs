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
            LoadLoginPanel();
        }

        public void LoadLoginPanel()
        {
            StackPanel appLoginBoxSP = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
            };

            StackPanel appInfoBoxSP = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
            };

            DockPanel appLoginBoxDP = new DockPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Label appTitleLabel = new Label
            {
                Content = "System Obsługi Banku",
                Background = Brushes.DeepSkyBlue,
                Foreground = Brushes.White,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                FontSize = 24,
            };

            Label appInfoLabel = new Label
            {
                Content = "Zaloguj się do systemu używając swojego indentyfikatora",
                Background = Brushes.DeepSkyBlue,
                Foreground = Brushes.White,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
            };

            PasswordBox appLoginPB = new PasswordBox
            {
                PasswordChar = '*',
                FontSize = 18,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Padding = new Thickness(6),
            };

            Button appExitBtn = new Button
            {
                Content = "Wyjście",
                Cursor = Cursors.Hand,
                Background = Brushes.Gray,
                Foreground = Brushes.White,
                Height = 40,
                Width = 100,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(20, 20, 10, 20),
            };

            Button appLoginBtn = new Button
            {
                Content = "Zaloguj",
                Cursor = Cursors.Hand,
                Background = Brushes.Gray,
                Foreground = Brushes.White,
                Height = 40,
                Width = 100,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10, 20, 20, 20),
            };

            mainWindow.Children.Add(appTitleLabel);
            mainWindow.Children.Add(appLoginBoxSP);
            mainWindow.Children.Add(appInfoBoxSP);

            Grid.SetColumn(appTitleLabel, 2);
            Grid.SetRow(appTitleLabel, 1);

            Grid.SetColumn(appInfoBoxSP, 2);
            Grid.SetRow(appInfoBoxSP, 3);

            Grid.SetColumn(appLoginBoxSP, 2);
            Grid.SetRow(appLoginBoxSP, 4);

            appInfoBoxSP.Children.Add(appInfoLabel);
            appInfoBoxSP.Children.Add(appLoginPB);

            appLoginBoxDP.Children.Add(appExitBtn);
            appLoginBoxDP.Children.Add(appLoginBtn);        

            appLoginBoxSP.Children.Add(appLoginBoxDP);

            appExitBtn.Click += ExitApp;
        }

        public void ExitApp(object sender, EventArgs e) => this.Close();
    }
}
