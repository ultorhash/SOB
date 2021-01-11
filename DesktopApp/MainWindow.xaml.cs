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

            UIButton btnExit = new UIButton("Wyjście");
            UIButton btnLogin = new UIButton("Zaloguj");

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
            UILabel lblDateTime = new UILabel();
            UILabel lblEmployee = new UILabel
            {
                Content = $"Zalogowany: {employee.FirstName} {employee.LastName}",
            };

            UILabel lblSessionTime = new UILabel
            {
                Content = "Timer",
            };

            OperationButton btnCustomerService = new OperationButton("Obsługa klienta");
            OperationButton btnCustomerAdd = new OperationButton("Dodawanie klienta");
            OperationButton btnCustomerDelete = new OperationButton("Usuwanie klienta");
            OperationButton btnBranchInfo = new OperationButton("Informacje o oddziale");
            OperationButton btnEmployeeInfo = new OperationButton("Twoje dane");
            OperationButton btnEmployeeSettings = new OperationButton("Ustawienia");

            UIButton btnLogout = new UIButton("Wyloguj");

            mainWindow.Children.Add(lblDateTime);
            mainWindow.Children.Add(lblEmployee);
            mainWindow.Children.Add(lblSessionTime);
            mainWindow.Children.Add(btnCustomerService);
            mainWindow.Children.Add(btnCustomerAdd);
            mainWindow.Children.Add(btnCustomerDelete);
            mainWindow.Children.Add(btnBranchInfo);
            mainWindow.Children.Add(btnEmployeeInfo);
            mainWindow.Children.Add(btnEmployeeSettings);
            mainWindow.Children.Add(btnLogout);

            Grid.SetColumn(lblEmployee, 0);
            Grid.SetRow(lblEmployee, 0);

            Grid.SetColumn(lblEmployee, 2);
            Grid.SetRow(lblEmployee, 0);

            Grid.SetColumn(lblSessionTime, 4);
            Grid.SetRow(lblSessionTime, 0);

            Grid.SetColumn(btnCustomerService, 0);
            Grid.SetRow(btnCustomerService, 1);

            Grid.SetColumn(btnCustomerAdd, 0);
            Grid.SetRow(btnCustomerAdd, 2);

            Grid.SetColumn(btnCustomerDelete, 0);
            Grid.SetRow(btnCustomerDelete, 3);

            Grid.SetColumn(btnBranchInfo, 0);
            Grid.SetRow(btnBranchInfo, 4);

            Grid.SetColumn(btnEmployeeInfo, 0);
            Grid.SetRow(btnEmployeeInfo, 5);

            Grid.SetColumn(btnEmployeeSettings, 0);
            Grid.SetRow(btnEmployeeSettings, 6);

            Grid.SetColumn(btnLogout, 4);
            Grid.SetRow(btnLogout, 6);

            btnCustomerDelete.Click += DeleteCustomer;
            btnLogout.Click += Logout;
            btnCustomerAdd.Click += AddCustomer;

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Ticker;
            dt.Start();

            void Ticker(object sender, EventArgs e)
            {
                lblDateTime.Content = "Dzień: " + DateTime.Now.ToString("dd/MM/yyyy") +
                                      "\nGodzina: " + DateTime.Now.ToString("HH:mm");
            }
        }

        public void AddCustomer(object sender, EventArgs e)
        {
            StackPanel sp = new StackPanel
            {
                Width = 400,
                Background = Brushes.DeepSkyBlue,
                Margin = new Thickness(0, -120, 0, -120),
            };

            UIAddCustomerDockPanel dpCustomerID = new UIAddCustomerDockPanel("Numer PESEL", 11);
            UIAddCustomerDockPanel dpCustomerFN = new UIAddCustomerDockPanel("Imię", 30);
            UIAddCustomerDockPanel dpCustomerLN = new UIAddCustomerDockPanel("Nazwisko", 30);
            UIAddCustomerDockPanel dpCustomerBD = new UIAddCustomerDockPanel("Data urodzenia", new DatePicker());
            UIAddCustomerDockPanel dpCustomerGender = new UIAddCustomerDockPanel("Płeć ( M / K )", 1);
            UIAddCustomerDockPanel dpCustomerAdress = new UIAddCustomerDockPanel("Ulica", 50);
            UIAddCustomerDockPanel dpCustomerCity = new UIAddCustomerDockPanel("Miasto", 30);
            DockPanel dpButtons = new DockPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            UIButton btnCancel = new UIButton("Anuluj");
            UIButton btnConfirm = new UIButton("Zatwierdź");

            btnCancel.Click += CloseCustomerAdd;
            btnConfirm.Click += ConfirmCustomerAdd;

            dpButtons.Children.Add(btnCancel);
            dpButtons.Children.Add(btnConfirm);

            mainWindow.Children.Add(sp);
            sp.Children.Add(dpCustomerID);
            sp.Children.Add(dpCustomerFN);
            sp.Children.Add(dpCustomerLN);
            sp.Children.Add(dpCustomerBD);
            sp.Children.Add(dpCustomerGender);
            sp.Children.Add(dpCustomerAdress);
            sp.Children.Add(dpCustomerCity);
            sp.Children.Add(dpButtons);

            Grid.SetColumn(sp, 2);
            Grid.SetRow(sp, 3);

            void CloseCustomerAdd(object o, EventArgs ev) => mainWindow.Children.RemoveAt(mainWindow.Children.Count - 1);
            void ConfirmCustomerAdd(object o, EventArgs ev)
            {
                int element = 1;
                AddCustomer
                (
                    (DatePicker)dpCustomerBD.Children[element],
                    (TextBox)dpCustomerID.Children[element],
                    (TextBox)dpCustomerFN.Children[element],
                    (TextBox)dpCustomerLN.Children[element],
                    (TextBox)dpCustomerGender.Children[element],
                    (TextBox)dpCustomerAdress.Children[element],
                    (TextBox)dpCustomerCity.Children[element]
                );

                mainWindow.Children.RemoveAt(mainWindow.Children.Count - 1);
            }
        }

        public void AddCustomer(DatePicker bd, params TextBox[] tbxs)
        {
            bool isFieldEmpty = false;

            foreach (var item in tbxs)
            {
                if (item.Text == "")
                {
                    MessageBoxResult confirm = MessageBox.Show
                    (
                        "Wprowadzono niekompletne dane!",
                        "Informacja",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );

                    isFieldEmpty = true;
                    break;
                }            
            }

            if (!isFieldEmpty)
            {
                string birthDate = bd.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
                string id = tbxs[0].Text;
                string firstName = tbxs[1].Text;
                string lastName = tbxs[2].Text;
                string gender = tbxs[3].Text;
                string adress = tbxs[4].Text;
                string city = tbxs[5].Text;

                using (var context = new SystemObsługiBankuDBEntities())
                {
                    context.Customer.Add(new Customer
                    {
                        ID = id,
                        FirstName = firstName,
                        LastName = lastName,
                        BirthDate = Convert.ToDateTime(birthDate),
                        Gender = gender,
                        Adress = adress,
                        City = city,
                    });

                    context.SaveChanges();
                }
            }         
        }

        public void DeleteCustomer(object sender, EventArgs e)
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
