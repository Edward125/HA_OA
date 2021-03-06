﻿using System;
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




        /// <summary>
        /// 
        /// </summary>
        /// <param name="listbox"></param>
        private void LoadInfo(string sql, string querykey,ListBox listbox)
        {
            listbox.Items.Clear();
            List<string> listversion = new List<string>();
            p.QueryDatabase(p.ConnStr, sql, querykey, out listversion);
            if (listversion.Count > 0)
            {
                foreach (string item in listversion)
                {
                    listbox.Items.Add(item);
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        private void LoadHwinfo()
        {
            string sql = "select * from ha_hwinfo";
            LoadInfo(sql,"hwinfo", lsthwinfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadModel()
        {
            string sql = "select * from ha_modellist";
            LoadInfo(sql,"model", lstmodel);
        }


        /// <summary>
        /// load department
        /// </summary>
        private void LoadDepartmentInfo()
        {
            comboDepname.Items.Clear();
            string sql = "select *  from ha_dep";

            List<string> listversion = new List<string>();
            p.QueryDatabase(p.ConnStr, sql, "depname", out listversion);
            if (listversion.Count > 0)
            {
                foreach (string item in listversion)
                {
                    comboDepname.Items.Add(item);
                }
                comboDepname.Text = p.LoginID.Department;
            }
        }




        /// <summary>
        /// load department
        /// </summary>
        private void LoadDepartment()
        {
            string sql = "select *  from ha_dep";
            LoadInfo(sql, "depname",lstDepname);
        }





        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {

          if (tabMain.SelectedTab == tabSysSet )
          {
                LoadVersion();
                btnAddVersion.Enabled = false;
                btnDeleteVersion.Enabled = false;
                return;
            }
            if (tabMain.SelectedTab == tabUserSet )
            {
                LoadDepartment();
                LoadDepartment();
                btnAddDep.Enabled = false;
                btnDelDep.Enabled = false;
                txtNewDep.Text = string.Empty;
                txtOldPwd.Text = string.Empty;
                txtNewPwd1.Text = string.Empty;
                txtNewPwd2.Text = string.Empty;
                return;
            }
            if (tabMain.SelectedTab == tabBodySet)
            {
                LoadHwinfo();
                LoadModel();
                txtModel.Text = string.Empty;
                txthwinfo.Text = string.Empty;
                btnDelModel.Enabled = false;
                btnAddModel.Enabled = false;
                btnAddHwinfo.Enabled = false;
                btnDelHwinfo.Enabled = false;
                return;
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
            else
                btnDeleteVersion.Enabled = false;
        }

        private void txtVersion_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVersion.Text.Trim()))
                btnAddVersion.Enabled = true;
            else
                btnAddVersion.Enabled = false;

        }

        private void btnAddVersion_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否添加新的版本号:" + txtVersion.Text.Trim ()+",添加后,该版本的软件可以运行.添加点击是(Y),不添加点击否(N)?", "更新?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void btnDeleteVersion_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否删除版本号:" + lstVersion.SelectedItem.ToString () + ",删除后,该版本的软件不可以运行.确认删除点击是(Y),不删除点击否(N)?", "更新?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string exmsg = string.Empty;

                string sql = "delete from ha_oa_version where version = '" + lstVersion.SelectedItem.ToString() + "'";
                if (p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                {
                    MessageBox.Show("更新数据库成功.", "Update Database Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstVersion.SelectedIndex = -1;
                    LoadVersion();
                }
                else
                {
                    MessageBox.Show("更新数据库失败," + exmsg, "Update Database Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    lstVersion.SelectedIndex = -1;
                }

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtOldPwd.Text = string.Empty;
            txtNewPwd1.Text = string.Empty;
            txtNewPwd2.Text = string.Empty;
            txtOldPwd.Focus();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }


        private void ChangePassword()
        {
            if (string.IsNullOrEmpty(txtOldPwd.Text.Trim()))
            {
                txtOldPwd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNewPwd1.Text.Trim()))
            {
                txtNewPwd1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNewPwd2.Text.Trim()))
            {
                txtNewPwd2.Focus();
                return;
            }

            if (DES.DesEncrypt(txtOldPwd.Text.Trim(), p.dKey) != p.LoginID.Password)
            {
                MessageBox.Show("旧密码不正确,请重新输入.", "密码不正确", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtOldPwd.SelectAll();
                txtOldPwd.Focus();
                return;
            }

            if (txtNewPwd1.Text.Trim() != txtNewPwd2.Text.Trim())
            {
                MessageBox.Show("新密码两次输入不正确,请重新输入.", "密码不正确", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtNewPwd1.SelectAll();
                txtNewPwd1.Focus();
                return;
            }


            DialogResult dr = MessageBox.Show("是否确认更新密码?确认更新点击是(Y),不更新点击否(N)?", "更新?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string exmsg = string.Empty;
                string sql = "update ha_user  set password = '" + DES.DesEncrypt(txtNewPwd1.Text.Trim(), p.dKey) + "' where userid = '" + p.LoginID.Name + "'";
                if (p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                {
                    MessageBox.Show("修改密码成功.", "Update Database Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    p.LoginID.Password = DES.DesEncrypt(txtNewPwd1.Text.Trim(), p.dKey);
                    txtNewPwd1.Text = string.Empty;
                    txtNewPwd2.Text = string.Empty;
                    txtOldPwd.Text = string.Empty;

                }
                else
                {
                    MessageBox.Show("修改密码失败," + exmsg, "Update Database Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }

        private void txtNewPwd2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                ChangePassword();
        }

        private void txtOldPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                ChangePassword();
        }

        private void txtNewPwd1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                ChangePassword();
        }

        private void txtNewDep_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewDep.Text.Trim()))
                btnAddDep.Enabled = true;
            else
                btnAddDep.Enabled = false;
        }

        private void lstDepname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDepname.SelectedIndex != -1)
                btnDelDep.Enabled = true;
            else
                btnDelDep.Enabled = false;
        }

        private void btnAddDep_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否添加新的部门名:" + txtNewDep.Text.Trim () + "?添加点击是(Y),不添加点击否(N)?", "更新?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string exmsg = string.Empty;

                string sql = "insert into ha_dep () values ('" + txtNewDep.Text.Trim() + "')";
                if (p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                {
                    MessageBox.Show("更新数据库成功.", "Update Database Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewDep.Text = string.Empty;
                    LoadDepartment();
                    LoadDepartmentInfo();

                }
                else
                {
                    MessageBox.Show("更新数据库失败," + exmsg, "Update Database Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtNewDep.SelectAll();
                    txtNewDep.Focus();
                }

            }
        }

        private void btnDelDep_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否删部门名:" + lstDepname.SelectedItem.ToString () + "?确认删除点击是(Y),不删除点击否(N)?", "更新?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string exmsg = string.Empty;

                string sql = "delete from ha_dep where depname = '" + lstDepname.SelectedItem.ToString() + "'";
                if (p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                {
                    MessageBox.Show("更新数据库成功.", "Update Database Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstDepname.SelectedIndex = -1;
                    btnDelDep.Enabled = false;
                    LoadDepartment();
                    LoadDepartmentInfo();
                }
                else
                {
                    MessageBox.Show("更新数据库失败," + exmsg, "Update Database Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    lstDepname.SelectedIndex = -1;
                    btnDelDep.Enabled = false;
                }

            }
        }

        private void btnChangeDep_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否确认将" + p.LoginID.Name + "的部门由'" + p.LoginID.Department + "'变更为'" + comboDepname.Text + "'?确认变更点击是(Y),不变更点击否(N)?", "更新?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string exmsg = string.Empty;
                string sql = "update ha_user  set depname = '" + comboDepname.Text + "' where userid = '" + p.LoginID.Name + "'";
                if (p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                {
                    MessageBox.Show("变更部门成功.", "Update Database Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    p.LoginID.Department = comboDepname.Text;
                }
                else
                {
                    MessageBox.Show("变更部门失败," + exmsg, "Update Database Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtModel.Text.Trim ()))
                btnAddModel.Enabled = true ;
            else
                btnAddModel .Enabled = false ;
        }

        private void lstmodel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstmodel.SelectedIndex == -1)
                btnDelModel.Enabled = false;
            else
                btnDelModel.Enabled = true; 
        }

        private void lsthwinfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsthwinfo.SelectedIndex == -1)
                btnDelHwinfo.Enabled = false;
            else
                btnDelHwinfo.Enabled = true;
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否添加新的型号:" + txtNewDep.Text.Trim() + "?添加点击是(Y),不添加点击否(N)?", "更新?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string exmsg = string.Empty;

                string sql = "insert into ha_modellist () values ('" + txtModel.Text.Trim() + "')";
                if (p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                {
                    MessageBox.Show("更新数据库成功.", "Update Database Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtModel.Text = string.Empty;
                    LoadModel();

                }
                else
                {
                    MessageBox.Show("更新数据库失败," + exmsg, "Update Database Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtModel.SelectAll();
                    txtModel.Focus();
                }

            }
        }

        private void btnAddHwinfo_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否添加新的硬件平台:" + txthwinfo.Text.Trim () + "?添加点击是(Y),不添加点击否(N)?", "更新?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string exmsg = string.Empty;

                string sql = "insert into ha_hwinfo () values ('" + txthwinfo.Text.Trim() + "')";
                if (p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                {
                    MessageBox.Show("更新数据库成功.", "Update Database Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txthwinfo.Text = string.Empty;
                    LoadHwinfo();

                }
                else
                {
                    MessageBox.Show("更新数据库失败," + exmsg, "Update Database Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txthwinfo.SelectAll();
                    txthwinfo.Focus();
                }

            }
        }

        private void btnDelModel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否删机种型号:" + lstmodel.SelectedItem.ToString () + "?确认删除点击是(Y),不删除点击否(N)?", "更新?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string exmsg = string.Empty;

                string sql = "delete from ha_modellist where model = '" + lstmodel.SelectedItem.ToString() + "'";
                if (p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                {
                    MessageBox.Show("更新数据库成功.", "Update Database Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstmodel.SelectedIndex = -1;
                    btnDelModel.Enabled = false;
                    LoadModel();
                }
                else
                {
                    MessageBox.Show("更新数据库失败," + exmsg, "Update Database Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    lstmodel.SelectedIndex = -1;
                    btnDelModel.Enabled = false;
                }

            }
        }

        private void btnDelHwinfo_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否删机种硬件平台型号:" + lsthwinfo.SelectedItem.ToString() + "?确认删除点击是(Y),不删除点击否(N)?", "更新?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string exmsg = string.Empty;

                string sql = "delete from ha_hwinfo where hwinfo = '" + lsthwinfo.SelectedItem.ToString() + "'";
                if (p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                {
                    MessageBox.Show("更新数据库成功.", "Update Database Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstmodel.SelectedIndex = -1;
                    btnDelHwinfo.Enabled = false;
                    LoadHwinfo();
                }
                else
                {
                    MessageBox.Show("更新数据库失败," + exmsg, "Update Database Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    lstmodel.SelectedIndex = -1;
                    btnDelHwinfo.Enabled = false;
                }

            }
        }

        private void txthwinfo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txthwinfo.Text.Trim()))
                btnAddHwinfo.Enabled = true;
            else
                btnAddHwinfo.Enabled = false;

        }




    }
}
