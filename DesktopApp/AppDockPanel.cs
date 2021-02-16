using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    /// <summary>
    /// Statyczna klasa reprezentująca zbiór komponentów służących do opisu lub pobierania informacji
    /// </summary>
    public static class AppDockPanel
    {
        public class DescriptionDockPanel : DockPanel
        {
            /// <summary>
            /// Klasa reprezentująca układ opisujący daną informację
            /// </summary>
            /// <param name="name">Opis wiersza</param>
            /// <param name="desc">Wartość wiersza</param>
            public DescriptionDockPanel(string name, string desc)
            {
                Children.Add(new Label
                {
                    Content = name,
                    Padding = new Thickness(10),
                    Background = Brushes.DodgerBlue,
                    FontSize = 12,
                    Width = 150,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                });

                Children.Add(new Label
                {
                    Content = desc,
                    Background = Brushes.LightGray,
                    Padding = new Thickness(10),
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                });
            }
        }

        public class ColorsDockPanel : DockPanel
        {
            /// <summary>
            /// Klasa reprezentująca wybór kolorów na liście poziomej
            /// </summary>
            /// <param name="name">Opis wiersza</param>
            /// <param name="btns">Lista przycisków z wyborem koloru</param>
            public ColorsDockPanel(string name, params Button[] btns)
            {
                Background = Brushes.LightGray;

                DockPanel dp = new DockPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                foreach (var item in btns) dp.Children.Add(item);

                Children.Add(new Label
                {
                    Content = name,
                    Padding = new Thickness(10),
                    Background = Brushes.DodgerBlue,
                    FontSize = 12,
                    Width = 150,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                });

                Children.Add(dp);
            }
        }

        public class ButtonsDockPanel : DockPanel
        {
            /// <summary>
            /// Klasa reprezentująca rozstawienie przycisków do interakcji z użytkownikiem
            /// </summary>
            /// <param name="margins">Marginesy dla każdego przycisku</param>
            /// <param name="buttons">Liczba przycisków na liście</param>
            public ButtonsDockPanel(int[] margins, params Button[] buttons)
            {
                VerticalAlignment = VerticalAlignment.Center;
                HorizontalAlignment = HorizontalAlignment.Center;
                margins = margins ?? new int[4] { 0, 0, 0, 0 };

                foreach (var item in buttons)
                {
                    item.Margin = new Thickness(margins[0], margins[1], margins[2], margins[3]);
                    Children.Add(item);
                }
            }
        }

        public class InfoInputDockPanel : DockPanel
        {
            /// <summary>
            /// Klasa reprezentująca wiersz do pobierania informacji od użytkownika
            /// </summary>
            /// <param name="lblContent">Opis wiersza</param>
            /// <param name="inputLength">Maksymalna długość jaką można wprowadzić do pola</param>
            public InfoInputDockPanel(string lblContent, int inputLength = 0)
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
        }

        public class InputDateDockPanel : DockPanel
        {
            /// <summary>
            /// Klasa reprezentująca wiersz do pobierania daty od użytkownika
            /// </summary>
            /// <param name="lblContent">Opis wiersza</param>
            public InputDateDockPanel(string lblContent)
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

                Children.Add(new DatePicker
                {
                    Background = Brushes.LightGray,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                });
            }
        }

        public class MultiLabelDockPanel : DockPanel
        {
            /// <summary>
            /// Klasa reprezentująca zbiór opisów poszczególnych informacji
            /// </summary>
            /// <param name="labels">Opisy kolumn reprezentujących informacje</param>
            public MultiLabelDockPanel(string[] labels)
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
        }

        public class AccountInfoDockPanel : DockPanel
        {
            /// <summary>
            /// Klasa reprezentująca wiersz opisujący konta klientów
            /// </summary>
            /// <param name="accountName">Nazwa konta klienta</param>
            /// <param name="actualMoney">Ilość pieniędzy na danym koncie</param>
            public AccountInfoDockPanel(string accountName, decimal actualMoney)
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

        public class ActionDockPanel : DockPanel
        {
            /// <summary>
            /// Klasa reprezentująca kontrolki służące do zatwierdzania operacji
            /// </summary>
            /// <param name="name">Opis wiersza</param>
            /// <param name="check">Zaznaczenie pola</param>
            public ActionDockPanel(string name, bool check)
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
        }

        public class SliderDockPanel : DockPanel
        {
            /// <summary>
            /// Klasa reprezentująca wiersz wraz z suwakiem służącym do określania wartości
            /// </summary>
            /// <param name="lblContent">Opis wiersza</param>
            /// <param name="slider">suwak służący do interakcji z użytkownikiem</param>
            public SliderDockPanel(string lblContent, Slider slider)
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
            void ChangeValue(object o, RoutedPropertyChangedEventArgs<double> e)
            {
                Slider slider = (Slider)o;
                Label lblValue = this.Children[2] as Label;
                lblValue.Content = Math.Round(slider.Value, 0);
            }
        }

        public class LoanInfoDockPanel : DockPanel
        {
            /// <summary>
            /// Klasa reprezentująca wierz wraz z informacjami o stanie pożyczki klienta
            /// </summary>
            /// <param name="ammount">Pożyczona kwota</param>
            /// <param name="percent">Oprocentowanie pożyczki</param>
            /// <param name="startDate">Data pożyczenia</param>
            /// <param name="endDate">Data oddania</param>
            public LoanInfoDockPanel(decimal ammount, byte percent, DateTime startDate, DateTime endDate)
            {
                string[] values = new string[6]
                {
                $"{Math.Round(ammount, 2)}",
                $"{percent}%",
                $"{startDate.ToShortDateString()}",
                $"{endDate.ToShortDateString()}",
                $"{Math.Round(ammount + (ammount /100 * (percent / ((endDate - startDate).Days)) * (DateTime.Now - startDate).Days), 2)}",
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
        }
    }
}
