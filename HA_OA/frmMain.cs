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
    public partial class frmMain : Form
    {

        frmOverTime OT;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOTInfo_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //     this.panel1.Controls.Clear();  // 清空原有的控件
            //w1.TopLevel = false;  // 非顶级窗口
            //w1.FormBorderStyle = FormBorderStyle.None;  // 不显示标题栏
            //w1.Dock = System.Windows.Forms.DockStyle.Fill;  // 填充panel
            //this.panel1.Controls.Add(w1);  // 添加w1窗体
            //w1.Show()
            OT.TopLevel = false;
            OT.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            OT.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(OT);
            OT.Show();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            OT = new frmOverTime();
        }

    }
}
