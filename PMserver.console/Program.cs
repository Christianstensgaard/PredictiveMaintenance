using DTL.Communication.StreamConverter;
using DTL.Communication.StreamConverter.Models;
using DTL.Communication.StreamConverter.Models.EmbededModels;
using PMserver.console.Server;




#region Server
Print.Print.Yellow("Starting Server");
ServerSocket server = new ServerSocket();
if (server.Start())
    Print.Print.Green("Server Started");
else Print.Print.Red("Server Could not start");
#endregion


#region Dummy data


/*Setting ud Dummy Modules and SystemLine*/
SensorModel sen1 = new SensorModel("1", 20);
SensorModel sen2 = new SensorModel("1", 1);
SensorModel sen3 = new SensorModel("1", 23);
SensorModel sen4 = new SensorModel("1", 98);

SensorModuleModel sensorModule1 = new SensorModuleModel(1, "TopArm");
sensorModule1.connectedSensors.AddRange(new[] { sen1, sen2, sen3, sen4 });

HovedModuleModel HModule = new HovedModuleModel(1, "Robot 1");
HModule.LinkedSmodules.Add(sensorModule1);

HovedModuleModel HModule2 = new HovedModuleModel(1, "Robot 2");
HModule2.LinkedSmodules.Add(sensorModule1);

SystemLineModel systemLine1 = new SystemLineModel(1, "Plast1");
systemLine1.LinkedHmodules.Add(HModule);
systemLine1.LinkedHmodules.Add(HModule2);


/*END*/


List<SystemLineModel> list = new List<SystemLineModel>();
list.Add(systemLine1);


/*Converting to String for Tcp*/
ConvertToStreamable convertToStreamable = new ConvertToStreamable(list);
Console.WriteLine(convertToStreamable.Convert());

ConvertFromStreamable ConvertFromStreamable = new ConvertFromStreamable(convertToStreamable.Convert());
ConvertFromStreamable.Convert();
#endregion






#region Console 
bool isRunning = true;
/*Lave noget Så der kan Ændres i forskellige ting. */
while (isRunning)
{
    string? inn = Console.ReadLine();
    switch (inn)
    {
        case ".stop":
            server.Stop();
            break;

        case ".start":
            server = new ServerSocket();
            server.Start();
            break;

        case ".exit":
            server.Stop();
            isRunning = false;
            break;

        case ".clear":
            Console.Clear();
            break;

        default:
            Print.Print.Yellow("try Again");
            break;
    }
}






#endregion