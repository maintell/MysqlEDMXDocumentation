namespace MysqlEDMXDocumentation
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Proc = new System.Windows.Forms.Button();
            this.btn_SelectEdmxFilename = new System.Windows.Forms.Button();
            this.txt_connectionString = new System.Windows.Forms.TextBox();
            this.txt_edmxFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Result = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Save);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Proc);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SelectEdmxFilename);
            this.splitContainer1.Panel1.Controls.Add(this.txt_connectionString);
            this.splitContainer1.Panel1.Controls.Add(this.txt_edmxFileName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_Result);
            this.splitContainer1.Size = new System.Drawing.Size(745, 516);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(617, 71);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(116, 33);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Proc
            // 
            this.btn_Proc.Location = new System.Drawing.Point(617, 42);
            this.btn_Proc.Name = "btn_Proc";
            this.btn_Proc.Size = new System.Drawing.Size(116, 30);
            this.btn_Proc.TabIndex = 3;
            this.btn_Proc.Text = "Proc";
            this.btn_Proc.UseVisualStyleBackColor = true;
            this.btn_Proc.Click += new System.EventHandler(this.btn_Proc_Click);
            // 
            // btn_SelectEdmxFilename
            // 
            this.btn_SelectEdmxFilename.Location = new System.Drawing.Point(617, 12);
            this.btn_SelectEdmxFilename.Name = "btn_SelectEdmxFilename";
            this.btn_SelectEdmxFilename.Size = new System.Drawing.Size(116, 33);
            this.btn_SelectEdmxFilename.TabIndex = 2;
            this.btn_SelectEdmxFilename.Text = "Select Edmx File";
            this.btn_SelectEdmxFilename.UseVisualStyleBackColor = true;
            this.btn_SelectEdmxFilename.Click += new System.EventHandler(this.btn_SelectEdmxFilename_Click);
            // 
            // txt_connectionString
            // 
            this.txt_connectionString.Location = new System.Drawing.Point(112, 39);
            this.txt_connectionString.Multiline = true;
            this.txt_connectionString.Name = "txt_connectionString";
            this.txt_connectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_connectionString.Size = new System.Drawing.Size(487, 65);
            this.txt_connectionString.TabIndex = 1;
            this.txt_connectionString.Text = "server=192.168.232.4;user id=root;password=123;persistsecurityinfo=True;database=" +
    "swms";
            // 
            // txt_edmxFileName
            // 
            this.txt_edmxFileName.Location = new System.Drawing.Point(112, 12);
            this.txt_edmxFileName.Name = "txt_edmxFileName";
            this.txt_edmxFileName.Size = new System.Drawing.Size(487, 21);
            this.txt_edmxFileName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "EDMX File Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "MySQL \r\nConnection \r\nString";
            // 
            // txt_Result
            // 
            this.txt_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Result.Location = new System.Drawing.Point(0, 0);
            this.txt_Result.Multiline = true;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ReadOnly = true;
            this.txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Result.Size = new System.Drawing.Size(745, 394);
            this.txt_Result.TabIndex = 0;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(745, 516);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "MySQL EDMX 注释补全工具";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        
      
        //private System.Windows.Forms.Button btn_Proc;
        //private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_edmxFileName;
        private System.Windows.Forms.TextBox txt_connectionString;
        private System.Windows.Forms.Button btn_SelectEdmxFilename;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Proc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Result;
    }
}

