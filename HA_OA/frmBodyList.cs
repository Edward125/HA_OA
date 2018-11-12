using MySql.Data.MySqlClient;
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
            string sql = "select * from ha_bodylist order by sn";
            LoadInfo2Listview(sql, listviewinfo);
            LoadModel(comboQueryModel);
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
        private void LoadModel(ComboBox combobox)
        {
            combobox.Items.Clear();
            string sql = "select * from ha_modellist";
            List<string> model = new List<string>();
            p.QueryDatabase(p.ConnStr, sql, "model", out model);
            foreach (string item in model)
            {
                combobox.Items.Add(item);
            }


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
            listview.Columns.Add("序列号", 60, HorizontalAlignment.Center);
            listview.Columns.Add("型号", 50, HorizontalAlignment.Center);
            listview.Columns.Add("硬件", 60, HorizontalAlignment.Center);
            listview.Columns.Add("服务器IP", 100, HorizontalAlignment.Center);
            listview.Columns.Add("账号", 80, HorizontalAlignment.Center);
            listview.Columns.Add("密码", 80, HorizontalAlignment.Center);
            listview.Columns.Add("更新者", 80, HorizontalAlignment.Center);
            listview.Columns.Add("去向", 200, HorizontalAlignment.Center);
            listview.Columns.Add("备注", 200, HorizontalAlignment.Center);

        }



        private void btnNew_Click(object sender, EventArgs e)
        {
            NewUIChange();


        }


        /// <summary>
        /// 
        /// </summary>
        private bool  UpdateDataBase()
        {
            string sn = txtSN.Text.Trim();
            string model = comboModel.Text.Trim();
            string hwinfo = comboHwInfo.Text.Trim();
            string location = txtLocation.Text.Trim();
            string remark = txtRemark.Text.Trim();
            string ip = txtIP.Text.Trim();
            string id = txtID.Text.Trim();
            string pwd = txtpwd.Text.Trim();
            string sql = "replace into ha_bodylist () values ('" + sn + "','" + model + "','" + hwinfo + "','" +
                location + "','" + @remark + "','" +p.LoginID.Name +"','"+ ip + "','" + id + "','" + pwd + "')";
       
            if (CheckParam())
            {
                DialogResult dr = MessageBox.Show("是否新增数据到数据库？,是请点击是(Y),不是请点击否(N)?", "更新数据库?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string exmsg = string.Empty;
                    if (!p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                    {
                        MessageBox.Show(exmsg, "更新数据库失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("更新数据库成功", "更新数据库成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return true;
                    }

                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckParam()
        {


            if (string.IsNullOrEmpty (txtSN.Text.Trim ()))
            {
                MessageBox.Show("序列号不能为空,请重新输入.", "Not Select", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtSN.Focus();
                return false ;
            }


            if (comboHwInfo.SelectedIndex == -1)
            {
                MessageBox.Show("请选择硬件信息.", "Not Select", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                comboHwInfo.Focus();
                return false;
            }

            if (comboModel.SelectedIndex == -1)
            {
                MessageBox.Show("请选择型号信息.", "Not Select", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                comboModel.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtLocation.Text.Trim ()))
            {
                MessageBox.Show("设备去向不能为空,请重新输入.", "Not Select", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtLocation.Focus();
                return false;
            }



            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        private void NewUIChange()
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

                if (UpdateDataBase())
                {
                    SaveOKUI();
                    string   sql = "select * from ha_bodylist order by sn";
                    LoadInfo2Listview(sql, listviewinfo);
                }
      
                //string sn = txtSN.Text.Trim();
                //string model = comboModel.Text.Trim();
                //string hwinfo = comboHwInfo.Text.Trim();
                //string location = txtLocation.Text.Trim();
                //string remark = txtRemark.Text.Trim();
                //string ip = txtIP.Text.Trim();
                //string id = txtID.Text.Trim();
                //string pwd = txtpwd.Text.Trim();
                //string sql = "replace into ha_bodylist () values ('" + sn + "','" + model + "','" + hwinfo + "','" +
                //      location + "','" + @remark + "','" + p.LoginID.Name + "','" + ip + "','" + id + "','" + pwd + "')";
                //if (CheckParam())
                //{
                //    DialogResult dr = MessageBox.Show("是否新增数据到数据库？,是请点击是(Y),不是请点击否(N)?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (dr == DialogResult.Yes)
                //    {
                //        string exmsg = string.Empty;
                //        if (!p.InsertDate2Database(p.ConnStr, sql, out exmsg))
                //        {
                //            MessageBox.Show(exmsg, "更新数据库失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //        }
                //        else
                //        {
                //            MessageBox.Show("更新数据库成功", "更新数据库成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //            SaveOKUI();
                //            sql = "select * from ha_bodylist order by sn";
                //           LoadInfo2Listview(sql, listviewinfo);
                           
                //        }

                //    }
                //}
            }

        }



        /// <summary>
        /// 
        /// </summary>
        private void SaveOKUI()
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



        private void EditOKUI()
        {
            btnEdit.Text = "编辑";
            btnNew.Enabled = true;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listview"></param>
        public static void LoadInfo2Listview(string sql, ListView listview)
        {

            listview.Items.Clear();
            listview.BeginUpdate();//数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            MySqlConnection conn = new MySqlConnection(p.ConnStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader re = cmd.ExecuteReader();
                ListViewItem lt = new ListViewItem();
                if (re.HasRows)
                {
                    while (re.Read())
                    {
                        lt = listview.Items.Add(re["sn"].ToString());
                        lt.SubItems.Add(re["model"].ToString());
                        lt.SubItems.Add(re["hwinfo"].ToString());
                        lt.SubItems.Add(re["cmsv6ip"].ToString());
                        lt.SubItems.Add(re["cmsv6id"].ToString());
                        lt.SubItems.Add(re["cmsv6pwd"].ToString());
                        lt.SubItems.Add(re["writer"].ToString());
                        lt.SubItems.Add(re["location"].ToString());
                        lt.SubItems.Add(re["remark"].ToString());

                    }
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }


            listview.EndUpdate();//结束数据处理，UI界面一次性绘制。

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "编辑")
            {
                btnEdit.Text = "保存";
                btnNew.Enabled = false;
                LoadHwInfo();
                LoadModel();
               // txtSN.Text = string.Empty;
                txtSN.ReadOnly = false;
               // txtLocation.Text = string.Empty;
                txtLocation.ReadOnly = false;
              //  txtRemark.Text = string.Empty;
                txtRemark.ReadOnly = false;
              //  txtIP.Text = string.Empty;
                txtIP.ReadOnly = false;
              //  txtID.Text = string.Empty;
                txtID.ReadOnly = false;
               // txtpwd.Text = string.Empty;
                txtpwd.ReadOnly = false;
            }
            else
            {
                if (UpdateDataBase())
                {
                    EditOKUI();
                    string sql = "select * from ha_bodylist order by sn";
                    LoadInfo2Listview(sql, listviewinfo);

                }
 

            }
        }

        private void listviewinfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listviewinfo.SelectedItems.Count > 0)
                {
                    txtSN.Text = listviewinfo.SelectedItems[0].SubItems[0].Text;
                    comboModel.Text = listviewinfo.SelectedItems[0].SubItems[1].Text;
                    comboHwInfo.Text = listviewinfo.SelectedItems[0].SubItems[2].Text;
                    txtIP.Text = listviewinfo.SelectedItems[0].SubItems[3].Text;
                    txtID.Text = listviewinfo.SelectedItems[0].SubItems[4].Text;
                    txtpwd.Text = listviewinfo.SelectedItems[0].SubItems[5].Text;
                    txtLocation.Text = listviewinfo.SelectedItems[0].SubItems[7].Text;
                    txtRemark.Text = listviewinfo.SelectedItems[0].SubItems[8].Text;
                }

     
            }
            catch (Exception)
            {
                
               // throw;
            }

           
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string sql = "select * from ha_bodylist order by sn";
            if (string.IsNullOrEmpty(txtQuerySN.Text))
            {
                if (comboQueryModel.SelectedIndex == -1)
                    return;
                else
                    sql = "select * from ha_bodylist where model = '" + comboQueryModel.Text + "' order by sn";
            }
            else
            {
                if (comboQueryModel.SelectedIndex == -1)
                    sql = "select * from ha_bodylist where sn = " + txtQuerySN.Text.Trim() + " order by sn";
                else 
                    sql = "select * from ha_bodylist where sn = " +txtQuerySN.Text.Trim () + " and model = '" + comboQueryModel.Text + "' order by sn";
            }

          LoadInfo2Listview(sql, listviewinfo);
        }




    }
}
