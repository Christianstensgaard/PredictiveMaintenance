using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMpanel.wpf.CoreFunctiond.IOTModels
{
    public class SensorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }


        /// <summary>
        /// Sensor model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public SensorModel(int id, string name, int value)
        {
            Id = id;
            Name = name;
            Value = value;
        }






        /// <summary>
        /// Converting float to procentage int 
        /// </summary>
        /// <param name="input"> Float > 0 && < 1 </param>
        public void ConvertFloat(float input)
        {
            if(input !> 1 && input !<0)
            {
                Value = (int) input * 100;
            }
        }
        public float ToFloat()
        {
            return Value / 100;
        }


        //TODO Jeg er nået hertil med arbejdet, så der skal kigges mere på denne klasse.

    }
}
