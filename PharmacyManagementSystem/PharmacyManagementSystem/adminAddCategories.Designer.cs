namespace PharmacyManagementSystem
{
    partial class adminAddCategories
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminAddCategories));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addCategory_clear = new System.Windows.Forms.Button();
            this.addCategory_status = new System.Windows.Forms.ComboBox();
            this.addCategory_delete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.addCategory_update = new System.Windows.Forms.Button();
            this.addCategory_add = new System.Windows.Forms.Button();
            this.addCategory_category = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(26, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(567, 618);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // addCategory_clear
            // 
            this.addCategory_clear.BackColor = System.Drawing.Color.SeaGreen;
            this.addCategory_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategory_clear.ForeColor = System.Drawing.Color.White;
            this.addCategory_clear.Location = new System.Drawing.Point(13, 565);
            this.addCategory_clear.Name = "addCategory_clear";
            this.addCategory_clear.Size = new System.Drawing.Size(256, 43);
            this.addCategory_clear.TabIndex = 3;
            this.addCategory_clear.Text = "CLEAR";
            this.addCategory_clear.UseVisualStyleBackColor = false;
            this.addCategory_clear.Click += new System.EventHandler(this.addCategory_clear_Click);
            // 
            // addCategory_status
            // 
            this.addCategory_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategory_status.FormattingEnabled = true;
            this.addCategory_status.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.addCategory_status.Location = new System.Drawing.Point(30, 290);
            this.addCategory_status.Name = "addCategory_status";
            this.addCategory_status.Size = new System.Drawing.Size(229, 28);
            this.addCategory_status.TabIndex = 3;
            this.addCategory_status.SelectedIndexChanged += new System.EventHandler(this.addCategory_status_SelectedIndexChanged);
            // 
            // addCategory_delete
            // 
            this.addCategory_delete.BackColor = System.Drawing.Color.SeaGreen;
            this.addCategory_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategory_delete.ForeColor = System.Drawing.Color.White;
            this.addCategory_delete.Location = new System.Drawing.Point(13, 505);
            this.addCategory_delete.Name = "addCategory_delete";
            this.addCategory_delete.Size = new System.Drawing.Size(256, 43);
            this.addCategory_delete.TabIndex = 2;
            this.addCategory_delete.Text = "DELETE";
            this.addCategory_delete.UseVisualStyleBackColor = false;
            this.addCategory_delete.Click += new System.EventHandler(this.addCategory_delete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Status";
            // 
            // addCategory_update
            // 
            this.addCategory_update.BackColor = System.Drawing.Color.SeaGreen;
            this.addCategory_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategory_update.ForeColor = System.Drawing.Color.White;
            this.addCategory_update.Location = new System.Drawing.Point(13, 446);
            this.addCategory_update.Name = "addCategory_update";
            this.addCategory_update.Size = new System.Drawing.Size(256, 43);
            this.addCategory_update.TabIndex = 1;
            this.addCategory_update.Text = "UPDATE";
            this.addCategory_update.UseVisualStyleBackColor = false;
            this.addCategory_update.Click += new System.EventHandler(this.addCategory_update_Click);
            // 
            // addCategory_add
            // 
            this.addCategory_add.BackColor = System.Drawing.Color.SeaGreen;
            this.addCategory_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategory_add.ForeColor = System.Drawing.Color.White;
            this.addCategory_add.Location = new System.Drawing.Point(13, 381);
            this.addCategory_add.Name = "addCategory_add";
            this.addCategory_add.Size = new System.Drawing.Size(256, 43);
            this.addCategory_add.TabIndex = 0;
            this.addCategory_add.Text = "ADD";
            this.addCategory_add.UseVisualStyleBackColor = false;
            this.addCategory_add.Click += new System.EventHandler(this.addCategory_add_Click);
            // 
            // addCategory_category
            // 
            this.addCategory_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategory_category.Location = new System.Drawing.Point(30, 207);
            this.addCategory_category.Name = "addCategory_category";
            this.addCategory_category.Size = new System.Drawing.Size(229, 27);
            this.addCategory_category.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(81, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(331, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(621, 709);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Category\'s Data";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.addCategory_clear);
            this.panel1.Controls.Add(this.addCategory_status);
            this.panel1.Controls.Add(this.addCategory_delete);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.addCategory_update);
            this.panel1.Controls.Add(this.addCategory_add);
            this.panel1.Controls.Add(this.addCategory_category);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(19, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 709);
            this.panel1.TabIndex = 2;
            // 
            // adminAddCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "adminAddCategories";
            this.Size = new System.Drawing.Size(970, 758);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addCategory_clear;
        private System.Windows.Forms.ComboBox addCategory_status;
        private System.Windows.Forms.Button addCategory_delete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addCategory_update;
        private System.Windows.Forms.Button addCategory_add;
        private System.Windows.Forms.TextBox addCategory_category;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}
