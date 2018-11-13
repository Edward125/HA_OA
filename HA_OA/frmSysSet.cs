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
    public partial class frmSysSet : Form
    {
        public frmSysSet()
        {
            InitializeComponent();
        }


        /// <summary>
        /// load version
        /// </summary>
        private void LoadVersion()
        {
            lstVersion.Items.Clear();
            string sql = "select version  from ha_oa_version where isrun = 1";

            List<string> listversion = new List<string>();
            p.QueryDatabase(p.ConnStr, sql, "version", out listversion);
            if (listversion.Count > 0)
            {
                foreach (string item in listversion )
                {
                    lstVersion.Items.Add(item);
                }
            }

        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSysSet.Focused)
            {
                LoadVersion();
                btnAddVersion.Enabled = false;
                btnDeleteVersion.Enabled = false;
            }
        }

        private void frmSysSet_Load(object sender, EventArgs e)
        {
            LoadVersion();
            btnAddVersion.Enabled = false;
            btnDeleteVersion.Enabled = false;
        }

        private void lstVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVersion.SelectedIndex != -1)
                btnDeleteVersion.Enabled = true;
        }

        private void txtVersion_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty (txtVersion.Text.Trim ()))
                btnAddVersion.Enabled = true ;

        }

        private void btnAddVersion_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否添加新的版本号:" + txtVersion.Text.Trim ()+",添加后,该版本的软件可以运行.添加点击是(Y),不添加点击否(N)?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string exmsg = string.Empty;

                string sql = "insert into ha_oa_version () values ('" + txtVersion.Text.Trim() + "',1)";
                if (p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                {
                    MessageBox.Show("更新数据库成功.", "Update Database Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtVersion.Text = string.Empty;
                    LoadVersion();
                }
                else
                {
                    MessageBox.Show("更新数据库失败," + exmsg, "Update Database Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtVersion.SelectAll();
                    txtVersion.Focus();
                }

                
                

               
            }
            



        }
    }
}
