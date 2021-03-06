using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PMpanel.wpf.ViewTemplates
{
    
    public partial class AlerView : UserControl
    {
        public AlerView(string name, State state)
        {
            InitializeComponent();
            ContentLabel.Content = name;
            AlertState(state);
            
        }
        public enum State { Go, Caution, Stop}
        public void AlertState(State state)
        {
            CollapsAll();
            switch (state)
            {
                case State.Go:
                    State_GO.Visibility = Visibility.Visible;
                    break;
                case State.Caution:
                    State_Caution.Visibility = Visibility.Visible;
                    break;
                case State.Stop:
                    State_Stop.Visibility = Visibility.Visible;
                    break;
            }
        }



        private void CollapsAll()
        {
            State_GO.Visibility = Visibility.Collapsed;
            State_Caution.Visibility = Visibility.Collapsed;
            State_Stop.Visibility = Visibility.Collapsed;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}


//TODO Denne klasse skal laves om, så den kan passe til begge dashboard. Det giver en mulighed for at genbruge samme element. *Udseende skal nok også laves om!