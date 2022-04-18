using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTL.Communication
{
    internal class InputStream
    {
        char[] stream;
        int placement = 0;
        public InputStream(char[] stream)
        {
            this.stream = stream;
        }



        public bool HasNext()
        {
            return placement < stream.Length;
        }
        public char GetNext() 
        { 
            return stream[placement++]; 
        }









    }
}
