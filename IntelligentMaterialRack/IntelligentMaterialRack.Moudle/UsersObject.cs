using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.Moudle
{
    [Table("Users")] //映射User类
    public class UsersObject
    {
        [Key]
        public virtual int h_ID { get; set; }
        [Column("h_UserName")]
        public string h_UserName { get; set; }
        [Column("h_yUserPwd")]
        public string h_yUserPwd { get; set; }
        [Column("h_Permissions")]
        public string h_Permissions { get; set; }
        [Column("h_Status")]
        public int h_Status { get; set; }
        [Column("h_Department")]
        public string h_Department { get; set; }
        [Column("h_Security")]
        public string h_Security { get; set; }
        [Column("Power")]
        public string Power { get; set; }
    }
}
