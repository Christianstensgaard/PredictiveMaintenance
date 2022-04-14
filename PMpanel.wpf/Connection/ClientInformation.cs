using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMpanel.wpf.Connection
{
    internal class ClientInformation
    {
        public string adress { get; set; }
        public int port { get; set; }

        public ClientInformation(string adress, int port)
        {
            this.adress = adress;
            this.port = port;
        }






    }
}
