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
    /// Interaction logic for SimpleTextField.xaml
    /// </summary>
    public partial class SimpleTextField : UserControl
    {
        public SimpleTextField()
        {
            InitializeComponent();
        }

        public string FieldName
        {
            get { return (string)GetValue(FieldNameProperty); }
            set { SetValue(FieldNameProperty, value); }
        }

        public static readonly DependencyProperty FieldNameProperty =
            DependencyProperty.Register("FieldName", typeof(string), typeof(SimpleTextField), new PropertyMetadata(string.Empty));

        public string FieldText
        {
            get { return (string)GetValue(FieldTextProperty); }
            set { SetValue(FieldTextProperty, value); }
        }

        public static readonly DependencyProperty FieldTextProperty =
            DependencyProperty.Register("FieldText", typeof(string), typeof(SimpleTextField), new PropertyMetadata(string.Empty));
    }
}
