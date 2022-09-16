
namespace XMLComparer
{
    partial class DifferenceWindow
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DIFFERENCE_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALUE_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALUE_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALUE_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALUE_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DIFFERENCE_TYPE,
            this.VALUE_1,
            this.VALUE_2,
            this.VALUE_3,
            this.VALUE_4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1044, 455);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DIFFERENCE_TYPE
            // 
            this.DIFFERENCE_TYPE.HeaderText = "Difference Type";
            this.DIFFERENCE_TYPE.Name = "DIFFERENCE_TYPE";
            this.DIFFERENCE_TYPE.Width = 200;
            // 
            // VALUE_1
            // 
            this.VALUE_1.HeaderText = "Value 1";
            this.VALUE_1.Name = "VALUE_1";
            this.VALUE_1.Width = 200;
            // 
            // VALUE_2
            // 
            this.VALUE_2.HeaderText = "Value 2";
            this.VALUE_2.Name = "VALUE_2";
            this.VALUE_2.Width = 200;
            // 
            // VALUE_3
            // 
            this.VALUE_3.HeaderText = "Value 3";
            this.VALUE_3.Name = "VALUE_3";
            this.VALUE_3.Width = 200;
            // 
            // VALUE_4
            // 
            this.VALUE_4.HeaderText = "Value 4";
            this.VALUE_4.Name = "VALUE_4";
            this.VALUE_4.Width = 200;
            // 
            // DifferenceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 532);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DifferenceWindow";
            this.Text = "DifferenceWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIFFERENCE_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALUE_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALUE_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALUE_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALUE_4;
    }
}