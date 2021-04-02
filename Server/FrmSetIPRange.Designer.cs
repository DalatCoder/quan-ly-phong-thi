namespace Server
{
    partial class FrmSetIPRange
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIPBegin = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSubnetMask = new System.Windows.Forms.TextBox();
            this.txtIpEnd = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSubmit2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClientNumbers = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP đầu tiên:";
            // 
            // txtIPBegin
            // 
            this.txtIPBegin.Location = new System.Drawing.Point(93, 27);
            this.txtIPBegin.Name = "txtIPBegin";
            this.txtIPBegin.Size = new System.Drawing.Size(205, 23);
            this.txtIPBegin.TabIndex = 2;
            this.txtIPBegin.Text = "192.168.255.1";
            this.txtIPBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSubnetMask);
            this.groupBox1.Controls.Add(this.txtIpEnd);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIPBegin);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 158);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin các máy con";
            // 
            // txtSubnetMask
            // 
            this.txtSubnetMask.Location = new System.Drawing.Point(93, 90);
            this.txtSubnetMask.Name = "txtSubnetMask";
            this.txtSubnetMask.Size = new System.Drawing.Size(205, 23);
            this.txtSubnetMask.TabIndex = 9;
            this.txtSubnetMask.Text = "255.255.255.0";
            this.txtSubnetMask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIpEnd
            // 
            this.txtIpEnd.Location = new System.Drawing.Point(93, 58);
            this.txtIpEnd.Name = "txtIpEnd";
            this.txtIpEnd.Size = new System.Drawing.Size(205, 23);
            this.txtIpEnd.TabIndex = 8;
            this.txtIpEnd.Text = "192.168.255.60";
            this.txtIpEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(9, 123);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(289, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Xác nhận";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subnet Mask:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP cuối cùng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSubmit2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtClientNumbers);
            this.groupBox2.Location = new System.Drawing.Point(12, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 91);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhập số lượng máy con";
            // 
            // btnSubmit2
            // 
            this.btnSubmit2.Location = new System.Drawing.Point(6, 56);
            this.btnSubmit2.Name = "btnSubmit2";
            this.btnSubmit2.Size = new System.Drawing.Size(292, 23);
            this.btnSubmit2.TabIndex = 7;
            this.btnSubmit2.Text = "Xác nhận";
            this.btnSubmit2.UseVisualStyleBackColor = true;
            this.btnSubmit2.Click += new System.EventHandler(this.btnSubmit2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Số máy con:";
            // 
            // txtClientNumbers
            // 
            this.txtClientNumbers.Location = new System.Drawing.Point(93, 27);
            this.txtClientNumbers.Name = "txtClientNumbers";
            this.txtClientNumbers.Size = new System.Drawing.Size(205, 23);
            this.txtClientNumbers.TabIndex = 2;
            this.txtClientNumbers.Text = "50";
            this.txtClientNumbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmSetIPRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 277);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "FrmSetIPRange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn vùng IP của các máy con";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPBegin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtSubnetMask;
        private System.Windows.Forms.TextBox txtIpEnd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSubmit2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClientNumbers;
    }
}