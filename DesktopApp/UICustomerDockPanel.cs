using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public class UICustomerDockPanel : DockPanel
    {
        public UICustomerDockPanel(string lblContent, int inputLength = 0)
        {
            Children.Add(new Label
            {
                Content = lblContent,
                Padding = new Thickness(10),
                Background = Brushes.DodgerBlue,
                FontSize = 12,
                Width = 100,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            });

            Children.Add(new TextBox
            {
                MaxLength = inputLength,
                Padding = new Thickness(2),
                Background = Brushes.LightGray,
                FontSize = 16,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontWeight = FontWeights.Bold,
            });
        }

        public UICustomerDockPanel(string lblContent, DatePicker dp, int inputLength = 0) :
            this(lblContent, inputLength)
        {
            Children.RemoveAt(Children.Count - 1);
            Children.Add(new DatePicker
            {
                Background = Brushes.LightGray,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            });
        }

        public UICustomerDockPanel(string[] labels)
        {
            Width = 600;
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;

            DockPanel actionDP = new DockPanel
            {
                Width = 100,
                Height = 40,
            };

            for (int i = 0; i < 6; i++)
            {
                {
                    Children.Add(new Label
                    {
                        Content = labels[i],
                        Width = 100,
                        Height = 40,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        Background = Brushes.DodgerBlue,
                        Padding = new Thickness(10, 0, 10, 0),
                    });
                } 
            }
        }

        public UICustomerDockPanel(string accountName, decimal actualMoney)
        {
            Width = 600;
            Background = Brushes.LightGray;

            Children.Add(new CheckBox
            {
                Width = 100,
                Height = 40,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(40, 0, -40, 0),
            });

            Children.Add(new RadioButton
            {
                Width = 100,
                Height = 40,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(40, 0, -40, 0),
            });

            Children.Add(new RadioButton
            {
                Width = 100,
                Height = 40,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(40, 0, -40, 0),
            });

            Children.Add(new Label
            {
                Content = accountName,
                Width = 100,
                Height = 40,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            });

            Children.Add(new Label
            {
                Content = Math.Round(actualMoney, 2).ToString(),
                Width = 100,
                Height = 40,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            });

            Children.Add(new TextBox
            {
                Width = 100,
                Height = 40,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                MaxLength = 7,
                FontSize = 14,
                FontWeight = FontWeights.Bold,
            });
        }

        public UICustomerDockPanel(string name, bool check)
        {
            Background = Brushes.PaleVioletRed;

            Children.Add(new CheckBox
            {
                Width = 40,
                Height = 40,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(20, 0, -10, 0),
                IsChecked = check,
            });

            Children.Add(new Label
            {
                Content = name,
                Padding = new Thickness(10),
                Background = Brushes.DodgerBlue,
                FontSize = 12,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            });
        }

        public UICustomerDockPanel(string lblContent, Slider slider)
        {
            Children.Add(new Label
            {
                Content = lblContent,
                Padding = new Thickness(10),
                Background = Brushes.DodgerBlue,
                FontSize = 12,
                Width = 100,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            });

            slider.Width = 200;
            slider.ValueChanged += ChangeValue;
            slider.HorizontalAlignment = HorizontalAlignment.Center;
            slider.VerticalAlignment = VerticalAlignment.Center;
            slider.Margin = new Thickness(10, 0, 10, 0);
            slider.Cursor = Cursors.Hand;

            Children.Add(slider);

            Children.Add(new Label
            {
                Content = slider.Value.ToString(),
                Padding = new Thickness(10),
                Background = Brushes.DodgerBlue,
                FontSize = 12,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            });
        }

        public UICustomerDockPanel(decimal ammount, byte percent, DateTime startDate, DateTime endDate)
        {
            string[] values = new string[6]
            {
                $"{Math.Round(ammount, 2)}",
                $"{percent}%",
                $"{startDate.ToShortDateString()}",
                $"{endDate.ToShortDateString()}",
                $"{Math.Round(ammount + (ammount * (percent / ((endDate - startDate).Days)) * (DateTime.Now - startDate).Days), 2)}",
                (endDate - DateTime.Now).Days > 0 ? $"{(endDate - DateTime.Now).Days + 1}" : "Zaległość!",
            };

            for (int i = 0; i < 6; i++)
            {
                Children.Add(new Label
                {
                    Content = values[i],
                    Padding = new Thickness(10),
                    Background = Brushes.LightGray,
                    FontSize = 12,
                    Width = 100,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                });     
            }
        }

        public void ChangeValue(object o, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)o;
            Label lblValue = this.Children[2] as Label;
            lblValue.Content = Math.Round(slider.Value, 0);
        }
    }
}
