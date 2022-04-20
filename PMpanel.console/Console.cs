//Giver dig fuld kontrol over serverens funktioner via console. 
//Dette er kun ment, som en test anvendelse af programmet.



using DTL.Connection;
using System.Net.Sockets;


TcpClient client = new TcpClient(ServerConnectionLayer.adress, ServerConnectionLayer.port);


StreamWriter writer = new StreamWriter(client.GetStream());
StreamReader reader = new StreamReader(client.GetStream());

while (client.Connected)
{
    try
    {
        Console.WriteLine(reader.ReadLine());

        /*Convert into classes*/

        client.Close();
        Console.ReadLine();
    }
    catch (Exception)
    {

    }
}