﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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


        //导入判断网络是否连接的 .dll  
        [DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
        //判断网络状况的方法,返回值true为连接，false为未连接  
        public extern static bool InternetGetConnectedState(out int conState, int reder);
        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadUI();
            if (!CheckVersion())
            {
                MessageBox.Show("当前软件版本'" + Application.ProductVersion + "'已不允许运行,请更换版本后重试.", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(0);
            }
        }



        private void LoadUI()
        {

            this.Text = "登陆系统";

            //server=电脑名 或 电脑IP;database=数据库名;userid=数据库登录名;password=数据库登录密码"
            p.ConnStr = "server=" + DES.DesDecrypt(p.DataBaseSeverName, p.dKey) + ";database="
                + DES.DesDecrypt(p.DataBase, p.dKey) + ";userid=" + DES.DesDecrypt(p.DataBaseUid, p.dKey)
                + ";password=" + DES.DesDecrypt(p.DataBasePwd, p.dKey);
            LoadUser();

        }


        private void LoadUser()
        {
            p.LoginID = new p.LoginIDInfo();
            string sql = "SELECT userid FROM ha_user";
            List<string> userid = new List<string>();
            p.QueryDatabase(p.ConnStr, sql, "userid", out userid);
            comboUser.Items.Clear();
            if (userid.Count > 0)
            {
                foreach (string item in userid)
                {
                    comboUser.Items.Add(item);
                }
            }
        }



        /// <summary>
        /// 检查当前版本是否允许运行
        /// </summary>
        /// <returns></returns>
        private bool CheckVersion()
        {
            string sql = "select isrun from ha_oa_version where version = '" + Application.ProductVersion + "'";
            string result = string.Empty ;
            if (p.QueryDatabase(p.ConnStr, sql, "isrun", out result))
            {
                if (result == "1")
                    return true;
            }
            return false;


        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
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
              Login();
   
            }
        }



        private void Login()
        {
            int connstate = -1;
            if (!InternetGetConnectedState(out connstate, 0))
            {
                MessageBox.Show("当前电脑未连入网络,请确认后重试", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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


        private void btnRegist_Click(object sender, EventArgs e)
        {
            Form f = new frmAddUser();
           DialogResult result= f.ShowDialog();

           if (f.DialogResult == System.Windows.Forms.DialogResult.Cancel )
           {
               LoadUser();
           }
        }
        
    }
}
