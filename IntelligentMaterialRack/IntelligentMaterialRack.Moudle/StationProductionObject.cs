using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.Moudle
{
   public class StationProductionObject : IEquatable<StationProductionObject>//继承IEquatable接口，实现Equals方法。List就可以使用Distinct去重
    {
        public string StationName { set; get; }
        public string ProductionName { set; get; }
        public string ProductionPn { set; get; }
        public string StepNo { get; set; }
        public string Step_Category { get; set; }
        public string Material_Name { get; set; }
        public string Number { get; set; }
        public string Gun_No { get; set; }
        public string Program_No { get; set; }
        public string Sleeve_No { get; set; }
        public string Photo_No { get; set; }
        public string A_Limit { get; set; }
        public string BoltEQS { get; set; }
        public string T_Limit { get; set; }
        public string MaterialPn { get; set; }
        public string T_Target { get; set; }
        public string T_Limits { get; set; }
        public string L_Program { get; set; }
        public string L_Rate { get; set; }
        public string PICPath { get; set; }
        public bool Equals(StationProductionObject other)
        {
            return this.StationName == other.StationName;
        }
        public override int GetHashCode()
        {
            return StationName.GetHashCode();
        }
    }
}
