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
            if(HasSystemLine) return ConvertWithNullSystemLines();
            return ConvertWithSystemLine();
        }


        private string ConvertWithNullSystemLines()
        {





            return string.Empty;
        }

        private string ConvertWithSystemLine()
        {

            return string.Empty;
        }




    }
}
