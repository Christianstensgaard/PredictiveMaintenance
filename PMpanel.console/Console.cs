//Giver dig fuld kontrol over serverens funktioner via console. 
//Dette er kun ment, som en test anvendelse af programmet.



using DTL.Connection;
using System.Net.Sockets;


TcpClient client = new TcpClient(ServerConnectionLayer.adress, ServerConnectionLayer.port);