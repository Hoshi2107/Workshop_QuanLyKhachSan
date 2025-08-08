namespace GUI_QuanLyKhachSan
{
    partial class FrmThongKeTheoPhong
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThongKeTheoPhong));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cbo_MaPhong = new Guna.UI2.WinForms.Guna2ComboBox();
            gnBtn_ThongKe = new Guna.UI2.WinForms.Guna2Button();
            dgvThongKe_phong = new Guna.UI2.WinForms.Guna2DataGridView();
            gnDtp_NgayKT = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            gnDtp_NgayBD = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)dgvThongKe_phong).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(30, 43);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(74, 33);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Phòng:";
            // 
            // cbo_MaPhong
            // 
            cbo_MaPhong.BackColor = Color.Transparent;
            cbo_MaPhong.CustomizableEdges = customizableEdges1;
            cbo_MaPhong.DrawMode = DrawMode.OwnerDrawFixed;
            cbo_MaPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_MaPhong.FocusedColor = Color.FromArgb(94, 148, 255);
            cbo_MaPhong.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbo_MaPhong.Font = new Font("Segoe UI", 10F);
            cbo_MaPhong.ForeColor = Color.FromArgb(68, 88, 112);
            cbo_MaPhong.ItemHeight = 30;
            cbo_MaPhong.Location = new Point(167, 43);
            cbo_MaPhong.Name = "cbo_MaPhong";
            cbo_MaPhong.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbo_MaPhong.Size = new Size(1008, 36);
            cbo_MaPhong.TabIndex = 1;
            cbo_MaPhong.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
            // 
            // gnBtn_ThongKe
            // 
            gnBtn_ThongKe.AutoRoundedCorners = true;
            gnBtn_ThongKe.BorderRadius = 21;
            gnBtn_ThongKe.CustomizableEdges = customizableEdges3;
            gnBtn_ThongKe.DisabledState.BorderColor = Color.DarkGray;
            gnBtn_ThongKe.DisabledState.CustomBorderColor = Color.DarkGray;
            gnBtn_ThongKe.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gnBtn_ThongKe.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gnBtn_ThongKe.FillColor = Color.Cyan;
            gnBtn_ThongKe.Font = new Font("Segoe UI", 9F);
            gnBtn_ThongKe.ForeColor = Color.Black;
            gnBtn_ThongKe.Image = (Image)resources.GetObject("gnBtn_ThongKe.Image");
            gnBtn_ThongKe.ImageAlign = HorizontalAlignment.Left;
            gnBtn_ThongKe.Location = new Point(1046, 234);
            gnBtn_ThongKe.Name = "gnBtn_ThongKe";
            gnBtn_ThongKe.ShadowDecoration.CustomizableEdges = customizableEdges4;
            gnBtn_ThongKe.Size = new Size(135, 44);
            gnBtn_ThongKe.TabIndex = 59;
            gnBtn_ThongKe.Text = "Thống kê";
            gnBtn_ThongKe.Click += gnBtn_ThongKe_Click;
            // 
            // dgvThongKe_phong
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvThongKe_phong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvThongKe_phong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvThongKe_phong.ColumnHeadersHeight = 4;
            dgvThongKe_phong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvThongKe_phong.DefaultCellStyle = dataGridViewCellStyle3;
            dgvThongKe_phong.GridColor = Color.FromArgb(231, 229, 255);
            dgvThongKe_phong.Location = new Point(30, 298);
            dgvThongKe_phong.Name = "dgvThongKe_phong";
            dgvThongKe_phong.RowHeadersVisible = false;
            dgvThongKe_phong.RowHeadersWidth = 51;
            dgvThongKe_phong.Size = new Size(1151, 590);
            dgvThongKe_phong.TabIndex = 60;
            dgvThongKe_phong.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvThongKe_phong.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvThongKe_phong.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvThongKe_phong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvThongKe_phong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvThongKe_phong.ThemeStyle.BackColor = Color.White;
            dgvThongKe_phong.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvThongKe_phong.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvThongKe_phong.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvThongKe_phong.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvThongKe_phong.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvThongKe_phong.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvThongKe_phong.ThemeStyle.HeaderStyle.Height = 4;
            dgvThongKe_phong.ThemeStyle.ReadOnly = false;
            dgvThongKe_phong.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvThongKe_phong.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvThongKe_phong.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvThongKe_phong.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvThongKe_phong.ThemeStyle.RowsStyle.Height = 29;
            dgvThongKe_phong.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvThongKe_phong.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // gnDtp_NgayKT
            // 
            gnDtp_NgayKT.Checked = true;
            gnDtp_NgayKT.CustomizableEdges = customizableEdges5;
            gnDtp_NgayKT.Font = new Font("Segoe UI", 9F);
            gnDtp_NgayKT.Format = DateTimePickerFormat.Long;
            gnDtp_NgayKT.Location = new Point(841, 147);
            gnDtp_NgayKT.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            gnDtp_NgayKT.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            gnDtp_NgayKT.Name = "gnDtp_NgayKT";
            gnDtp_NgayKT.ShadowDecoration.CustomizableEdges = customizableEdges6;
            gnDtp_NgayKT.Size = new Size(340, 45);
            gnDtp_NgayKT.TabIndex = 5;
            gnDtp_NgayKT.Value = new DateTime(2025, 8, 8, 15, 15, 9, 84);
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(705, 147);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(105, 33);
            guna2HtmlLabel3.TabIndex = 4;
            guna2HtmlLabel3.Text = "Đến ngày:";
            // 
            // gnDtp_NgayBD
            // 
            gnDtp_NgayBD.Checked = true;
            gnDtp_NgayBD.CustomizableEdges = customizableEdges7;
            gnDtp_NgayBD.Font = new Font("Segoe UI", 9F);
            gnDtp_NgayBD.Format = DateTimePickerFormat.Long;
            gnDtp_NgayBD.Location = new Point(242, 147);
            gnDtp_NgayBD.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            gnDtp_NgayBD.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            gnDtp_NgayBD.Name = "gnDtp_NgayBD";
            gnDtp_NgayBD.ShadowDecoration.CustomizableEdges = customizableEdges8;
            gnDtp_NgayBD.Size = new Size(340, 45);
            gnDtp_NgayBD.TabIndex = 3;
            gnDtp_NgayBD.Value = new DateTime(2025, 8, 8, 15, 15, 9, 84);
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(30, 147);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(170, 33);
            guna2HtmlLabel2.TabIndex = 2;
            guna2HtmlLabel2.Text = "Bắt đầu từ ngày:";
            // 
            // FrmThongKeTheoPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1238, 923);
            Controls.Add(dgvThongKe_phong);
            Controls.Add(gnBtn_ThongKe);
            Controls.Add(gnDtp_NgayKT);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(gnDtp_NgayBD);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(cbo_MaPhong);
            Controls.Add(guna2HtmlLabel1);
            Name = "FrmThongKeTheoPhong";
            Text = "FrmThongKeTheoPhong";
            Load += FrmThongKeTheoPhong_Load;
            ((System.ComponentModel.ISupportInitialize)dgvThongKe_phong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_MaPhong;
        private Guna.UI2.WinForms.Guna2Button gnBtn_ThongKe;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThongKe_phong;
        private Guna.UI2.WinForms.Guna2DateTimePicker gnDtp_NgayKT;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2DateTimePicker gnDtp_NgayBD;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}