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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


       
        

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Text = "登陆系统";

            //server=电脑名 或 电脑IP;database=数据库名;userid=数据库登录名;password=数据库登录密码"
            p.ConnStr = "server=" + DES.DesDecrypt(p.DataBaseSeverName, p.dKey) + ";database="
                + DES.DesDecrypt(p.DataBase, p.dKey) + ";userid=" + DES.DesDecrypt(p.DataBaseUid, p.dKey)
                + ";password=" + DES.DesDecrypt(p.DataBasePwd, p.dKey);

            p.LoginID = new p.LoginIDInfo();



            string sql = "SELECT userid FROM ha_user";
            List<string> userid = new List<string>();
            p.QueryDatabase(p.ConnStr, sql, "userid", out userid);
            comboUser.Items.Clear();
            if (userid.Count > 0)
            {
                foreach (string  item in userid )
                {
                    comboUser.Items.Add(item);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {

                if (DES.DesEncrypt(txtPassword.Text.Trim(), p.dKey) == p.LoginID.Password)
                {
                    frmMain f = new frmMain();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Password.,pls retry.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                }
            }
            else
                txtPassword.Focus();
        }

        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboUser.SelectedIndex != -1)
            {
                string sql = "select * from ha_user where userid = '" + comboUser.Text.Trim() + "'";
               // p.QueryDatabase(p.ConnStr, sql, "password", out sPassword);
                p.LoadUserInfo(p.ConnStr, sql, comboUser.Text.Trim(), out p.LoginID);
               
               // p.LoginID.Name = comboUser.Text.Trim();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否确认退出软件,退出点击是(Y),不退出点击否(N)?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Environment.Exit(0);
   
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    if (DES.DesEncrypt(txtPassword.Text.Trim(), p.dKey) == p.LoginID.Password)
                    {
                        frmMain f = new frmMain();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password.,pls retry.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.SelectAll();
                        txtPassword.Focus();
                    }
                }
                else
                    txtPassword.Focus();
            }
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            Form f = new frmAddUser();
           DialogResult result= f.ShowDialog();

           if (f.DialogResult == System.Windows.Forms.DialogResult.Cancel )
           {
               string sql = "SELECT userid FROM ha_user";
               List<string> userid = new List<string>();
               comboUser.Items.Clear();
               p.QueryDatabase(p.ConnStr, sql, "userid", out userid);
               if (userid.Count > 0)
               {
                   foreach (string item in userid)
                   {
                       comboUser.Items.Add(item);
                   }
               }
           }
        }
        
    }
}
