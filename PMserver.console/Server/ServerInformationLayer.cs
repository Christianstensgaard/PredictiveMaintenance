using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMserver.console.Server
{
    public class ServerInformationLayer
    {
        public string Adress { get; set; }
        public int Port { get; set; }

        public ServerInformationLayer(string adress, int port)
        {
            Adress = adress;
            Port = port;
        }
    }
}
