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
            txtHours.Text = string.Format("{0:F}", TimeHelper.DateTimeDiff(dtpStartTime.Value, dtpEndTime.Value));
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            txtHours.Text = string.Format("{0:F}", TimeHelper.DateTimeDiff(dtpStartTime.Value, dtpEndTime.Value));
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty (txtHours.Text.Trim ()))
            {

                MessageBox.Show("时数为空,请重新选择日期和时间.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpStartTime.Focus();
                return;
            }

            if (dtpEndTime.Value <= dtpStartTime.Value)
            {
                MessageBox.Show("结束时间不能小于等于开始时间,请重新选择日期和时间.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpStartTime.Focus();
                return;
            }

            if (string.IsNullOrEmpty (txtReason.Text.Trim ()))
            {
                MessageBox.Show("事由为空,请重新输入.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReason.SelectAll();
                txtReason.Focus();
                return;
            }




        }

    }
}
