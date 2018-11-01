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
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            ResetUI();
        }

        private void ResetUI()
        {
            comboDep.SelectedIndex = -1;
            txtUserName.Text = string.Empty;
            txtPassword1.Text = string.Empty;
            txtPassword2.Text = string.Empty;
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {

            p.ConnStr = "server=" + DES.DesDecrypt(p.DataBaseSeverName, p.dKey) + ";database="
                  + DES.DesDecrypt(p.DataBase, p.dKey) + ";userid=" + DES.DesDecrypt(p.DataBaseUid, p.dKey)
                   + ";password=" + DES.DesDecrypt(p.DataBasePwd, p.dKey);
   
            string sql = "SELECT depname FROM ha_dep";
            List<string> depname = new List<string>();
            p.QueryDatabase(p.ConnStr, sql, "depname", out depname);
            if (depname.Count > 0)
            {
                foreach (string item in depname)
                {
                    comboDep.Items.Add(item);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(comboDep.SelectedIndex == -1)
            {
                MessageBox.Show ("未选择部门,请重新选择.","Stop",MessageBoxButtons.OK,MessageBoxIcon.Stop );
                comboDep.Focus ();
                return;
            }


            if (string.IsNullOrEmpty (txtUserName.Text.Trim ()))
            {
                MessageBox.Show("用户姓名不能为空,请重新输入.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtUserName.SelectAll();
                txtUserName.Focus();
                return;

            }


            if (string.IsNullOrEmpty(txtPassword1.Text.Trim ()))
            {
                MessageBox.Show("密码不能为空,请重新输入.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPassword1.SelectAll();
                txtPassword1.Focus();
                return;

            }

            if (txtPassword1.Text.Trim () != txtPassword2.Text.Trim ())
            {
                MessageBox.Show("密码1和密码2不相同,请重新输入.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPassword1.SelectAll();
                txtPassword2.SelectAll();
                txtPassword2.Focus();
                return;

            }


            string sql = "insert into ha_user () values ('" + txtUserName.Text.Trim() + "','" +
                DES.DesEncrypt(txtPassword1.Text.Trim(), p.dKey) + "','" + comboDep.Text.Trim() + "',0)";

            string str = string.Empty;
            if (p.InsertDate2Database(p.ConnStr, sql, out str))
            {
                MessageBox.Show("注册账号成功,现在可以使用'" + txtUserName.Text + "'进行登陆.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetUI();
                this.Close();
                //Environment.Exit(0);
            }





            
        }
    }
}
