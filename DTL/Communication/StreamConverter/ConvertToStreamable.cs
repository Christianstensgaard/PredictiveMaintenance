using DTL.Communication.StreamConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTL.Communication.StreamConverter
{
    public class ConvertToStreamable
    {
        bool HasSystemLine { get;}
        List<SystemLineModel>?  systemLineModels;
        List<HovedModuleModel>? hovedModuleModels;


        public ConvertToStreamable(List<SystemLineModel> systemLines)
        {
            this.systemLineModels = systemLines;
            HasSystemLine = true;
        }

        public ConvertToStreamable(List<HovedModuleModel> Hmodules)
        {
            hovedModuleModels = Hmodules;
            HasSystemLine = false;
        }


        public string Convert()
        {
            if(HasSystemLine) return ConvertWithSystemLine();
            return ConvertWithNullSystemLines();
        }



        /*
         * Oversætning af betydende chars
            * System-Linje  = #, ##, !## (start, Slut)
            * Hoved-Module  = $, $$, !$$ (Start, Slut)
            * Sensor-Module = @, @@, !@@ (Start, Slut)
        */

        private string ConvertWithNullSystemLines()
        {
            StringBuilder sb = new StringBuilder();
            //> Appending all "H-modules"
            foreach (HovedModuleModel HM in hovedModuleModels)
            {
                sb.Append('$');     //Start Syntax
                sb.Append(HM.Name); //Storing name
                sb.Append("$$");    //End Syntax

                //Appending all S-modules
                foreach (SensorModuleModel SM in HM.LinkedSmodules)
                {
                    sb.Append('@');     //Start syntax
                    sb.Append(SM.Name); //Storing name
                    sb.Append("@@");    //End syntax

                    //Appending all sensors
                    foreach (var s in SM.connectedSensors)
                    {
                        sb.Append(s.value); //Storing the sensor value
                        sb.Append(',');     //separating the values
                    }
                    sb.Append("!@@");
                }

                sb.Append("!$$");
            }
            return sb.ToString();
        }
        private string ConvertWithSystemLine()
        {
            StringBuilder sb = new StringBuilder();
            foreach (SystemLineModel SL in systemLineModels)
            {
                //> Starting the SystemLine Syntax
                sb.Append("#");     //Starting Syntax
                sb.Append(SL.Name); //Storing name in String
                sb.Append("!");    //End syntax
                //> Done with naming the SystemLine

                //> Appending all "H-modules"
                foreach (HovedModuleModel HM in SL.LinkedHmodules)
                {
                    sb.Append("$");     //Start Syntax
                    sb.Append(HM.Name); //Storing name
                    sb.Append("!");    //End Syntax

                    //Appending all S-modules
                    foreach (SensorModuleModel SM in HM.LinkedSmodules)
                    {
                        sb.Append("@");     //Start syntax
                        sb.Append(SM.Name); //Storing name
                        sb.Append("!");    //End syntax

                        //Appending all sensors
                        foreach (var s in SM.connectedSensors)
                        {
                            sb.Append(s.value); //Storing the sensor value
                            sb.Append('!');     //separating the values
                        }
                    }
                }
            }
            return sb.ToString();
        }




    }
}
