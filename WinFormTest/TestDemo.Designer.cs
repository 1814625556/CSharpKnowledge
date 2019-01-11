namespace WinFormTest
{
    partial class TestDemo
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B = new System.Windows.Forms.TextBox();
            this.A = new System.Windows.Forms.TextBox();
            this.searchControl1 = new WinFormTest.UIControls.SearchControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(28, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 35);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(513, 823);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.B);
            this.panel1.Controls.Add(this.A);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(1275, 509);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 507);
            this.panel1.TabIndex = 4;
            // 
            // B
            // 
            this.B.Location = new System.Drawing.Point(28, 284);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(100, 28);
            this.B.TabIndex = 4;
            this.B.Enter += new System.EventHandler(this.B_Enter);
            this.B.Leave += new System.EventHandler(this.B_Leave);
            // 
            // A
            // 
            this.A.Location = new System.Drawing.Point(28, 198);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(100, 28);
            this.A.TabIndex = 3;
            this.A.MouseEnter += new System.EventHandler(this.A_MouseEnter);
            this.A.MouseLeave += new System.EventHandler(this.A_MouseLeave);
            // 
            // searchControl1
            // 
            this.searchControl1.InnerText = null;
            this.searchControl1.Location = new System.Drawing.Point(28, 173);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Size = new System.Drawing.Size(1470, 259);
            this.searchControl1.TabIndex = 0;
            this.searchControl1.UserControlBtnClicked += new WinFormTest.UIControls.SearchControl.BtnClickHandle(this.UserDefinationClick);
            // 
            // TestDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2189, 1269);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchControl1);
            this.Name = "TestDemo";
            this.Text = "TestDemo";
            this.Load += new System.EventHandler(this.TestDemo_Load);
            this.Shown += new System.EventHandler(this.TestDemo_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UIControls.SearchControl searchControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox B;
        private System.Windows.Forms.TextBox A;
    }
}