using PMpanel.wpf.CoreFunctiond;
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
    /// Interaction logic for HmoduleDashBoard.xaml
    /// </summary>
    public partial class HmoduleDashBoard : UserControl
    {
        public HmoduleDashBoard(List<HmoduleModel> hmoduleModels)
        {
            InitializeComponent();
            hmodules = hmoduleModels;
        }

        private List<HmoduleModel> hmodules;


        /// <summary>
        /// Loading the Hmodules to the screen
        /// </summary>
        private void Load()
        {
            foreach (HmoduleModel item in hmodules)
            {




            }

            /*Printer alle hmulerne som er linket til et givet system-linje, f.eks. produktions linje*/

        }

        //TODO Der skal laves en funktion som kan printe det i lag. denne klasse skal også kunne genbruges. til det andet dashboard.



    }
}
