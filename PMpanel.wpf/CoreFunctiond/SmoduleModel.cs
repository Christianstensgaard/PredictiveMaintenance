using PMpanel.wpf.CoreFunctiond.IOTModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMpanel.wpf.CoreFunctiond
{
    public class SmoduleModel
    {

        public int id { get;}
        public string Name { get;}
        public List<SensorModel> connectedSensors { get;}

        public SmoduleModel(int id, string name, List<SensorModel> connectedSensors)
        {
            this.id = id;
            Name = name;
            this.connectedSensors = connectedSensors;
        }

        /*Måske lave en klasse som indeholde en sensor, så der kan laves uendelige mange af dem, hvis det nødvendigt?? */

        /*Jeg har lavet så det tager en list<> med connected sensors*/


        //TODO Der skal kigges mere på denne klasse og dets rolle i systemet!







    }
}
