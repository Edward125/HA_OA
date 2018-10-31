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
    public partial class frmLeaveInfo : Form
    {
        public frmLeaveInfo()
        {
            InitializeComponent();
        }

        private void frmLeaveInfo_Load(object sender, EventArgs e)
        {
            LoadUI();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadUI()
        {
            comboDep.Items.Clear();
            comboDep.Items.Add(p.LoginID.Department);
            comboDep.SelectedIndex = 0;


           frmOverTime. SetListView(listviewInfo);

            string sql = "select * from ha_leaveinfo ";
            int totolrecord = 0;
            double totalhours = 0.0;
           frmOverTime.LoadInfo2Listview(sql, listviewInfo, out totolrecord, out totalhours);
            txtInfo.Text = "发现" + p.LoginID.Name + "的请假记录" + totolrecord + "条,共计:" + totalhours + "小时";

        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            txtHours.Text = string.Format("{0:F}", TimeHelper.DateTimeDiff(dtpStartTime.Value, dtpEndTime.Value,TimeHelper.InfoType.LeaveTime ));
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            txtHours.Text = string.Format("{0:F}", TimeHelper.DateTimeDiff(dtpStartTime.Value, dtpEndTime.Value, TimeHelper.InfoType.LeaveTime));
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHours.Text.Trim()))
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

            if (string.IsNullOrEmpty(txtReason.Text.Trim()))
            {
                MessageBox.Show("事由为空,请重新输入.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReason.SelectAll();
                txtReason.Focus();
                return;
            }

            string sql = "Insert into ha_leaveinfo () values('" + p.LoginID.Department + "','" + p.LoginID.Name + "','" + dtpStartTime.Value.Date + "','" +
                dtpStartTime.Value + "','" + dtpEndTime.Value + "'," + Convert.ToDouble(txtHours.Text) + ",'" + DateTime.Now + "','" + @txtReason.Text.Trim() + "')";
            string ex = string.Empty;
            if (p.InsertDate2Database(p.ConnStr, sql, out ex))
            {
                MessageBox.Show("插入数据成功", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHours.Text = string.Empty;
                txtReason.SelectAll();
                txtReason.Focus();
                sql = "select * from ha_leaveinfo ";
                int totolrecord = 0;
                double totalhours = 0.0;
               frmOverTime. LoadInfo2Listview(sql, listviewInfo, out totolrecord, out totalhours);
                txtInfo.Text = "发现" + p.LoginID.Name + "的请假记录" + totolrecord + "条,共计:" + totalhours + "小时";
            }

            else
                MessageBox.Show("插入数据失败,详细信息:" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtHours.Text = string.Empty;
            txtReason.Text = string.Empty;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string sql = "select * from ha_leaveinfo where date >'" + dtpStartDate.Value.Date + "' and date <'" + dtpEndDate.Value.Date + "'";
            int totolrecord = 0;
            double totalhours = 0.0;
           frmOverTime. LoadInfo2Listview(sql, listviewInfo, out totolrecord, out totalhours);
            txtInfo.Text = "发现" + p.LoginID.Name + "的请假记录" + totolrecord + "条,共计:" + totalhours + "小时";
        }

        private void txtReason_DoubleClick(object sender, EventArgs e)
        {
            txtReason.SelectAll();
        }
    }
}
