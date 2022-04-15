using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMpanel.wpf.CoreFunctiond
{
    public class HmoduleModel
    {
        public string ModuleName { get; set; }
        public int Id { get; set; }
        public int MedianSensorValue { get; set; }

        public HmoduleModel(string moduleName, int id, int medianSensorValue)
        {
            ModuleName = moduleName;
            Id = id;
            MedianSensorValue = medianSensorValue;
        }

        /*Dette er en model til vores HovedModul, som har en x antal Sensor moduler (Smodule) tilsluttet.*/
        //TODO der skal kigges mere på denne klasses rolle i programmet.



    }
}
