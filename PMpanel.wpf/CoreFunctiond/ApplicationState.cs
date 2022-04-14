using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMpanel.wpf.CoreFunk
{
    public class ApplicationState
    {
        private static readonly ApplicationState instance = new ApplicationState();

        static ApplicationState() { }
        private ApplicationState() { }

        public static ApplicationState Instance
        {
            get { return instance; }
        }


        public bool IsRunning { get; set; }




    }
}
