using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HA_OA
{
    public partial class frmMain : Form
    {

        frmOverTime OT;
        frmLeaveInfo Leave;
        public frmMain()
        {
            InitializeComponent();
        }




        private void btnOTInfo_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            OT = new frmOverTime();
            OT.TopLevel = false;
            OT.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            OT.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(OT);
            OT.Show();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           // OT = new frmOverTime();
        }

        private void btmLeaveInfo_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Leave = new frmLeaveInfo();
            Leave.TopLevel = false;
            Leave.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Leave.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(Leave );
            Leave.Show();
        }



    }
}
