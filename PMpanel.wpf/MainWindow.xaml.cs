using PMpanel.wpf.CoreFunk;
using PMpanel.wpf.Views.ViewTemplates;
using PMpanel.wpf.ViewTemplates;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        // Demo Generated Collums
        private void Window_Initialized(object sender, EventArgs e)
        {
            StackPanel.Children.Add(new AlerView("B21", AlerView.State.Go));
            StackPanel.Children.Add(new AlerView("B21", AlerView.State.Go));
            StackPanel.Children.Add(new AlerView("B21", AlerView.State.Go));

        }

        //Used for demo only
        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            

        }


        /*Alle data skal hentes via en forbindelse til serveren. og derefter skal der oprettes de forskellige
         *Moduler, Hvordan det lige skal gøres skal jeg lige tænkte lidt, så det er Work in progress*/
        private void GetData() { }




    }

}
