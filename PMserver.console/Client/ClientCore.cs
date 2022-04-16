using PMserver.console.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PMserver.console.Client
{
    public class ClientCore
    {
        //´Collection of Client States, handled by the Thread.
        List<ClientModel> NewClients;
        List<ClientModel> lostClients;
        List<ClientModel> clients;

        Thread clientCoreThread;


        public ClientCore()
        {
            clients = new List<ClientModel>();
            NewClients = new List<ClientModel>();
            lostClients = new List<ClientModel>();
            clientCoreThread = new Thread(BackgroundWorker);
        }


        /// <summary>
        /// Starting the ClientCore Class on it's own Thread.
        /// </summary>
        public void Start()
        {
            try
            {
                clientCoreThread.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Adding new client to the list. 
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(ClientModel client)
        {
            lock (this)
            {
                NewClients.Add(client);
            }
        }







        /// <summary>
        /// Removing all disconnected clients from the main list<>
        /// </summary>
        void RemoveLostClients()
        {
            foreach (ClientModel client in lostClients)
            {
                clients.Remove(client);
            }
            lostClients.Clear();
        }

        /// <summary>
        /// BackgroundWorker, Handling all communication with active clients.
        /// </summary>
        void BackgroundWorker()
        {
            while (ServerState.IsRunning)
            {
                foreach (ClientModel clientModel in NewClients)
                {
                    clients.Add(clientModel);
                }
                NewClients.Clear();

                //> Main Client Communication. 
                foreach (ClientModel client in clients)
                {
                    //> Adding client to Remove list.
                    if (!client.client.Connected)
                    {
                        lostClients.Add(client);
                        continue;
                    }


                    /*
                     *Her skal Alt Kommunikation med client sendes, om den bare skal sende alt, eller den ud fra en komando give data. 
                     */





                }
                RemoveLostClients(); //Removing all Clients. 
            }
        }


    }
}
