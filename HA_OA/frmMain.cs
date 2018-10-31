using System;
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
    public partial class frmMain : Form
    {

        frmOverTime OT;
        frmLeaveInfo LeaveI;
        public frmMain()
        {
            InitializeComponent();
        }

        //导入判断网络是否连接的 .dll  
        [DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
        //判断网络状况的方法,返回值true为连接，false为未连接  
        public extern static bool InternetGetConnectedState(out int conState, int reder);

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



        private void btnOTInfo_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            OT = new frmOverTime();
            OT.TopLevel = false;
            OT.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            OT.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(OT);
            OT.Show();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           // OT = new frmOverTime();
        }

        private void btmLeaveInfo_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            LeaveI = new frmLeaveInfo();
            LeaveI.TopLevel = false;
            LeaveI.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            LeaveI.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(LeaveI );
            LeaveI.Show();
        }

        private void btnAllInfo_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            string sql = "select sum(hours) from ha_otinfo";

            MessageBox.Show(p.querySum(p.ConnStr, sql).ToString());


         
        }




        private void gdrawYR(PaintEventArgs e, double ateyr, double ftyr)
        {

            Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的. 

            g.Clear(this.BackColor);

            ////ate
            //Pen p = new Pen(Color.Blue, 25);//定义了一个蓝色,宽度为的画笔        
            //g.DrawEllipse(p, 100, 150, 260, 260);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
            //p = new Pen(color, 1);
            //g.DrawRectangle(p, 70, 120, 320, 320);
            //System.Drawing.Font font = new System.Drawing.Font("Agency FB", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //SolidBrush brush = new SolidBrush(color);
            //g.DrawString(string.Format("{0:P}", ateyr), font, brush, 135F, 240F);

            ////ft
            //p = new Pen(color, 25);//定义了一个蓝色,宽度为的画笔   
            //g.DrawEllipse(p, 450, 150, 260, 260);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为   
            //p = new Pen(color, 1);
            //g.DrawRectangle(p, 420, 120, 320, 320);
            //brush = new SolidBrush(color);
            //g.DrawString(string.Format("{0:P}", ftyr), font, brush, 485F, 240F);
            ////
            //font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //brush = new SolidBrush(Color.Black);
            //g.DrawString("ATE Overall Yield Rate", font, brush, 150F, 100F);
            //g.DrawString("FT Overall Yield Rate", font, brush, 500F, 100F);
        }


    }
}
