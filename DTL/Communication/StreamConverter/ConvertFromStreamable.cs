using DTL.Communication.StreamConverter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTL.Communication.StreamConverter
{
    public class ConvertFromStreamable
    {
        string inputstream;
        char[] buffer;
        int currentPlacement;
        enum modeltypes {SystemLine, HModule, Smodule}
        public ConvertFromStreamable(string streamin)
        {
            inputstream = streamin;
            buffer = inputstream.ToCharArray();
            currentPlacement = 0;
            Console.WriteLine(HasSystemLine());
        }

        public void Convert()
        {
            if(HasSystemLine())
                convertWithSystemLine();
            else ConvertWithNullSystemLine();
        }

        




        private bool HasSystemLine()
        {
            return buffer[0] == '#';
        }


        private SystemLineModel convertWithSystemLine()
        {
            SystemLineModel lineModel;


            //Get Syntax

            while(currentPlacement < buffer.Length)
            {
                SystemLineModel systemLine;


                switch (buffer[currentPlacement])
                {
                    case '#':
                        Console.WriteLine("SystemLineFound");
                        systemLine = TosystemLine(currentPlacement);
                        //TODO jeg er nået hertil, jeg er begyndt på at samle en string til de tilhørende klasser
                        Console.WriteLine(systemLine.Name);

                        break;
                    case '$':
                        Console.WriteLine("HovedModuleFound");
                        HovedModuleModel hovedModule = ToHovedModule(currentPlacement);
                        Console.WriteLine(hovedModule.Name);
                        break;
                    case '@':
                        Console.WriteLine("SensorModuleFound");
                        SensorModuleModel sensorModuleModel = TosensorModule(currentPlacement);
                        Console.WriteLine(sensorModuleModel.Name);
                        break;
                }


                currentPlacement++;
            }













            return null;
        }

        public string ConvertWithNullSystemLine()
        {
            

            return string.Empty;
        }


        /// <summary>
        /// Checking the next char
        /// </summary>
        /// <param name="inn"></param>
        /// <returns></returns>
        private bool DoNext(int index)
        {
            if(index +1 >= buffer.Length)
                return false;
            return buffer[index+1] != '!';
        }
        /// <summary>
        /// Checking if the region ends.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool RegionEnd(int index)
        {
            if(index+1 >= buffer.Length)
                return true;
            return buffer[index+1] == '#'
                || buffer[index+1] == '$'
                || buffer[index+1] == '@';
        }




        /// <summary>
        /// Converting String to SystemLine
        /// </summary>
        /// <param name="startingpoint">placement of current char[] placement</param>
        /// <returns>systemLineModel</returns>
        private SystemLineModel TosystemLine(int startingpoint)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (DoNext(startingpoint++))
            {
                stringBuilder.Append(buffer[startingpoint]);
            }
            currentPlacement = startingpoint+1;
            return new SystemLineModel(0, stringBuilder.ToString());
        }
        /// <summary>
        /// Converting from string to HovedModule
        /// </summary>
        /// <param name="startingpoint">placement of current char[] placement</param>
        /// <returns>HovedModuleModel</returns>
        private HovedModuleModel ToHovedModule(int startingpoint)
        {
            StringBuilder sb = new StringBuilder();
            while (DoNext(startingpoint++))
            {
                sb.Append(buffer[startingpoint]);
            }
            currentPlacement=startingpoint+1;
            return new HovedModuleModel(0, sb.ToString());
        }

        /// <summary>
        /// Converting from String into SensorModule 
        /// </summary>
        /// <param name="startingpoint">placement of current char[] placement</param>
        /// <returns>SensorModuleModel</returns>
        private SensorModuleModel TosensorModule(int startingpoint)
        {
            StringBuilder sb = new StringBuilder();
            while (DoNext(startingpoint++))
            {
                sb.Append(buffer[startingpoint]);
            }
            currentPlacement = startingpoint + 1;
            return new SensorModuleModel(0, sb.ToString());
        }

         



    }
}
