using PMpanel.wpf.CoreFunk;
using PMpanel.wpf.Views.ViewTemplates;
using PMpanel.wpf.ViewTemplates;
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

namespace PMpanel.wpf
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ApplicationState.Instance.IsRunning = true;
            InitializeComponent();
        }

        /// <summary>
        /// Called on closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //> This will automatic close all running Threads
            ApplicationState.Instance.IsRunning = false;

            
        }


        private void Window_Initialized(object sender, EventArgs e)
        {
            StackPanel HstackPanel = new StackPanel();
            HstackPanel.Orientation = Orientation.Horizontal;
            HstackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            for (int i = 0; i < 4; i++)
            {
                AlerView view = new AlerView(i.ToString(), AlerView.State.Stop);
                HstackPanel.Children.Add(view);
            }

            StackPanel.Children.Add(HstackPanel);


            StackPanel HstackPanel1 = new StackPanel();
            HstackPanel1.Orientation = Orientation.Horizontal;
            HstackPanel1.HorizontalAlignment = HorizontalAlignment.Center;
            for (int i = 0; i < 4; i++)
            {
                AlerView view = new AlerView(i.ToString(), AlerView.State.Caution);
                HstackPanel1.Children.Add(view);
            }

            StackPanel.Children.Add(HstackPanel1);



            StackPanel HstackPanel2 = new StackPanel();
            HstackPanel2.Orientation = Orientation.Horizontal;
            HstackPanel2.HorizontalAlignment = HorizontalAlignment.Center;
            for (int i = 0; i < 4; i++)
            {
                AlerView view = new AlerView(i.ToString(), AlerView.State.Go);
                HstackPanel2.Children.Add(view);
            }

            StackPanel.Children.Add(HstackPanel2);



        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StackPanel.Children.Clear();
            StackPanel.Children.Add(new HmoduleView(this));

        }


        /*Der må maks være 3-4 pr. række. */






    }

}
