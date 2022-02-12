using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SimpleUI.Controls
{
    public class WindowButton : DependencyObject
    {
        public static readonly DependencyProperty ImagePathProperty
            = DependencyProperty.RegisterAttached(
              "ImagePath",
              typeof(string),
              typeof(WindowButton),
              new FrameworkPropertyMetadata(defaultValue: string.Empty, propertyChangedCallback: OnImagePathChanged)
        );

        private static void OnImagePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(ImagePathProperty, e.NewValue);
        }

        public static string GetImagePath(UIElement element)
        {
            return (string)element.GetValue(ImagePathProperty);
        }

        public static void SetImagePath(UIElement element, string value)
        {
            element.SetValue(ImagePathProperty, value);
        }
    }
}
