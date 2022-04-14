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

namespace PMpanel.wpf.Views.ViewTemplates
{
    /// <summary>
    /// Interaction logic for HmoduleView.xaml
    /// </summary>
    public partial class HmoduleView : UserControl
    {
        private MainWindow MainWindow;
        public HmoduleView(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            
        }
    }
}
