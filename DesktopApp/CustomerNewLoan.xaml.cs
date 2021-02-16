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
    /// Logika interakcji dla klasy CustomerNewLoan.xaml
    /// </summary>
    public partial class CustomerNewLoan : Window
    {
        public CustomerNewLoan(Customer customer)
        {
            InitializeComponent();
            LoadNewLoanWindow(customer);
        }

        private void LoadNewLoanWindow(Customer customer)
        {
            StackPanel sp = new StackPanel
            {
                Height = 320,
            };

            AppButton.ActionButton btnBack = new AppButton.ActionButton("Powrót");
            AppButton.ActionButton btnApply = new AppButton.ActionButton("Zatwierdź");

            AppDockPanel.SliderDockPanel loanBalance = new AppDockPanel.SliderDockPanel("Kwota ( ZŁ )", new Slider { Maximum = 50_000, Minimum = 3000 });
            AppDockPanel.SliderDockPanel loanPercent = new AppDockPanel.SliderDockPanel("Procent", new Slider { Maximum = 100, Minimum = 0 });
            AppDockPanel.InputDateDockPanel loanStartDate = new AppDockPanel.InputDateDockPanel("Od dnia");
            AppDockPanel.InputDateDockPanel loanEndDate = new AppDockPanel.InputDateDockPanel("Do dnia");

            AppDockPanel.ButtonsDockPanel buttons = new AppDockPanel.ButtonsDockPanel(new int[4] { 0, 10, 0, 0 }, btnBack, btnApply);

            sp.Children.Add(loanBalance);
            sp.Children.Add(loanPercent);
            sp.Children.Add(loanStartDate);
            sp.Children.Add(loanEndDate);
            sp.Children.Add(buttons);
            customerNewLoan.Children.Add(sp);

            btnApply.Click += NewLoan;
            btnBack.Click += DeleteWindow;

            void NewLoan(object o, EventArgs ev) => AddNewLoan(
                (Slider)loanBalance.Children[1],
                (Slider)loanPercent.Children[1],
                (DatePicker)loanStartDate.Children[1],
                (DatePicker)loanEndDate.Children[1],
                customer);

            void DeleteWindow(object o, EventArgs ev) => Close();
        }

        private void AddNewLoan(Slider balance, Slider percent, DatePicker startDate, DatePicker endDate, Customer customer)
        {
            bool isValidDate = true;
            DateTime date1 = default;
            DateTime date2 = default;

            try
            {
                date1 = startDate.SelectedDate.Value.Date;
                date2 = endDate.SelectedDate.Value.Date;
            }
            catch (InvalidOperationException) { isValidDate = false; }
            int resultDate = DateTime.Compare(date1, date2);

            if (isValidDate == false) ShowMessage("Wprowadzono niekompletne dane!", MessageBoxImage.Error);
            else if (resultDate >= 0) ShowMessage("Podana data zakończenia jest dniem przeszłym!", MessageBoxImage.Error);
            else if (date1 >= DateTime.Now) ShowMessage("Data założenia nie może być większa od dzisiejszego dnia!", MessageBoxImage.Error);
            else
            {
                string openDate = startDate.SelectedDate.Value.Date.ToString("yyyy/MM/dd");
                string closeDate = endDate.SelectedDate.Value.Date.ToString("yyyy/MM/dd");

                using (var context = new SystemObsługiBankuDBEntities())
                {
                    context.Loan.Add(new Loan
                    {
                        Balance = (decimal)Math.Round(balance.Value, 2),
                        PercentValue = (byte)percent.Value,
                        StartDate = Convert.ToDateTime(openDate),
                        EndDate = Convert.ToDateTime(closeDate),
                        CustomerID = customer.ID,
                    });

                    context.SaveChanges();
                    ShowMessage("Pożyczka została udzielona pomyślnie.", MessageBoxImage.Information);
                }

                Close();
            }
        }

        private void ShowMessage(string msg, MessageBoxImage img)
        {
            MessageBox.Show(msg, "Informacja", MessageBoxButton.OK, img);
        }
    }
}
