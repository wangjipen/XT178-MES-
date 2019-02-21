using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMaterialRack.IntelligentMaterialRack.FUNCTION
{
  public   class Status
    {

        private int _Id;
        private string _Name;
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        public Status(int id, string name)
        {
            this._Id = id;
            this._Name = name;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
