namespace HA_OA
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAllInfo = new System.Windows.Forms.Button();
            this.btnOTInfo = new System.Windows.Forms.Button();
            this.btmLeaveInfo = new System.Windows.Forms.Button();
            this.picOTInfo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picLeaveInfo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picAllInfo = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picBodyList = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picSysSet = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picOTInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeaveInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAllInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBodyList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSysSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 461);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnAllInfo
            // 
            this.btnAllInfo.Location = new System.Drawing.Point(1179, 59);
            this.btnAllInfo.Name = "btnAllInfo";
            this.btnAllInfo.Size = new System.Drawing.Size(95, 47);
            this.btnAllInfo.TabIndex = 1;
            this.btnAllInfo.Text = "信息汇总";
            this.btnAllInfo.UseVisualStyleBackColor = true;
            this.btnAllInfo.Click += new System.EventHandler(this.btnAllInfo_Click);
            // 
            // btnOTInfo
            // 
            this.btnOTInfo.Location = new System.Drawing.Point(1280, 59);
            this.btnOTInfo.Name = "btnOTInfo";
            this.btnOTInfo.Size = new System.Drawing.Size(95, 47);
            this.btnOTInfo.TabIndex = 2;
            this.btnOTInfo.Text = "加班信息";
            this.btnOTInfo.UseVisualStyleBackColor = true;
            this.btnOTInfo.Click += new System.EventHandler(this.btnOTInfo_Click);
            // 
            // btmLeaveInfo
            // 
            this.btmLeaveInfo.Location = new System.Drawing.Point(1391, 59);
            this.btmLeaveInfo.Name = "btmLeaveInfo";
            this.btmLeaveInfo.Size = new System.Drawing.Size(95, 47);
            this.btmLeaveInfo.TabIndex = 3;
            this.btmLeaveInfo.Text = "请假信息";
            this.btmLeaveInfo.UseVisualStyleBackColor = true;
            this.btmLeaveInfo.Click += new System.EventHandler(this.btmLeaveInfo_Click);
            // 
            // picOTInfo
            // 
            this.picOTInfo.BackColor = System.Drawing.Color.Transparent;
            this.picOTInfo.Image = ((System.Drawing.Image)(resources.GetObject("picOTInfo.Image")));
            this.picOTInfo.Location = new System.Drawing.Point(251, 12);
            this.picOTInfo.Name = "picOTInfo";
            this.picOTInfo.Size = new System.Drawing.Size(80, 75);
            this.picOTInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOTInfo.TabIndex = 4;
            this.picOTInfo.TabStop = false;
            this.picOTInfo.Click += new System.EventHandler(this.picOTInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(264, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "加班信息";
            // 
            // picLeaveInfo
            // 
            this.picLeaveInfo.BackColor = System.Drawing.Color.Transparent;
            this.picLeaveInfo.Image = ((System.Drawing.Image)(resources.GetObject("picLeaveInfo.Image")));
            this.picLeaveInfo.Location = new System.Drawing.Point(391, 12);
            this.picLeaveInfo.Name = "picLeaveInfo";
            this.picLeaveInfo.Size = new System.Drawing.Size(80, 75);
            this.picLeaveInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLeaveInfo.TabIndex = 6;
            this.picLeaveInfo.TabStop = false;
            this.picLeaveInfo.Click += new System.EventHandler(this.picLeaveInfo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(404, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "请假信息";
            // 
            // picAllInfo
            // 
            this.picAllInfo.BackColor = System.Drawing.Color.Transparent;
            this.picAllInfo.Image = ((System.Drawing.Image)(resources.GetObject("picAllInfo.Image")));
            this.picAllInfo.Location = new System.Drawing.Point(113, 12);
            this.picAllInfo.Name = "picAllInfo";
            this.picAllInfo.Size = new System.Drawing.Size(80, 75);
            this.picAllInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAllInfo.TabIndex = 8;
            this.picAllInfo.TabStop = false;
            this.picAllInfo.Click += new System.EventHandler(this.picAllInfo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(126, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "信息汇总";
            // 
            // picBodyList
            // 
            this.picBodyList.BackColor = System.Drawing.Color.Transparent;
            this.picBodyList.Image = ((System.Drawing.Image)(resources.GetObject("picBodyList.Image")));
            this.picBodyList.Location = new System.Drawing.Point(516, 12);
            this.picBodyList.Name = "picBodyList";
            this.picBodyList.Size = new System.Drawing.Size(72, 75);
            this.picBodyList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBodyList.TabIndex = 10;
            this.picBodyList.TabStop = false;
            this.picBodyList.Click += new System.EventHandler(this.picBodyList_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(523, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "执法仪清单";
            // 
            // picSysSet
            // 
            this.picSysSet.BackColor = System.Drawing.Color.Transparent;
            this.picSysSet.Image = ((System.Drawing.Image)(resources.GetObject("picSysSet.Image")));
            this.picSysSet.Location = new System.Drawing.Point(641, 12);
            this.picSysSet.Name = "picSysSet";
            this.picSysSet.Size = new System.Drawing.Size(81, 75);
            this.picSysSet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSysSet.TabIndex = 12;
            this.picSysSet.TabStop = false;
            this.picSysSet.Click += new System.EventHandler(this.picSysSet_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(654, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "系统设置";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(969, 576);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picSysSet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picBodyList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picAllInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picLeaveInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picOTInfo);
            this.Controls.Add(this.btmLeaveInfo);
            this.Controls.Add(this.btnOTInfo);
            this.Controls.Add(this.btnAllInfo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picOTInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeaveInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAllInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBodyList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSysSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAllInfo;
        private System.Windows.Forms.Button btnOTInfo;
        private System.Windows.Forms.Button btmLeaveInfo;
        private System.Windows.Forms.PictureBox picOTInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picLeaveInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picAllInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBodyList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picSysSet;
        private System.Windows.Forms.Label label5;
    }
}