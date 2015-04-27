using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDB.Model
{
   public  class NumRowEventArgs : EventArgs
    {
        public int numRow { get; set; }
        public NumRowEventArgs(int row):base()
        {
            numRow = row;
        }
    }
}
