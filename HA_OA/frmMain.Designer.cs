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
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 461);
            this.panel1.TabIndex = 0;
            // 
            // btnAllInfo
            // 
            this.btnAllInfo.Location = new System.Drawing.Point(56, 12);
            this.btnAllInfo.Name = "btnAllInfo";
            this.btnAllInfo.Size = new System.Drawing.Size(95, 47);
            this.btnAllInfo.TabIndex = 1;
            this.btnAllInfo.Text = "信息汇总";
            this.btnAllInfo.UseVisualStyleBackColor = true;
            this.btnAllInfo.Click += new System.EventHandler(this.btnAllInfo_Click);
            // 
            // btnOTInfo
            // 
            this.btnOTInfo.Location = new System.Drawing.Point(206, 12);
            this.btnOTInfo.Name = "btnOTInfo";
            this.btnOTInfo.Size = new System.Drawing.Size(95, 47);
            this.btnOTInfo.TabIndex = 2;
            this.btnOTInfo.Text = "加班信息";
            this.btnOTInfo.UseVisualStyleBackColor = true;
            this.btnOTInfo.Click += new System.EventHandler(this.btnOTInfo_Click);
            // 
            // btmLeaveInfo
            // 
            this.btmLeaveInfo.Location = new System.Drawing.Point(346, 12);
            this.btmLeaveInfo.Name = "btmLeaveInfo";
            this.btmLeaveInfo.Size = new System.Drawing.Size(95, 47);
            this.btmLeaveInfo.TabIndex = 3;
            this.btmLeaveInfo.Text = "请假信息";
            this.btmLeaveInfo.UseVisualStyleBackColor = true;
            this.btmLeaveInfo.Click += new System.EventHandler(this.btmLeaveInfo_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(970, 526);
            this.Controls.Add(this.btmLeaveInfo);
            this.Controls.Add(this.btnOTInfo);
            this.Controls.Add(this.btnAllInfo);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAllInfo;
        private System.Windows.Forms.Button btnOTInfo;
        private System.Windows.Forms.Button btmLeaveInfo;
    }
}