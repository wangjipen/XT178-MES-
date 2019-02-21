using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SKTraceablity.Config
{
    public partial class frmConfig : Form
    {
        public XmlNode rootNode;
        public frmConfig()
        {
            InitializeComponent();
        }
    }
}
