using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTraceablity.Query
{
  public  class Table
    {
        private string tabelName;

        public string TabelName
        {
            get { return tabelName; }
            set { tabelName = value; }
        }
        private string tableValue;

        public string TableValue
        {
            get { return tableValue; }
            set { tableValue = value; }
        }
    }
}
