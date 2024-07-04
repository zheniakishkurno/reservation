
namespace WindowsFormsApp1
{
    partial class Form7
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
            this.components = new System.ComponentModel.Container();
            this.table1DataSet = new WindowsFormsApp1.table1DataSet();
            this.table1DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.table1TableAdapter = new WindowsFormsApp1.table1DataSetTableAdapters.Table1TableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.логинDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.времяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоЛюдейDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table1BindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.table1DataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.table1DataSet3 = new WindowsFormsApp1.table1DataSet3();
            this.table1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.table1DataSet1 = new WindowsFormsApp1.table1DataSet1();
            this.table1BindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.table1TableAdapter1 = new WindowsFormsApp1.table1DataSet1TableAdapters.Table1TableAdapter();
            this.table1TableAdapter2 = new WindowsFormsApp1.table1DataSet3TableAdapters.Table1TableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.button3 = new Guna.UI2.WinForms.Guna2Button();
            this.button2 = new Guna.UI2.WinForms.Guna2Button();
            this.button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.table1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1DataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource2)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // table1DataSet
            // 
            this.table1DataSet.DataSetName = "table1DataSet";
            this.table1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table1DataSetBindingSource
            // 
            this.table1DataSetBindingSource.DataSource = this.table1DataSet;
            this.table1DataSetBindingSource.Position = 0;
            // 
            // table1BindingSource
            // 
            this.table1BindingSource.DataMember = "Table1";
            this.table1BindingSource.DataSource = this.table1DataSet;
            // 
            // table1TableAdapter
            // 
            this.table1TableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.логинDataGridViewTextBoxColumn,
            this.датаDataGridViewTextBoxColumn,
            this.времяDataGridViewTextBoxColumn,
            this.количествоЛюдейDataGridViewTextBoxColumn,
            this.имяDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.table1BindingSource3;
            this.dataGridView2.Location = new System.Drawing.Point(64, 104);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(569, 371);
            this.dataGridView2.TabIndex = 5;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // логинDataGridViewTextBoxColumn
            // 
            this.логинDataGridViewTextBoxColumn.DataPropertyName = "логин";
            this.логинDataGridViewTextBoxColumn.HeaderText = "логин";
            this.логинDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.логинDataGridViewTextBoxColumn.Name = "логинDataGridViewTextBoxColumn";
            this.логинDataGridViewTextBoxColumn.ReadOnly = true;
            this.логинDataGridViewTextBoxColumn.Width = 74;
            // 
            // датаDataGridViewTextBoxColumn
            // 
            this.датаDataGridViewTextBoxColumn.DataPropertyName = "дата";
            this.датаDataGridViewTextBoxColumn.HeaderText = "дата";
            this.датаDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.датаDataGridViewTextBoxColumn.Name = "датаDataGridViewTextBoxColumn";
            this.датаDataGridViewTextBoxColumn.ReadOnly = true;
            this.датаDataGridViewTextBoxColumn.Width = 68;
            // 
            // времяDataGridViewTextBoxColumn
            // 
            this.времяDataGridViewTextBoxColumn.DataPropertyName = "время";
            this.времяDataGridViewTextBoxColumn.HeaderText = "время";
            this.времяDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.времяDataGridViewTextBoxColumn.Name = "времяDataGridViewTextBoxColumn";
            this.времяDataGridViewTextBoxColumn.ReadOnly = true;
            this.времяDataGridViewTextBoxColumn.Width = 77;
            // 
            // количествоЛюдейDataGridViewTextBoxColumn
            // 
            this.количествоЛюдейDataGridViewTextBoxColumn.DataPropertyName = "количество людей";
            this.количествоЛюдейDataGridViewTextBoxColumn.HeaderText = "количество людей";
            this.количествоЛюдейDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.количествоЛюдейDataGridViewTextBoxColumn.Name = "количествоЛюдейDataGridViewTextBoxColumn";
            this.количествоЛюдейDataGridViewTextBoxColumn.ReadOnly = true;
            this.количествоЛюдейDataGridViewTextBoxColumn.Width = 145;
            // 
            // имяDataGridViewTextBoxColumn
            // 
            this.имяDataGridViewTextBoxColumn.DataPropertyName = "имя";
            this.имяDataGridViewTextBoxColumn.HeaderText = "имя";
            this.имяDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.имяDataGridViewTextBoxColumn.Name = "имяDataGridViewTextBoxColumn";
            this.имяDataGridViewTextBoxColumn.ReadOnly = true;
            this.имяDataGridViewTextBoxColumn.Width = 62;
            // 
            // table1BindingSource3
            // 
            this.table1BindingSource3.DataMember = "Table1";
            this.table1BindingSource3.DataSource = this.table1DataSet3BindingSource;
            // 
            // table1DataSet3BindingSource
            // 
            this.table1DataSet3BindingSource.DataSource = this.table1DataSet3;
            this.table1DataSet3BindingSource.Position = 0;
            // 
            // table1DataSet3
            // 
            this.table1DataSet3.DataSetName = "table1DataSet3";
            this.table1DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table1BindingSource1
            // 
            this.table1BindingSource1.DataMember = "Table1";
            this.table1BindingSource1.DataSource = this.table1DataSetBindingSource;
            // 
            // table1DataSet1
            // 
            this.table1DataSet1.DataSetName = "table1DataSet1";
            this.table1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table1BindingSource2
            // 
            this.table1BindingSource2.DataMember = "Table1";
            this.table1BindingSource2.DataSource = this.table1DataSet1;
            // 
            // table1TableAdapter1
            // 
            this.table1TableAdapter1.ClearBeforeFill = true;
            // 
            // table1TableAdapter2
            // 
            this.table1TableAdapter2.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 28.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(380, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 56);
            this.label1.TabIndex = 6;
            this.label1.Text = "Админ";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.button3);
            this.guna2GradientPanel1.Controls.Add(this.button2);
            this.guna2GradientPanel1.Controls.Add(this.button1);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Controls.Add(this.dataGridView2);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(1, -1);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(935, 585);
            this.guna2GradientPanel1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BorderRadius = 20;
            this.button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button3.FillColor = System.Drawing.Color.CadetBlue;
            this.button3.Font = new System.Drawing.Font("Consolas", 22.2F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.SystemColors.Info;
            this.button3.Location = new System.Drawing.Point(704, 396);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(212, 58);
            this.button3.TabIndex = 10;
            this.button3.Text = "удалить";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BorderRadius = 20;
            this.button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button2.FillColor = System.Drawing.Color.CadetBlue;
            this.button2.Font = new System.Drawing.Font("Consolas", 22.2F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.Info;
            this.button2.Location = new System.Drawing.Point(719, 506);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 58);
            this.button2.TabIndex = 9;
            this.button2.Text = "выход";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BorderRadius = 20;
            this.button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button1.FillColor = System.Drawing.Color.CadetBlue;
            this.button1.Font = new System.Drawing.Font("Consolas", 22.2F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.Info;
            this.button1.Location = new System.Drawing.Point(64, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 58);
            this.button1.TabIndex = 8;
            this.button1.Text = "назад";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources._1685384046_fons_pibig_info_p_fon_restoran_razmitii_vkontakte_36;
            this.ClientSize = new System.Drawing.Size(931, 580);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "Form7";
            this.Text = "поле админа ";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1DataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1DataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource2)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource table1DataSetBindingSource;
        private table1DataSet table1DataSet;
        private System.Windows.Forms.BindingSource table1BindingSource;
        private table1DataSetTableAdapters.Table1TableAdapter table1TableAdapter;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource table1BindingSource1;
        private table1DataSet1 table1DataSet1;
        private System.Windows.Forms.BindingSource table1BindingSource2;
        private table1DataSet1TableAdapters.Table1TableAdapter table1TableAdapter1;
        private System.Windows.Forms.BindingSource table1DataSet3BindingSource;
        private table1DataSet3 table1DataSet3;
        private System.Windows.Forms.BindingSource table1BindingSource3;
        private table1DataSet3TableAdapters.Table1TableAdapter table1TableAdapter2;
        private System.Windows.Forms.DataGridViewTextBoxColumn логинDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn времяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоЛюдейDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn имяDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button button1;
        private Guna.UI2.WinForms.Guna2Button button3;
        private Guna.UI2.WinForms.Guna2Button button2;
    }
}