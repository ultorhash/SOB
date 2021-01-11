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

        public void DeleteCustomer(object sender, EventArgs e) // Do przerobienia na panel
        {
            string numbers = "";

            Window deleteCustomerWindow = new Window()
            {
                Title = "Usuwanie klienta",
                Width = 400,
                Height = 240,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Background = Brushes.MidnightBlue,
                ResizeMode = ResizeMode.NoResize,
            };

            StackPanel sp = new StackPanel();
            DockPanel dpNumbers = new DockPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            DockPanel dpButtons = new DockPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Label lblOperationInfo = new Label
            {
                FontSize = 10,
                Background = Brushes.MidnightBlue,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Label lblCustomerDelete = new Label
            {
                Content = "Podaj numer PESEL klienta",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10),
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
            };

            UIButton btnExit = new UIButton("Zamknij");
            UIButton btnConfirm = new UIButton("Zatwierdź");

            dpButtons.Children.Add(btnExit);
            dpButtons.Children.Add(btnConfirm);

            sp.Children.Add(lblCustomerDelete);
            sp.Children.Add(dpNumbers);
            sp.Children.Add(dpButtons);
            sp.Children.Add(lblOperationInfo);

            for (int i = 11; i > 0; i--)
            {
                TextBox tb = new TextBox
                {
                    MaxLength = 1,
                    Width = 20,
                    Height = 40,
                    FontSize = 16,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(2),
                };

                tb.GotFocus += ChangeColorNumber;
                tb.LostFocus += ChangeColorNumber;
                dpNumbers.Children.Add(tb);
            }

            btnExit.Click += ExitWindow;
            btnConfirm.Click += DeleteCustomerAction;

            void ChangeColorNumber(object o, EventArgs ev)
            {
                TextBox tb = (TextBox)o;
                tb.Background = tb.IsFocused ? tb.Background = Brushes.LightSkyBlue : tb.Background = Brushes.White;
                if (tb.Text.Length != 0)
                {
                    tb.IsEnabled = false;
                }
            }

            void ExitWindow(object o, EventArgs ev) => deleteCustomerWindow.Close();
            void DeleteCustomerAction(object o, EventArgs ev)
            {
                foreach (TextBox tb in ControlFinder.FindVisualChildren<TextBox>(deleteCustomerWindow))
                {
                    numbers += tb.Text;
                    tb.Text = "";
                    tb.IsEnabled = true;
                }

                if (numbers.Length != 11)
                {
                    lblOperationInfo.Foreground = Brushes.Red;
                    lblOperationInfo.Content = "Brak klienta o danym peselu";
                }
                else
                {
                    using (var context = new SystemObsługiBankuDBEntities())
                    {
                        Customer customer = null;
                        try
                        {
                            customer = context.Customer.Where(x => x.ID == numbers).First();
                            context.Customer.Remove(customer);
                            lblOperationInfo.Foreground = Brushes.Lime;
                            lblOperationInfo.Content = "Opracja zakończona pomyślnie";
                            context.SaveChanges();
                        }
                        catch (InvalidOperationException)
                        {
                            lblOperationInfo.Foreground = Brushes.Red;
                            lblOperationInfo.Content = "Brak klienta o danym peselu";
                        }
                    }
                }

                numbers = "";
            }

            deleteCustomerWindow.Content = sp;
            deleteCustomerWindow.Show();
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
