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
    /// Interaction logic for SimpleTextBox.xaml
    /// </summary>
    public partial class SimpleTextBox : TextBox
    {
        public SimpleTextBox()
        {
            InitializeComponent();
        }

        public bool DisableHighlight
        {
            get { return (bool)GetValue(DisableHighlightProperty); }
            set { SetValue(DisableHighlightProperty, value); }
        }

        public static readonly DependencyProperty DisableHighlightProperty =
            DependencyProperty.Register("DisableHighlight", typeof(bool), typeof(SimpleTextBox), new PropertyMetadata(false));
    }
}
