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
        frmBodyList BodyList;
        public frmMain()
        {
            InitializeComponent();
        }

        //导入判断网络是否连接的 .dll  
        [DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
        //判断网络状况的方法,返回值true为连接，false为未连接  
        public extern static bool InternetGetConnectedState(out int conState, int reder);



        double totalot = 0.0;
        double totalleave = 0.0;

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

            this.Text = "加班请假管理系统(当前用户:" + p.LoginID.Name +") ,Ver:" + Application.ProductVersion;

            string sql = "select sum(hours) from ha_otinfo where username ='" +p.LoginID.Name +"'";
            totalot = p.querySum(p.ConnStr, sql);
            sql = "select sum(hours) from ha_leaveinfo where username ='" + p.LoginID.Name + "'";
            totalleave = p.querySum(p.ConnStr, sql);

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
            string sql =  "select sum(hours) from ha_otinfo where username ='" +p.LoginID.Name +"'";
            totalot = p.querySum(p.ConnStr, sql);
            sql = "select sum(hours) from ha_leaveinfo where username ='" + p.LoginID.Name + "'";
            totalleave = p.querySum(p.ConnStr, sql);


         
        }




        private void gdrawYR(PaintEventArgs e, double ateyr, double ftyr)
        {

            Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的. 
            g.Clear(this.BackColor);


        }


        private void gDrawInfo(PaintEventArgs e, double totalot, double totalleave)
        {

            Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的. 
            g.Clear(this.BackColor);
            Pen p = new Pen(Color.Blue  , 1);//定义了一个蓝色,宽度为的画笔    
            //g.DrawEllipse(p, 40, 150, 250, 250);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
            g.DrawRectangle(p, 56, 86, 220, 250);
           
            System.Drawing.Font font = new System.Drawing.Font("Agency FB", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SolidBrush brush = new SolidBrush(Color.Blue  );
            g.DrawString(string.Format("{0:F}", totalot), font, brush, 70F, 202F);


             p = new Pen(Color.LimeGreen , 1);//定义了一个蓝色,宽度为的画笔    
            // g.DrawEllipse(p, 400, 86, 200, 250);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
             g.DrawRectangle(p, 361, 86, 220, 250);
            font = new System.Drawing.Font("Agency FB", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
             brush = new SolidBrush(Color.LimeGreen );
            g.DrawString(string.Format("{0:F}", totalleave ), font, brush, 376F, 202F);


            p = new Pen(Color.OrangeRed , 1);//定义了一个蓝色,宽度为的画笔    
           // g.DrawEllipse(p, 700, 150, 250, 250);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
            g.DrawRectangle(p, 666, 86, 220, 250);
            font = new System.Drawing.Font("Agency FB", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            brush = new SolidBrush(Color.Red);
            g.DrawString(string.Format("{0:F}", (totalot-totalleave )), font, brush, 681F, 202F);

            //
            font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            brush = new SolidBrush(Color.Black);
            g.DrawString("加班总时数", font, brush, 112F, 134F);
            g.DrawString("请假总时数", font, brush, 417F, 134F);
            g.DrawString("结余总时数", font, brush, 722F, 134F);

        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            gDrawInfo(e, totalot , totalleave );

        }

        private void picAllInfo_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            string sql = "select sum(hours) from ha_otinfo where username ='" + p.LoginID.Name + "'";
            totalot = p.querySum(p.ConnStr, sql);
            sql = "select sum(hours) from ha_leaveinfo where username ='" + p.LoginID.Name + "'";
            totalleave = p.querySum(p.ConnStr, sql);
        }

        private void picOTInfo_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            OT = new frmOverTime();
            OT.TopLevel = false;
            OT.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            OT.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(OT);
            OT.Show();

        }

        private void picLeaveInfo_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            LeaveI = new frmLeaveInfo();
            LeaveI.TopLevel = false;
            LeaveI.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            LeaveI.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(LeaveI);
            LeaveI.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否确认退出软件,退出点击是(Y),不退出点击否(N)?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
                e.Cancel = true;
        }

        private void picBodyList_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            BodyList = new frmBodyList();
            BodyList.TopLevel = false;
            BodyList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BodyList.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(BodyList);
            BodyList.Show();

        }




    }
}
