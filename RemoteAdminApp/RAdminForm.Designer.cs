namespace RemoteAdminApp
{
    partial class RAdminForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbHostInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtbHostInfo
            // 
            this.txtbHostInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbHostInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbHostInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbHostInfo.Location = new System.Drawing.Point(0, 0);
            this.txtbHostInfo.Multiline = true;
            this.txtbHostInfo.Name = "txtbHostInfo";
            this.txtbHostInfo.ReadOnly = true;
            this.txtbHostInfo.Size = new System.Drawing.Size(434, 151);
            this.txtbHostInfo.TabIndex = 0;
            // 
            // RAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 151);
            this.Controls.Add(this.txtbHostInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RAdminForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoteAdmin beta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbHostInfo;
    }
}

