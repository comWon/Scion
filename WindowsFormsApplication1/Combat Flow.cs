using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scion.MainHard;

namespace WindowsFormsApplication1
{
    public partial class Combat_Flow : Form
    {
        /// <summary>
        /// Data Land
        /// </summary>
        /// 
        CharacterSet CGroup = new CharacterSet();
        

        public Combat_Flow()
        {
            InitializeComponent();
        }

        private void CBinding_CurrentChanged(object sender, EventArgs e)
        {
            
        }
    }
}
