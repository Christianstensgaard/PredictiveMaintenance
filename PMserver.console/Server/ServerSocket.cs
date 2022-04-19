using DTL.Connection;
using PMserver.console.Client;
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
    internal class ServerSocket
    {
        public TcpListener serverSocket { get; }
        public Thread serverThred { get; }

        public ServerSocket()
        {
            //Setup -> Tcp 
            serverSocket = new TcpListener(IPAddress.Parse(ServerConnectionLayer.adress), ServerConnectionLayer.port);
            serverThred = new Thread(Worker);   //Init the ServerThread.
        }


        public bool Start()
        {
            if (ServerState.IsRunning)
            {
                Print.Print.Yellow("Server is Running");
                return false;
            }
            try
            {
                ServerState.IsRunning = true;   //Setting the ServerState - used to stop all thread if false.
                serverSocket.Start();           //Starting Tcp server socket.
                serverThred.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Stop()
        {
            Print.Print.Red("Stopping server");
            ServerState.IsRunning = false;
            serverSocket.Stop();
        }


        private void Worker()
        {

            while (ServerState.IsRunning)
            {
                try
                {
                    Print.Print.Yellow("Waiting for client to connect");
                    TcpClient client = serverSocket.AcceptTcpClient();          //Accepting tbc client
                    Print.Print.Yellow("Client has Connected");
                    ClientController controller = new ClientController(client); //Init the Client Controller class
                    controller.Start();                                         //Starting the Worker on the client Controller "Running on it's own Thread"
                }
                catch (Exception e)
                {

                    Print.Print.Red($"Error + {e}");
                }
            }
        }


    }
}
