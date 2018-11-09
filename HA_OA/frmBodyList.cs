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
    public partial class frmBodyList : Form
    {
        public frmBodyList()
        {
            InitializeComponent();
        }

        private void frmBodyList_Load(object sender, EventArgs e)
        {
            SetListView(listviewinfo);
        }



        /// <summary>
        /// 
        /// </summary>
        private void LoadModel()
        {
            comboModel.Items.Clear();
            string sql = "select * from ha_modellist";
            List<string> model = new List<string>();
            p.QueryDatabase(p.ConnStr, sql, "model", out model);
            foreach (string item in model)
            {
                comboModel.Items.Add(item);
            }
            if (comboModel.Items.Count > 0)
                comboModel.SelectedIndex = 0;

        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadHwInfo()
        {
            comboHwInfo.Items.Clear();
            string sql = "select * from ha_hwinfo";
            List<string> hwinfo = new List<string>();
            p.QueryDatabase(p.ConnStr, sql, "hwinfo", out hwinfo);
            foreach (string item in hwinfo)
            {
                comboHwInfo.Items.Add(item);   
            }
            if (comboHwInfo.Items.Count > 0)
                comboHwInfo.SelectedIndex = 0;


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="listview"></param>
        public static void SetListView(ListView listview)
        {
            listview.Clear();
            listview.View = View.Details;
            listview.MultiSelect = false;
            listview.AutoArrange = true;
            listview.GridLines = true;
            listview.FullRowSelect = true;
            listview.Columns.Add("序列号", 80, HorizontalAlignment.Center);
            listview.Columns.Add("型号", 50, HorizontalAlignment.Center);
            listview.Columns.Add("硬件", 60, HorizontalAlignment.Center);
            listview.Columns.Add("服务器IP", 80, HorizontalAlignment.Center);
            listview.Columns.Add("账号", 80, HorizontalAlignment.Center);
            listview.Columns.Add("密码", 80, HorizontalAlignment.Center);
            listview.Columns.Add("去向", 200, HorizontalAlignment.Center);
            listview.Columns.Add("备注", 280, HorizontalAlignment.Center);


        }



        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "新增")
            {
                btnNew.Text = "保存";
                btnEdit.Enabled = false;
                LoadHwInfo();
                LoadModel();
                txtSN.Text = string.Empty;
                txtSN.ReadOnly = false;
                txtLocation.Text = string.Empty;
                txtLocation.ReadOnly = false;
                txtRemark.Text = string.Empty;
                txtRemark.ReadOnly = false;
                txtIP.Text = string.Empty;
                txtIP.ReadOnly = false;
                txtID.Text = string.Empty;
                txtID.ReadOnly = false;
                txtpwd.Text = string.Empty;
                txtpwd.ReadOnly = false;
            }
            else
            {
                btnNew.Text = "新增";
                btnEdit.Enabled = true;
                comboHwInfo.Items.Clear();
                comboModel.Items.Clear();
                txtSN.Text = string.Empty;
                txtSN.ReadOnly = true;
                txtLocation.Text = string.Empty;
                txtLocation.ReadOnly = true;
                txtRemark.Text = string.Empty;
                txtRemark.ReadOnly = true;
                txtIP.Text = string.Empty;
                txtIP.ReadOnly = true;
                txtID.Text = string.Empty;
                txtID.ReadOnly = true;
                txtpwd.Text = string.Empty;
                txtpwd.ReadOnly = true;
            }
        }



    }
}
