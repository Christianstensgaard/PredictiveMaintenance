using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTL.Communication.StreamConverter.Models
{
    public class HovedModuleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SensorModuleModel> LinkedSmodules { get; set; }






        public HovedModuleModel(int id, string name)
        {
            Id = id;
            Name = name;
            LinkedSmodules = new List<SensorModuleModel>();
        }
    }
}
