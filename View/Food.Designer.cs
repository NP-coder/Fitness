namespace View
{
    partial class FoodForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.Weight = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.FoodGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Weight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FoodGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(164)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.Weight);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.FoodGrid);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(699, 466);
            this.panel3.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(12, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 27);
            this.label6.TabIndex = 9;
            this.label6.Text = "Грамм:";
            // 
            // Weight
            // 
            this.Weight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Weight.Location = new System.Drawing.Point(103, 62);
            this.Weight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Weight.Name = "Weight";
            this.Weight.Size = new System.Drawing.Size(100, 22);
            this.Weight.TabIndex = 5;
            this.Weight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(513, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Прийом їжі";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FoodGrid
            // 
            this.FoodGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.FoodGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.FoodGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(164)))), ((int)(((byte)(255)))));
            this.FoodGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FoodGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FoodGrid.Location = new System.Drawing.Point(0, 132);
            this.FoodGrid.MultiSelect = false;
            this.FoodGrid.Name = "FoodGrid";
            this.FoodGrid.RowHeadersWidth = 51;
            this.FoodGrid.RowTemplate.Height = 24;
            this.FoodGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.FoodGrid.Size = new System.Drawing.Size(699, 334);
            this.FoodGrid.TabIndex = 3;
            this.FoodGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FoodGrid_CellClick);
            this.FoodGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FoodGrid_CellContentClick);
            this.FoodGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.FoodGrid_CellValueChanged);
            this.FoodGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.FoodGrid_UserAddedRow);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(700, 100);
            this.panel1.MinimumSize = new System.Drawing.Size(700, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 100);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(700, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Харчові продукти";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 566);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FoodForm";
            this.Text = "Food";
            this.Load += new System.EventHandler(this.Food_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Weight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FoodGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView FoodGrid;
        private System.Windows.Forms.NumericUpDown Weight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
    }
}