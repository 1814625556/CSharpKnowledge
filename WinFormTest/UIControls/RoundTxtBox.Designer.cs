namespace WinFormTest.UIControls
{
    partial class RoundTxtBox
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.InnerTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InnerTextbox
            // 
            this.InnerTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InnerTextbox.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InnerTextbox.Location = new System.Drawing.Point(26, 12);
            this.InnerTextbox.Multiline = true;
            this.InnerTextbox.Name = "InnerTextbox";
            this.InnerTextbox.Size = new System.Drawing.Size(245, 40);
            this.InnerTextbox.TabIndex = 0;
            // 
            // RoundTxtBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.InnerTextbox);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "RoundTxtBox";
            this.Size = new System.Drawing.Size(351, 90);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RoundTxtBox_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InnerTextbox;
    }
}
