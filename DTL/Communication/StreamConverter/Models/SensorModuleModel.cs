using DTL.Communication.StreamConverter.Models.EmbededModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTL.Communication.StreamConverter.Models
{
    public class SensorModuleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SensorModel> connectedSensors { get; set; }


        public SensorModuleModel(int id, string name)
        {
            Id = id;
            Name = name;
            connectedSensors = new List<SensorModel>();
        }
    }
}
