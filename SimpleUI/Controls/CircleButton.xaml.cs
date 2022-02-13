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

namespace SimpleUI.Controls
{
    /// <summary>
    /// Interaction logic for CircleButton.xaml
    /// </summary>
    public partial class CircleButton : Button
    {
        public CircleButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ImagePathProperty
            = DependencyProperty.Register(
              "ImagePath",
              typeof(string),
              typeof(CircleButton),
              new FrameworkPropertyMetadata(string.Empty)
        );

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }
    }
}
