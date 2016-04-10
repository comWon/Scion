using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scion.Main;


namespace Scion.Forms.Windows
{
    public partial class MonsterMaker : System.Windows.Forms.Form
    {
        public List<Monster> Monsters { get; private set; }

        public MonsterMaker()
        {
            InitializeComponent();
            List<Monster> Monsters = new List<Monster>();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Monsters = FileManagment.MonsterLoader(this.FilePathText.Text.ToString());
        }

    }
}
