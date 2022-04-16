using PMserver.console.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PMserver.console.Server
{
    public class ServerCore
    {
        private TcpListener serverSocket;
        private Thread serverThread;


        public ServerCore()
        {
            //> Getting information and init serversocket.
            serverSocket = new TcpListener(IPAddress.Parse(ServerInformation.adress), ServerInformation.port);
        }





        /// <summary>
        /// Starting Server on a new Thread, and will begin accepting Clients. 
        /// </summary>
        public void Start()
        {
            try
            {
                ServerState.IsRunning = true;
                serverSocket.Start();
                serverThread = new Thread(Server);
                serverThread.Start();
            }
            
            catch (Exception)
            {
                //TODO Error logging ServerCore
                ServerState.IsRunning=false;
                throw;
            }
        }


        /// <summary>
        /// Background Worker Thread. 
        /// </summary>
        private void Server()
        {
            while (ServerState.IsRunning)
            {
                //> Directing new client to ClientCore.







            }
        }



    }
}
