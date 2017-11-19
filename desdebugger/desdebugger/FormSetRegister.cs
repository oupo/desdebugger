using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desdebugger
{
    public partial class FormSetRegister : Form
    {
        public FormSetRegister()
        {
            InitializeComponent();
        }

        public void SetValue(uint value)
        {
            this.textBoxRegValue.Text = String.Format("{0:x8}", value);
        }

        public uint GetValue()
        {
            return Convert.ToUInt32(this.textBoxRegValue.Text, 16);
        }
    }
}
