using DTL.Communication.StreamConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMserver.console.ConnectedServices
{
    public class ProductionLine
    {
        public static readonly ProductionLine Instance = new ProductionLine();
        static ProductionLine()
        {

        }
        public static ProductionLine GetInstance { get { return Instance; } }

        /*Dummy data, don't know yet how i will make this work. */
        //Used to send data to the client via TCP. 


        List<SystemLineModel> systemLines;

        private ProductionLine()
        {
            systemLines = new List<SystemLineModel>();
        }


        public void add(SystemLineModel systemLine)
        {
            lock (this)
            {
                systemLines.Add(systemLine);
            }
        }

        public void Remove(SystemLineModel systemLine)
        {
            lock (this)
            {
                systemLines.Remove(systemLine);
            }
        }

        public List<SystemLineModel> getAll()
        {
            return systemLines;
        }
    }
}
