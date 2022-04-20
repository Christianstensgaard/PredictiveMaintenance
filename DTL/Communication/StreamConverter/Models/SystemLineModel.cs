using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTL.Communication.StreamConverter.Models
{
    public class SystemLineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HovedModuleModel> LinkedHmodules { get; set; }

        public SystemLineModel(int id, string name)
        {
            Id = id;
            Name = name;
            LinkedHmodules = new List<HovedModuleModel>();
        }
    }
}
