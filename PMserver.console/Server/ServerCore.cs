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
    public class ServerCore
    {
        private TcpListener serverSocket;   //ServerSocket
        private Thread serverThread;        //ServerThread
        private ClientCore clientCore;      //ClientCore

        public ServerCore()
        {
            //> Getting information and init serversocket.
            serverSocket = new TcpListener(IPAddress.Parse(ServerConnectionLayer.adress), ServerConnectionLayer.port);
        }





        /// <summary>
        /// Starting Server on a new Thread, and will begin accepting Clients. 
        /// </summary>
        public void Start()
        {
            try
            {
                ServerState.IsRunning = true;       //Setting Server state to Running
                serverSocket.Start();               //Starting ServerSocket
                clientCore = new ClientCore();      //Init ClientCore class
                clientCore.Start();                 //Starting ClientCore class
                serverThread = new Thread(Server);  //Creating thread
                serverThread.Start();               //Starting Thread
            }
            
            catch (Exception)
            {
                //TODO Error logging ServerCore
                ServerState.IsRunning=false;        //Setting Server state to false
                throw;                              //Throw error exception
            }
        }

        public void Stop()
        {
            ServerState.IsRunning=false;
            serverSocket.Stop();

        }


        /// <summary>
        /// Background Worker Thread. 
        /// </summary>
        private void Server()
        {
            while (ServerState.IsRunning)
            {
                try
                {
                    Console.WriteLine("Waiting for client to connect");
                    //> Directing new client to ClientCore.
                    TcpClient client = serverSocket.AcceptTcpClient(); //Accepting tcp client
                    ClientModel clientModel = new ClientModel(client); //Init ClientModel class
                    clientCore.AddClient(clientModel);                 //Adding client to client Core
                }
                catch (Exception)
                {
                }


            }
        }



    }
}
