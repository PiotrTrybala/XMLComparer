
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
            this.NODE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIFFERENCE_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OLD_VALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NEW_VALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NODE_NAME,
            this.DIFFERENCE_TYPE,
            this.OLD_VALUE,
            this.NEW_VALUE});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1246, 455);
            this.dataGridView1.TabIndex = 0;
        
            // 
            // NODE_NAME
            // 
            this.NODE_NAME.HeaderText = "Node Name";
            this.NODE_NAME.Name = "NODE_NAME";
            this.NODE_NAME.Width = 300;
            // 
            // DIFFERENCE_TYPE
            // 
            this.DIFFERENCE_TYPE.HeaderText = "Difference Type";
            this.DIFFERENCE_TYPE.Name = "DIFFERENCE_TYPE";
            this.DIFFERENCE_TYPE.Width = 300;
            // 
            // OLD_VALUE
            // 
            this.OLD_VALUE.HeaderText = "Old value";
            this.OLD_VALUE.Name = "OLD_VALUE";
            this.OLD_VALUE.Width = 300;
            // 
            // NEW_VALUE
            // 
            this.NEW_VALUE.HeaderText = "New Value";
            this.NEW_VALUE.Name = "NEW_VALUE";
            this.NEW_VALUE.Width = 300;
            // 
            // DifferenceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 532);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DifferenceWindow";
            this.Text = "DifferenceWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NODE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIFFERENCE_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLD_VALUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NEW_VALUE;
    }
}