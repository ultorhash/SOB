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
        private Employee loggedEmployee = null;
        public MainWindow()
        {
            InitializeComponent();
            EmployeeLoginPanel();
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
                loggedEmployee = null;
                DeleteMenuPanel();
                EmployeeLoginPanel();
            }
        }

        public void DeleteMenuPanel()
        {
            for (int i = mainWindow.Children.Count - 1; i >= 0; i--) mainWindow.Children.RemoveAt(i);
        }
    }
}
