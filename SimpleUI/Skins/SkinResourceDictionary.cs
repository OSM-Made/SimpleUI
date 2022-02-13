using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleUI.Skins
{
    public class SkinResourceDictionary : ResourceDictionary
    {
        public static Uri RedSource => new("pack://application:,,,/SimpleUI;component/Skins/RedTheme.xaml");
        public static Uri BlueSource => new("pack://application:,,,/SimpleUI;component/Skins/BlueTheme.xaml");

        private static SkinResourceDictionary? Instance;

        public enum Themes
        {
            Red,
            Blue,
        };

        private static Dictionary<Themes, Uri> ThemeDic = new Dictionary<Themes, Uri>() { { Themes.Red, RedSource }, { Themes.Blue, BlueSource } };

        public static Themes CurrentTheme { get; private set; }

        public SkinResourceDictionary()
        {
            base.Source = RedSource;
            Instance = this;
        }

        public static void ChangeTheme(Themes theme)
        {
            Instance.Source = ThemeDic[theme];
            CurrentTheme = theme;
        }
    }
}
