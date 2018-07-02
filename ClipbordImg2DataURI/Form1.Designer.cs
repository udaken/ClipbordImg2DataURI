namespace ClipbordImg2DataURI
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.scale100Percent = new System.Windows.Forms.RadioButton();
            this.scale50Percent = new System.Windows.Forms.RadioButton();
            this.scale25Percent = new System.Windows.Forms.RadioButton();
            this.scale12Percent = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.outputFormatPng8 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.outputFormatJpeg = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(8, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 640);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyButton.Enabled = false;
            this.copyButton.Location = new System.Drawing.Point(551, 734);
            this.copyButton.Margin = new System.Windows.Forms.Padding(2);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(98, 29);
            this.copyButton.TabIndex = 1;
            this.copyButton.Text = "&Copy data URI";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(8, 653);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(384, 41);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "縮小";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.scale100Percent);
            this.flowLayoutPanel1.Controls.Add(this.scale50Percent);
            this.flowLayoutPanel1.Controls.Add(this.scale25Percent);
            this.flowLayoutPanel1.Controls.Add(this.scale12Percent);
            this.flowLayoutPanel1.Controls.Add(this.checkBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 14);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(380, 25);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // scale100Percent
            // 
            this.scale100Percent.AutoSize = true;
            this.scale100Percent.Checked = true;
            this.scale100Percent.Location = new System.Drawing.Point(2, 2);
            this.scale100Percent.Margin = new System.Windows.Forms.Padding(2);
            this.scale100Percent.Name = "scale100Percent";
            this.scale100Percent.Size = new System.Drawing.Size(47, 16);
            this.scale100Percent.TabIndex = 0;
            this.scale100Percent.TabStop = true;
            this.scale100Percent.Text = "100%";
            this.scale100Percent.UseVisualStyleBackColor = true;
            this.scale100Percent.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // scale50Percent
            // 
            this.scale50Percent.AutoSize = true;
            this.scale50Percent.Location = new System.Drawing.Point(53, 2);
            this.scale50Percent.Margin = new System.Windows.Forms.Padding(2);
            this.scale50Percent.Name = "scale50Percent";
            this.scale50Percent.Size = new System.Drawing.Size(41, 16);
            this.scale50Percent.TabIndex = 1;
            this.scale50Percent.TabStop = true;
            this.scale50Percent.Text = "50%";
            this.scale50Percent.UseVisualStyleBackColor = true;
            this.scale50Percent.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // scale25Percent
            // 
            this.scale25Percent.AutoSize = true;
            this.scale25Percent.Location = new System.Drawing.Point(98, 2);
            this.scale25Percent.Margin = new System.Windows.Forms.Padding(2);
            this.scale25Percent.Name = "scale25Percent";
            this.scale25Percent.Size = new System.Drawing.Size(41, 16);
            this.scale25Percent.TabIndex = 2;
            this.scale25Percent.TabStop = true;
            this.scale25Percent.Text = "25%";
            this.scale25Percent.UseVisualStyleBackColor = true;
            this.scale25Percent.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // scale12Percent
            // 
            this.scale12Percent.AutoSize = true;
            this.scale12Percent.Location = new System.Drawing.Point(143, 2);
            this.scale12Percent.Margin = new System.Windows.Forms.Padding(2);
            this.scale12Percent.Name = "scale12Percent";
            this.scale12Percent.Size = new System.Drawing.Size(49, 16);
            this.scale12Percent.TabIndex = 4;
            this.scale12Percent.TabStop = true;
            this.scale12Percent.Text = "12.5%";
            this.scale12Percent.UseVisualStyleBackColor = true;
            this.scale12Percent.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(196, 2);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "シャープネスフィルター";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.outputFormatJpeg);
            this.groupBox2.Controls.Add(this.outputFormatPng8);
            this.groupBox2.Location = new System.Drawing.Point(13, 698);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 36);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "画像フォーマット";
            // 
            // outputFormatPng8
            // 
            this.outputFormatPng8.AutoSize = true;
            this.outputFormatPng8.Checked = true;
            this.outputFormatPng8.Location = new System.Drawing.Point(6, 14);
            this.outputFormatPng8.Name = "outputFormatPng8";
            this.outputFormatPng8.Size = new System.Drawing.Size(52, 16);
            this.outputFormatPng8.TabIndex = 0;
            this.outputFormatPng8.Text = "PNG8";
            this.outputFormatPng8.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(13, 744);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(379, 19);
            this.textBox1.TabIndex = 4;
            // 
            // radioButton1
            // 
            this.outputFormatJpeg.AutoSize = true;
            this.outputFormatJpeg.Location = new System.Drawing.Point(161, 14);
            this.outputFormatJpeg.Name = "radioButton1";
            this.outputFormatJpeg.Size = new System.Drawing.Size(52, 16);
            this.outputFormatJpeg.TabIndex = 1;
            this.outputFormatJpeg.Text = "JPEG";
            this.outputFormatJpeg.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 770);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ClipbordImg2DataURI";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton scale100Percent;
        private System.Windows.Forms.RadioButton scale50Percent;
        private System.Windows.Forms.RadioButton scale25Percent;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton outputFormatPng8;
        private System.Windows.Forms.RadioButton scale12Percent;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton outputFormatJpeg;
    }
}

