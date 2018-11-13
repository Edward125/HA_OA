namespace HA_OA
{
    partial class frmSysSet
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabUserSet = new System.Windows.Forms.TabPage();
            this.tabBodySet = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabMain.SuspendLayout();
            this.tabBodySet.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabUserSet);
            this.tabMain.Controls.Add(this.tabBodySet);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(940, 437);
            this.tabMain.TabIndex = 0;
            // 
            // tabUserSet
            // 
            this.tabUserSet.Location = new System.Drawing.Point(4, 22);
            this.tabUserSet.Name = "tabUserSet";
            this.tabUserSet.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserSet.Size = new System.Drawing.Size(932, 411);
            this.tabUserSet.TabIndex = 0;
            this.tabUserSet.Text = "用户管理";
            this.tabUserSet.UseVisualStyleBackColor = true;
            // 
            // tabBodySet
            // 
            this.tabBodySet.Controls.Add(this.groupBox2);
            this.tabBodySet.Controls.Add(this.groupBox1);
            this.tabBodySet.Location = new System.Drawing.Point(4, 22);
            this.tabBodySet.Name = "tabBodySet";
            this.tabBodySet.Size = new System.Drawing.Size(932, 411);
            this.tabBodySet.TabIndex = 1;
            this.tabBodySet.Text = "执法仪硬件平台管理";
            this.tabBodySet.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(17, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 386);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "执法仪型号管理";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(276, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 386);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "执法仪型号管理";
            // 
            // frmSysSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 461);
            this.Controls.Add(this.tabMain);
            this.Name = "frmSysSet";
            this.Text = "frmSysSet";
            this.tabMain.ResumeLayout(false);
            this.tabBodySet.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabUserSet;
        private System.Windows.Forms.TabPage tabBodySet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}