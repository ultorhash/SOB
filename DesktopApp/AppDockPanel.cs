using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    /// <summary>
    /// Reprezentuje zbiór układów komponentów
    /// </summary>
    public static class AppDockPanel
    {
        public class DescriptionDockPanel : DockPanel
        {
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
    }
}
