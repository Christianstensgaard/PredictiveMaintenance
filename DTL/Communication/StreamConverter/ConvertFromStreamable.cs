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


        private string convertWithSystemLine()
        {
            Debug.WriteLine("Converting Input with SystemLine");
            StringBuilder sb = new StringBuilder();

            SystemLineModel systemLine = TosystemLine(currentPlacement);
            Console.WriteLine(currentPlacement);

            HovedModuleModel hovedModuleModel = ToHovedModule(currentPlacement);
            Console.WriteLine(hovedModuleModel.Name);
            Console.WriteLine(buffer[currentPlacement]);

            /*For now this is only used for testing, and will be remade later*/





            return string.Empty;
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
