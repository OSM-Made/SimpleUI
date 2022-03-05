using SimpleUI.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SimpleUI.Skins;

namespace Simple_UI_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SimpleWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DoSlider(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = (Slider)sender;
            TestProgress.ProgressPercentage = (int)slider.Value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = SimpleMessageBox.ShowInformation(this, "Would you like to change the theme?", "SimpleUI Example: Theme Popup", SimpleUI.SimpleDialogButton.YesNo);

            if(result == SimpleUI.SimpleDialogResult.Yes)
            {
                if (SkinResourceDictionary.CurrentTheme == SkinResourceDictionary.Themes.Red)
                {
                    SkinResourceDictionary.ChangeTheme(SkinResourceDictionary.Themes.Blue);
                }
                else
                {
                    SkinResourceDictionary.ChangeTheme(SkinResourceDictionary.Themes.Red);
                }
            }
        }

        private void SimpleSwitch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!ThemeSwitch.IsToggled)
            {
                SkinResourceDictionary.ChangeTheme(SkinResourceDictionary.Themes.Blue);
            }
            else
            {
                SkinResourceDictionary.ChangeTheme(SkinResourceDictionary.Themes.Red);
            }
        }
    }
}
