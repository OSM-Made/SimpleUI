using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUI.Colours
{
    class StaticObservableObject
    {
        public static event PropertyChangedEventHandler? StaticPropertyChanged;

        public static void NotifyStaticPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}
