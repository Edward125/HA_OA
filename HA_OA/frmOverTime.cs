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

            SetListView(listviewInfo);
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

            string sql = "Insert into ha_otinfo () values('" + p.LoginID.Department + "','" + p.LoginID.Name + "','" + dtpStartTime.Value.Date + "','" +
                dtpStartTime.Value + "','" + dtpEndTime.Value + "'," + Convert.ToDouble ( txtHours.Text )+ ",'" + DateTime.Now + "','" + @txtReason.Text.Trim() + "')";
            string ex = string.Empty;
            if (p.InsertDate2Database(p.ConnStr, sql, out ex))
                MessageBox.Show("插入数据成功", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("插入数据失败,详细信息:" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }



        private void SetListView(ListView listview)
        {
            listview.Clear();
            listview.View = View.Details;
            listview.MultiSelect = false;
            listview.AutoArrange = true;
            listview.GridLines = true;
            listview.FullRowSelect = true;
            listview.Columns.Add("部门名称", 60, HorizontalAlignment.Center);
            listview.Columns.Add("姓名", 80, HorizontalAlignment.Center);
            listview.Columns.Add("日期", 60, HorizontalAlignment.Center);
            listview.Columns.Add("开始时间", 100, HorizontalAlignment.Center);
            listview.Columns.Add("截至时间", 100, HorizontalAlignment.Center);
            listview.Columns.Add("时数", 50, HorizontalAlignment.Center);
            listview.Columns.Add("填写时间", 100, HorizontalAlignment.Center);
            listview.Columns.Add("事由", 350, HorizontalAlignment.Center);



        }



    }
}
