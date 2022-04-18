using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTL.Communication.StreamConverter.Models.EmbededModels
{
    public class SensorModel
    {
        public string name { get; set; }
        public int value { get; set; }

        public SensorModel(string name, int value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
