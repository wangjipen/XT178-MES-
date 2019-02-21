using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMaterialRack.IntelligentMaterialRack.Moudle
{
    [Table("C_ASM_DEVICE_T")] //映射User类
    class AsmDeviceObject
    {
        [Key]
        public virtual int ID{ get; set; }
        [Column("DEVICE_NAME")]
        public string DEVICE_NAME { get; set; }
        [Column("DEVICE_STATION")]
        public string DEVICE_STATION { get; set; }

        [Column("DEVICE_TYPE")]
        public string DEVICE_TYPE { get; set; }
        [Column("DEVICE_IP")]
        public string DEVICE_IP { get; set; }
        [Column("DEVICE_CID")]
        public string DEVICE_CID { get; set; }
        [Column("DEVICE_PROTOCOL")]
        public string DEVICE_PROTOCOL { get; set; }
        [Column("DEVICE_PRINTADD")]
        public string DEVICE_PRINTADD { get; set; }
        [Column("DEVICE_CONTROLADD")]
        public string DEVICE_CONTROLADD { get; set; }
    }
}
