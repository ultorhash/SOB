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
                if (i == 0)
                {
                    Children.Add(actionDP);
                    actionDP.Children.Add(new Label
                    {
                        Content = labels[i],
                        Width = 60,
                        Height = 40,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        Foreground = Brushes.Maroon,
                        Background = Brushes.PaleVioletRed,
                        FontWeight = FontWeights.Bold,
                        Padding = new Thickness(30, 0, 0, 0),
                    });

                    actionDP.Children.Add(new Label
                    {
                        Content = "⚠",
                        Width = 40,
                        Height = 40,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        Background = Brushes.PaleVioletRed,
                        Foreground = Brushes.Maroon,
                        Padding = new Thickness(0, 0, -20, 0),
                        ToolTip = "Zaznacz tą opcję, aby potwierdzić wykonanie operacji",
                    });
                }
                else
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
    }
}
