using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SimpleUI.Colours
{
    class Colours
    {
        public static event PropertyChangedEventHandler? StaticPropertyChanged;

        public static void NotifyStaticPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        private static Brush _ControlDarkBackground = new SolidColorBrush(Color.FromRgb(44, 45, 46));
        public static Brush ControlDarkBackground
        {
            get { return _ControlDarkBackground; }
            set
            {
                _ControlDarkBackground = value;
                NotifyStaticPropertyChanged();
            }
        }

        private static Brush _ControlBackground = new SolidColorBrush(Color.FromRgb(60, 63, 65));
        public static Brush ControlBackground
        { 
            get { return _ControlBackground; }
            set { 
                _ControlBackground = value;
                NotifyStaticPropertyChanged();
            }
        }

        private static Brush _ControlHoverBackground = new SolidColorBrush(Color.FromRgb(95, 66, 66));
        public static Brush ControlHoverBackground
        {
            get { return _ControlHoverBackground; }
            set
            {
                _ControlHoverBackground = value;
                NotifyStaticPropertyChanged();
            }
        }

        private static Brush _Text = new SolidColorBrush(Color.FromRgb(220, 220, 220));
        public static Brush Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
                NotifyStaticPropertyChanged();
            }
        }

        private static Brush _DisabledText = new SolidColorBrush(Color.FromRgb(153, 153, 153));
        public static Brush DisabledText
        {
            get { return _DisabledText; }
            set
            {
                _DisabledText = value;
                NotifyStaticPropertyChanged();
            }
        }
    }
}
