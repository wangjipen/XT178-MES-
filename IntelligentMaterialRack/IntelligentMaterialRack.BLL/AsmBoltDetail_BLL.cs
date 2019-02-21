using SKTraceablity.SKTraceablity.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.BLL
{
    class AsmBoltDetail_BLL
    {
        public static int AddBoltByObject(AsmBoltDetailObject abdo)
        {
            int a = AsmBoltDetail_DAL.AddBoltByObject(abdo);
            return a;
        }
    }
}
