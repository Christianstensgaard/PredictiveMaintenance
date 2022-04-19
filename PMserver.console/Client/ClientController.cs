using DTL.Safety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PMserver.console.Client
{
    internal class ClientController
    {
        TcpClient client;
        Thread clientThread;
        cryptionEngine cryption;

        StreamWriter writer;

        int frequencyWriter = 1000;


        public ClientController(TcpClient client)
        {
            this.client = client;
            clientThread = new Thread(Worker);

            writer = new StreamWriter(this.client.GetStream());
            cryption = new cryptionEngine();
        }


        public void Start()
        {
            clientThread.Start();
        }



        private void Worker()
        {
            //Der skal laves et håndtryk som er sikker, så andre ikke bare lytter på denne port. og får tilsendt data.


            while (client.Connected)
            {
                try
                {
                    writer.WriteLine(cryption.Encryption("hej"));
                    writer.Flush();
                    Thread.Sleep(frequencyWriter);
                }

                catch (Exception)
                {
                    Print.Print.Red($"Connection lost");
                    Print.Print.Red("Closing Connection");
                    client.Close();
                }
            }
        }





    }
}
