using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTL.Connection
{
    public class ServerConnectionLayer
    {
        public const int port = 20200;              //Main Port for Clients.
        public const int port_Service = 20201;      //Service port, configure server settings via this port. 
        public const string adress = "127.0.0.1";   //Main IpAdress.
    }
}
