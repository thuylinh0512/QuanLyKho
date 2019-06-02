namespace QuanLyKho.View
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPX = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNV = new System.Windows.Forms.Button();
            this.btnKH = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTKXH = new System.Windows.Forms.Button();
            this.btnTKNH = new System.Windows.Forms.Button();
            this.btnTKHH = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.btnPX);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnNV);
            this.groupBox1.Controls.Add(this.btnKH);
            this.groupBox1.Location = new System.Drawing.Point(0, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản Lý";
            // 
            // btnPX
            // 
            this.btnPX.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPX.Location = new System.Drawing.Point(153, 131);
            this.btnPX.Name = "btnPX";
            this.btnPX.Size = new System.Drawing.Size(140, 45);
            this.btnPX.TabIndex = 3;
            this.btnPX.Text = "Phiếu Xuất";
            this.btnPX.UseVisualStyleBackColor = false;
            this.btnPX.Click += new System.EventHandler(this.btnPX_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(153, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Nhà Cung Cấp";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNV
            // 
            this.btnNV.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNV.Location = new System.Drawing.Point(7, 131);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(125, 45);
            this.btnNV.TabIndex = 1;
            this.btnNV.Text = "Nhân Viên";
            this.btnNV.UseVisualStyleBackColor = false;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // btnKH
            // 
            this.btnKH.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnKH.Location = new System.Drawing.Point(7, 44);
            this.btnKH.Name = "btnKH";
            this.btnKH.Size = new System.Drawing.Size(124, 42);
            this.btnKH.TabIndex = 0;
            this.btnKH.Text = "Khách Hàng";
            this.btnKH.UseVisualStyleBackColor = false;
            this.btnKH.Click += new System.EventHandler(this.btnKH_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.btnTKXH);
            this.groupBox2.Controls.Add(this.btnTKNH);
            this.groupBox2.Controls.Add(this.btnTKHH);
            this.groupBox2.Location = new System.Drawing.Point(302, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 205);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống Kê";
            // 
            // btnTKXH
            // 
            this.btnTKXH.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnTKXH.Location = new System.Drawing.Point(16, 157);
            this.btnTKXH.Name = "btnTKXH";
            this.btnTKXH.Size = new System.Drawing.Size(207, 42);
            this.btnTKXH.TabIndex = 0;
            this.btnTKXH.Text = "Xuất Hàng";
            this.btnTKXH.UseVisualStyleBackColor = false;
            this.btnTKXH.Click += new System.EventHandler(this.btnTKXH_Click);
            // 
            // btnTKNH
            // 
            this.btnTKNH.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnTKNH.Location = new System.Drawing.Point(16, 90);
            this.btnTKNH.Name = "btnTKNH";
            this.btnTKNH.Size = new System.Drawing.Size(207, 42);
            this.btnTKNH.TabIndex = 0;
            this.btnTKNH.Text = "Nhập Hàng";
            this.btnTKNH.UseVisualStyleBackColor = false;
            this.btnTKNH.Click += new System.EventHandler(this.btnTKNH_Click);
            // 
            // btnTKHH
            // 
            this.btnTKHH.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnTKHH.Location = new System.Drawing.Point(16, 21);
            this.btnTKHH.Name = "btnTKHH";
            this.btnTKHH.Size = new System.Drawing.Size(207, 42);
            this.btnTKHH.TabIndex = 0;
            this.btnTKHH.Text = "Hàng Hóa";
            this.btnTKHH.UseVisualStyleBackColor = false;
            this.btnTKHH.Click += new System.EventHandler(this.btnTKHH_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(542, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 378);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNV;
        private System.Windows.Forms.Button btnKH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTKXH;
        private System.Windows.Forms.Button btnTKNH;
        private System.Windows.Forms.Button btnTKHH;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}