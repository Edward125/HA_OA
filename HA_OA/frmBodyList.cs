﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HA_OA
{
    public partial class frmBodyList : Form
    {
        public frmBodyList()
        {
            InitializeComponent();
        }

        public static Excel.Application _Excel = null;
        private void frmBodyList_Load(object sender, EventArgs e)
        {
            SetListView(listviewInfo);
            string sql = "select * from ha_bodylist order by sn";
            LoadInfo2Listview(sql, listviewInfo);
            LoadModel(comboQueryModel);
        }



        #region 防止屏幕闪烁
        protected override CreateParams CreateParams
        {
            get
            {

                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }

        }
        #endregion


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
            listview.Columns.Add("型号", 40, HorizontalAlignment.Center);
            listview.Columns.Add("硬件", 60, HorizontalAlignment.Center);
            listview.Columns.Add("服务器IP", 100, HorizontalAlignment.Center);
            listview.Columns.Add("账号", 60, HorizontalAlignment.Center);
            listview.Columns.Add("密码", 60, HorizontalAlignment.Center);
            listview.Columns.Add("更新者", 70, HorizontalAlignment.Center);
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
                    LoadInfo2Listview(sql, listviewInfo);
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
                    LoadInfo2Listview(sql, listviewInfo);

                }
 

            }
        }

        private void listviewinfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listviewInfo.SelectedItems.Count > 0)
                {
                    txtSN.Text = listviewInfo.SelectedItems[0].SubItems[0].Text;
                    comboModel.Text = listviewInfo.SelectedItems[0].SubItems[1].Text;
                    comboHwInfo.Text = listviewInfo.SelectedItems[0].SubItems[2].Text;
                    txtIP.Text = listviewInfo.SelectedItems[0].SubItems[3].Text;
                    txtID.Text = listviewInfo.SelectedItems[0].SubItems[4].Text;
                    txtpwd.Text = listviewInfo.SelectedItems[0].SubItems[5].Text;
                    txtLocation.Text = listviewInfo.SelectedItems[0].SubItems[7].Text;
                    txtRemark.Text = listviewInfo.SelectedItems[0].SubItems[8].Text;
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

          LoadInfo2Listview(sql, listviewInfo);
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            string destfile = System.Windows.Forms.Application.StartupPath + @"\" +  "执法仪清单信息_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            this.Enabled = false;
            OutPutDataFromListView(listviewInfo, destfile);
            this.Enabled = true;
        }

        public static void OutPutDataFromListView(ListView listview, string destfile)
        {

            if (listview.Items.Count > 0)
            {

                  initailExcel();
                //  _Excel = new Excel.Application();
                Excel.Workbook book = null;
                Excel.Worksheet sheet = null;
                //Excel.Range range = null;
                //string tempfile = System.Windows.Forms.Application.StartupPath + @"\sample.xls";
                //if (p.downLoadFile(tempfile))
                //{

                //}

                try
                {
                    //book = _Excel.Workbooks.Open(tempfile);//開啟舊檔案
                    book = _Excel.Workbooks.Add(true);
                    //sheet = (Excel.Worksheet)book.Sheets[1];//指定活頁簿,代表Sheet1 
                    sheet = (Excel.Worksheet)book.Sheets["Sheet1"];//也可以直接指定工作表名稱 

                    sheet.Cells[1, 1] = "序列号";
                    sheet.Cells[1, 2] = "型号";
                    sheet.Cells[1, 3] = "硬件";
                    sheet.Cells[1, 4] = "服务器IP";
                    sheet.Cells[1, 5] = "账号";
                    sheet.Cells[1, 6] = "密码";
                    sheet.Cells[1, 7] = "更新者";
                    sheet.Cells[1, 8] = "去向";
                    sheet.Cells[1, 9] = "备注";
                    sheet.Columns["F:F"].NumberFormatLocal = "@";

                    for (int i = 0; i < listview.Items.Count; i++)
                    {
                        for (int j = 0; j < listview.Items[i].SubItems.Count; j++)
                        {
                            System.Windows.Forms.Application.DoEvents();
                            sheet.Cells[i + 2, j + 1] = listview.Items[i].SubItems[j].Text;
                        }
                    }
                    _Excel.AlertBeforeOverwriting = false;

                    sheet.UsedRange.HorizontalAlignment = XlVAlign.xlVAlignCenter;
                    sheet.UsedRange.Font.Size = 9;
                    sheet.UsedRange.Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlThin;//
                    sheet.UsedRange.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    sheet.UsedRange.Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThin;//
                    sheet.UsedRange.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    sheet.UsedRange.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;//
                    sheet.UsedRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    sheet.UsedRange.Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;//
                    sheet.UsedRange.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    sheet.UsedRange.Borders[XlBordersIndex.xlInsideHorizontal].Weight = XlBorderWeight.xlThin;//
                    sheet.UsedRange.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                    sheet.UsedRange.Borders[XlBordersIndex.xlInsideVertical].Weight = XlBorderWeight.xlThin;//
                    sheet.UsedRange.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
                    sheet.Columns.AutoFit();
                    book.SaveAs(destfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    DialogResult dr = MessageBox.Show("文件:" + destfile + "已输出,保存在" + System.Windows.Forms.Application.StartupPath + ",打开文件所在路径,点击是(Y),不打开点击否(N)", "输出完成",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath);
                    }
                }
                finally
                {
                    book.Close();
                    book = null;
                    // p.KillExcel();
                }
            }
            else
            {
                MessageBox.Show("未发现有记录,请重新确认.", "无记录", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public static void initailExcel()
        {
            //檢查PC有無Excel在執行
            bool flag = false;
            foreach (var item in Process.GetProcesses())
            {
                if (item.ProcessName == "EXCEL")
                {
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                _Excel = new Excel.Application();
            }
            else
            {
                object obj = Marshal.GetActiveObject("Excel.Application");//引用已在執行的Excel
                _Excel = obj as Excel.Application;
            }

            _Excel.Visible = false;//設false效能會比較好
        }




    }
}
