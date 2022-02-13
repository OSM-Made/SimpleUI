using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SimpleUI.Colours
{
    public class Colours : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public static Brush ControlDarkBackground { get; set; } = new SolidColorBrush(Color.FromRgb(44, 45, 46));

        public static Brush ControlBackground { get; set; } = new SolidColorBrush(Color.FromRgb(60, 63, 65));

        public static Brush ControlHoverBackground { get; set; } = new SolidColorBrush(Color.FromRgb(95, 66, 66));

        public static Brush Text { get; set; } = new SolidColorBrush(Color.FromRgb(220, 220, 220));

        public static Brush DisabledText { get; set; } = new SolidColorBrush(Color.FromRgb(153, 153, 153));
    }
}
