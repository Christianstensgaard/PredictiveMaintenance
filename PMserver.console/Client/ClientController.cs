using DTL.Communication.StreamConverter;
using DTL.Safety;
using PMserver.console.ConnectedServices;
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


            while (client.Connected)
            {
                try
                {
                    ConvertToStreamable convertToStreamable = new ConvertToStreamable(ProductionLine.GetInstance.getAll());
                    writer.WriteLine(convertToStreamable.Convert());
                    writer.Flush();
                    client.Close();
                    Print.Print.Green("client exited with no error ");
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
