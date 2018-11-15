using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

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


        private void LoadUI()
        {
            comboDep.Items.Clear();
            comboDep.Items.Add(p.LoginID.Department);
            comboDep.SelectedIndex = 0;
           

            SetListView(listviewInfo);
            string sql = "select * from ha_otinfo where username ='" + p.LoginID.Name + "'";
            int totolrecord = 0;
            double totalhours = 0.0;
            LoadInfo2Listview(sql, listviewInfo, out totolrecord, out totalhours);
            txtInfo.Text = "发现" + p.LoginID.Name + "的加班记录" + totolrecord + "条,共计:" + totalhours + "小时";

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

            if (dtpEndTime.Value.Date > dtpStartTime.Value.Date)
            {
                MessageBox.Show("加班填写不能超过一天,请重新选择日期.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            {
                MessageBox.Show("插入数据成功", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHours.Text = string.Empty;
                txtReason.SelectAll();
                txtReason.Focus();
                sql = "select * from ha_otinfo where username ='" + p.LoginID.Name + "'";
                int totolrecord = 0;
                double totalhours = 0.0;
                LoadInfo2Listview(sql, listviewInfo, out totolrecord, out totalhours);
                txtInfo.Text = "发现" + p.LoginID.Name + "的加班记录" + totolrecord + "条,共计:" + totalhours + "小时";
            }

            else
                MessageBox.Show("插入数据失败,详细信息:" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="listview"></param>
        public static  void SetListView(ListView listview)
        {
            listview.Clear();
            listview.View = View.Details;
            listview.MultiSelect = false;
            listview.AutoArrange = true;
            listview.GridLines = true;
            listview.FullRowSelect = true;
            listview.Columns.Add("部门名称", 80, HorizontalAlignment.Center);
            listview.Columns.Add("姓名", 70, HorizontalAlignment.Center);
            listview.Columns.Add("日期", 80, HorizontalAlignment.Center);
            listview.Columns.Add("开始时间", 130, HorizontalAlignment.Center);
            listview.Columns.Add("截至时间", 130, HorizontalAlignment.Center);
            listview.Columns.Add("时数", 50, HorizontalAlignment.Center);
            listview.Columns.Add("填写时间", 130, HorizontalAlignment.Center);
            listview.Columns.Add("事由", 250, HorizontalAlignment.Center);

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="listview"></param>
        public static void LoadInfo2Listview(string sql ,ListView listview)
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
                        lt = listview.Items.Add(re["depname"].ToString());
                        lt.SubItems.Add(re["username"].ToString());
                        lt.SubItems.Add(re["date"].ToString().Replace(" 0:00:00", ""));
                        lt.SubItems.Add(re["starttime"].ToString());
                        lt.SubItems.Add(re["endtime"].ToString());
                        lt.SubItems.Add(re["hours"].ToString());
                        lt.SubItems.Add(re["writetime"].ToString());
                        lt.SubItems.Add(re["reason"].ToString());

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





        /// <summary>
        /// 
        /// </summary>
        /// <param name="listview"></param>
        public static void LoadInfo2Listview(string sql, ListView listview,out int totalrecord,out double totalhours)
        {
            totalrecord = 0;
            totalhours = 0.0;
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
                        totalrecord++;
                        lt = listview.Items.Add(re["depname"].ToString());
                        lt.SubItems.Add(re["username"].ToString());
                        lt.SubItems.Add(re["date"].ToString().Replace(" 0:00:00", ""));
                        lt.SubItems.Add(re["starttime"].ToString());
                        lt.SubItems.Add(re["endtime"].ToString());
                        lt.SubItems.Add(re["hours"].ToString());
                        lt.SubItems.Add(re["writetime"].ToString());
                        lt.SubItems.Add(re["reason"].ToString());
                        totalhours = totalhours + (double)re["hours"];

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



        private void btnQuery_Click(object sender, EventArgs e)
        {
            string sql = "select * from ha_otinfo where date >'" + dtpStartDate.Value.Date + "' and date <'" + dtpEndDate.Value.Date + "' and username ='" + p.LoginID.Name + "'";
            int totolrecord = 0;
            double totalhours = 0.0;
            LoadInfo2Listview(sql, listviewInfo, out totolrecord, out totalhours);
            txtInfo.Text = "发现" + p.LoginID.Name + "的加班记录" + totolrecord + "条,共计:" + totalhours + "小时";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtHours.Text = string.Empty;
            txtReason.Text = string.Empty;
        }

        private void txtReason_DoubleClick(object sender, EventArgs e)
        {
            txtReason.SelectAll();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {

            string destfile = p.LoginID.Name + "加班信息_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            OutPutDataFromListView(listviewInfo, destfile);

        }




        public static void OutPutDataFromListView(ListView listview,string destfile)
        {
            if (listview.Items.Count > 0)
            {
                string tempfile = System.Windows.Forms.Application.StartupPath + @"\sample.xls";
                if (p.downLoadFile(tempfile))
                {

                    Microsoft.Office.Interop.Excel.Application objExcel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook objWorkbook = objExcel.Workbooks.Add(tempfile);
                    //objExcel.Cells[3, 7] = gagedate;
                    //objExcel.Cells[4, 7] = enginner;
                    //objExcel.Cells[5, 7] = model;
                    //objExcel.Cells[6, 7] = machine;
                    //objWorkbook.SaveAs(fileName);

                    //foreach (ListViewItem item in listview.Items)
                    //{
                    //    foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                    //    {
                    //        //MessageBox.Show(subitem.Text);
                    //    }

                    //}

                    for (int i = 0; i < listview.Items.Count ; i++)
                    {
                        for (int j = 0; j < listview.Items[i].SubItems.Count; j++)
                        {
                            System.Windows.Forms.Application.DoEvents();
                            objExcel.Cells[i + 2, j + 1] = listview.Items[i].SubItems[j].Text;

                        }

                    }


                    objExcel.DisplayAlerts = false;
                    objExcel.AlertBeforeOverwriting = false;
                    objWorkbook.SaveAs(destfile);
                    objWorkbook.Close();
                    objExcel.SaveWorkspace();
                   // objExcel.ActiveWorkbook.SaveAs(destfile);
                    objExcel.Quit();
                    objExcel = null;
                    p.KillExcel();
                  DialogResult dr =  MessageBox.Show ("文件:" + destfile +"已输出,保存在" + System.Windows.Forms.Application.StartupPath+",打开文件所在路径,点击是(Y),不打开点击否(N)","输出完成",
                        MessageBoxButtons.YesNoCancel ,MessageBoxIcon.Question );
                  if (dr == DialogResult.Yes)
                  {
                      System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath);
                  }
                }
            }
            else
            {
                MessageBox.Show("未发现有记录,请重新确认.", "无记录", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}
