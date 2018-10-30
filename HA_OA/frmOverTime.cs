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
    public partial class frmOverTime : Form
    {
        public frmOverTime()
        {
            InitializeComponent();
        }

        private void frmOverTime_Load(object sender, EventArgs e)
        {
            LoadUI();
        }




        private void LoadUI()
        {
            comboDep.Items.Clear();
            comboDep.Items.Add(p.LoginID.Department);
            comboDep.SelectedIndex = 0;
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            txtHours.Text = TimeHelper.DateTimeDiff(dtpStartTime.Value, dtpEndTime.Value).ToString();
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            txtHours.Text = TimeHelper.DateTimeDiff(dtpStartTime.Value, dtpEndTime.Value).ToString();
        }

    }
}
