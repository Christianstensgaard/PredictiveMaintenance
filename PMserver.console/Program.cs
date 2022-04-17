
using PMserver.console.Server;




ServerCore serverCore = new ServerCore();
serverCore.Start();



while (true)
{
    string? a = Console.ReadLine();

    switch (a)
    {
        case "#Restart":
            Console.WriteLine("Restarting Server");
            break;
        case "#State":
            break;
        case "#Exit":
            serverCore.Stop();
            break;


        default:
            break;
    }


}




