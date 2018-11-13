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
            this.tabSysSet = new System.Windows.Forms.TabPage();
            this.btnDeleteVersion = new System.Windows.Forms.Button();
            this.btnAddVersion = new System.Windows.Forms.Button();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lstVersion = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.txtNewPwd1 = new System.Windows.Forms.TextBox();
            this.txtNewPwd2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboDepname = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lstDepname = new System.Windows.Forms.ListBox();
            this.txtNewDep = new System.Windows.Forms.TextBox();
            this.btnAddDep = new System.Windows.Forms.Button();
            this.btnDelDep = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabUserSet.SuspendLayout();
            this.tabBodySet.SuspendLayout();
            this.tabSysSet.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabSysSet);
            this.tabMain.Controls.Add(this.tabUserSet);
            this.tabMain.Controls.Add(this.tabBodySet);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(940, 437);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabUserSet
            // 
            this.tabUserSet.Controls.Add(this.groupBox5);
            this.tabUserSet.Controls.Add(this.groupBox4);
            this.tabUserSet.Controls.Add(this.groupBox3);
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
            // tabSysSet
            // 
            this.tabSysSet.Controls.Add(this.label2);
            this.tabSysSet.Controls.Add(this.label1);
            this.tabSysSet.Controls.Add(this.btnDeleteVersion);
            this.tabSysSet.Controls.Add(this.btnAddVersion);
            this.tabSysSet.Controls.Add(this.txtVersion);
            this.tabSysSet.Controls.Add(this.lstVersion);
            this.tabSysSet.Location = new System.Drawing.Point(4, 22);
            this.tabSysSet.Name = "tabSysSet";
            this.tabSysSet.Size = new System.Drawing.Size(932, 411);
            this.tabSysSet.TabIndex = 2;
            this.tabSysSet.Text = "系统设置";
            this.tabSysSet.UseVisualStyleBackColor = true;
            // 
            // btnDeleteVersion
            // 
            this.btnDeleteVersion.Location = new System.Drawing.Point(158, 121);
            this.btnDeleteVersion.Name = "btnDeleteVersion";
            this.btnDeleteVersion.Size = new System.Drawing.Size(108, 32);
            this.btnDeleteVersion.TabIndex = 7;
            this.btnDeleteVersion.Text = "删除版本号";
            this.btnDeleteVersion.UseVisualStyleBackColor = true;
            this.btnDeleteVersion.Click += new System.EventHandler(this.btnDeleteVersion_Click);
            // 
            // btnAddVersion
            // 
            this.btnAddVersion.Location = new System.Drawing.Point(158, 83);
            this.btnAddVersion.Name = "btnAddVersion";
            this.btnAddVersion.Size = new System.Drawing.Size(108, 32);
            this.btnAddVersion.TabIndex = 6;
            this.btnAddVersion.Text = "添加版本号";
            this.btnAddVersion.UseVisualStyleBackColor = true;
            this.btnAddVersion.Click += new System.EventHandler(this.btnAddVersion_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(158, 56);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(108, 21);
            this.txtVersion.TabIndex = 5;
            this.txtVersion.TextChanged += new System.EventHandler(this.txtVersion_TextChanged);
            // 
            // lstVersion
            // 
            this.lstVersion.FormattingEnabled = true;
            this.lstVersion.ItemHeight = 12;
            this.lstVersion.Location = new System.Drawing.Point(15, 35);
            this.lstVersion.Name = "lstVersion";
            this.lstVersion.Size = new System.Drawing.Size(137, 124);
            this.lstVersion.TabIndex = 4;
            this.lstVersion.SelectedIndexChanged += new System.EventHandler(this.lstVersion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "当前可用版本号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "新版本号";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnModify);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtNewPwd2);
            this.groupBox3.Controls.Add(this.txtNewPwd1);
            this.groupBox3.Controls.Add(this.txtOldPwd);
            this.groupBox3.Location = new System.Drawing.Point(15, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 172);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "密码修改";
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(78, 24);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(142, 21);
            this.txtOldPwd.TabIndex = 1;
            this.txtOldPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOldPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOldPwd_KeyPress);
            // 
            // txtNewPwd1
            // 
            this.txtNewPwd1.Location = new System.Drawing.Point(77, 58);
            this.txtNewPwd1.Name = "txtNewPwd1";
            this.txtNewPwd1.PasswordChar = '*';
            this.txtNewPwd1.Size = new System.Drawing.Size(142, 21);
            this.txtNewPwd1.TabIndex = 2;
            this.txtNewPwd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewPwd1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPwd1_KeyPress);
            // 
            // txtNewPwd2
            // 
            this.txtNewPwd2.Location = new System.Drawing.Point(76, 92);
            this.txtNewPwd2.Name = "txtNewPwd2";
            this.txtNewPwd2.PasswordChar = '*';
            this.txtNewPwd2.Size = new System.Drawing.Size(142, 21);
            this.txtNewPwd2.TabIndex = 3;
            this.txtNewPwd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewPwd2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPwd2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "旧密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "新密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "确认新密码";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(15, 129);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(91, 31);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "确认修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(127, 129);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(91, 31);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.btnDelDep);
            this.groupBox4.Controls.Add(this.btnAddDep);
            this.groupBox4.Controls.Add(this.txtNewDep);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.lstDepname);
            this.groupBox4.Location = new System.Drawing.Point(269, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(271, 276);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "部门增删";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.comboDepname);
            this.groupBox5.Location = new System.Drawing.Point(15, 193);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(239, 98);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "部门修改";
            // 
            // comboDepname
            // 
            this.comboDepname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDepname.FormattingEnabled = true;
            this.comboDepname.Location = new System.Drawing.Point(65, 27);
            this.comboDepname.Name = "comboDepname";
            this.comboDepname.Size = new System.Drawing.Size(153, 20);
            this.comboDepname.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 31);
            this.button1.TabIndex = 7;
            this.button1.Text = "确认修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "部门列表";
            // 
            // lstDepname
            // 
            this.lstDepname.FormattingEnabled = true;
            this.lstDepname.ItemHeight = 12;
            this.lstDepname.Location = new System.Drawing.Point(6, 32);
            this.lstDepname.Name = "lstDepname";
            this.lstDepname.Size = new System.Drawing.Size(139, 232);
            this.lstDepname.TabIndex = 0;
            this.lstDepname.SelectedIndexChanged += new System.EventHandler(this.lstDepname_SelectedIndexChanged);
            // 
            // txtNewDep
            // 
            this.txtNewDep.Location = new System.Drawing.Point(154, 52);
            this.txtNewDep.Name = "txtNewDep";
            this.txtNewDep.Size = new System.Drawing.Size(101, 21);
            this.txtNewDep.TabIndex = 7;
            this.txtNewDep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewDep.TextChanged += new System.EventHandler(this.txtNewDep_TextChanged);
            // 
            // btnAddDep
            // 
            this.btnAddDep.Enabled = false;
            this.btnAddDep.Location = new System.Drawing.Point(154, 79);
            this.btnAddDep.Name = "btnAddDep";
            this.btnAddDep.Size = new System.Drawing.Size(101, 31);
            this.btnAddDep.TabIndex = 7;
            this.btnAddDep.Text = "增加部门名";
            this.btnAddDep.UseVisualStyleBackColor = true;
            this.btnAddDep.Click += new System.EventHandler(this.btnAddDep_Click);
            // 
            // btnDelDep
            // 
            this.btnDelDep.Enabled = false;
            this.btnDelDep.Location = new System.Drawing.Point(154, 116);
            this.btnDelDep.Name = "btnDelDep";
            this.btnDelDep.Size = new System.Drawing.Size(101, 31);
            this.btnDelDep.TabIndex = 8;
            this.btnDelDep.Text = "删除部门名";
            this.btnDelDep.UseVisualStyleBackColor = true;
            this.btnDelDep.Click += new System.EventHandler(this.btnDelDep_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "部门列表";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "新部门名";
            // 
            // frmSysSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 461);
            this.Controls.Add(this.tabMain);
            this.Name = "frmSysSet";
            this.Text = "frmSysSet";
            this.Load += new System.EventHandler(this.frmSysSet_Load);
            this.tabMain.ResumeLayout(false);
            this.tabUserSet.ResumeLayout(false);
            this.tabBodySet.ResumeLayout(false);
            this.tabSysSet.ResumeLayout(false);
            this.tabSysSet.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabUserSet;
        private System.Windows.Forms.TabPage tabBodySet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabSysSet;
        private System.Windows.Forms.Button btnDeleteVersion;
        private System.Windows.Forms.Button btnAddVersion;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.ListBox lstVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewPwd2;
        private System.Windows.Forms.TextBox txtNewPwd1;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboDepname;
        private System.Windows.Forms.ListBox lstDepname;
        private System.Windows.Forms.Button btnDelDep;
        private System.Windows.Forms.Button btnAddDep;
        private System.Windows.Forms.TextBox txtNewDep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}