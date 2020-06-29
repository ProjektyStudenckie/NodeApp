using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp
{
    static class DataProgram
    {
        private static Room room;

        public static Room Room
        {
            get { return room; }
            set { room = value; }
        }  
    }
}
