using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDbUserInterface.ServiceInterfaces
{
    public  class ANumRowEventArgs:EventArgs
    {
        public int numRow { get; set; }
        public ANumRowEventArgs(int row):base()
        {
            numRow = row;
        }
    }
}
