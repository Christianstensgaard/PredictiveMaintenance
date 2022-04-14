
// Start Server
using PMserver.console.Server;
using System.Net;
using System.Net.Sockets;

TcpListener serverSocket;
ServerInformationLayer serverInformationLayer;



serverInformationLayer = new ServerInformationLayer("127.0.0.1", 20200);




try
{
    serverSocket = new TcpListener(IPAddress.Parse(serverInformationLayer.Adress), serverInformationLayer.Port);
    serverSocket.Start();
    Console.WriteLine("Server Stared");

}
catch (Exception)
{

    throw;
}








while (true)
{
  

}
