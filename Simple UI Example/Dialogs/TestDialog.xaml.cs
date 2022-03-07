using SimpleUI.Dialogs;
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
using System.Windows.Shapes;

namespace Simple_UI_Example.Dialogs
{
    /// <summary>
    /// Interaction logic for TestDialog.xaml
    /// </summary>
    public partial class TestDialog : SimpleDialog
    {
        public TestDialog(Window Owner)
            : base(Owner, "Save", "Cancel", "Do Something!")
        {
            InitializeComponent();
        }

        public static SimpleDialogResult ShowDialog(Window Owner)
        {
            var dlg = new TestDialog(Owner);
            dlg.ShowDialog();
            return dlg.Result;
        }
    }
}
