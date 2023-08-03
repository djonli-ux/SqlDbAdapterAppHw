namespace DbAdapterAppHw
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fill_btn = new Button();
            save_btn = new Button();
            dgv = new DataGridView();
            TableList = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // fill_btn
            // 
            fill_btn.Location = new Point(278, 12);
            fill_btn.Name = "fill_btn";
            fill_btn.Size = new Size(94, 29);
            fill_btn.TabIndex = 1;
            fill_btn.Text = "Fill";
            fill_btn.UseVisualStyleBackColor = true;
            fill_btn.Click += Fill_btn_Click;
            // 
            // save_btn
            // 
            save_btn.Location = new Point(389, 12);
            save_btn.Name = "save_btn";
            save_btn.Size = new Size(94, 29);
            save_btn.TabIndex = 2;
            save_btn.Text = "Save";
            save_btn.UseVisualStyleBackColor = true;
            save_btn.Click += Save_btn_Click;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(278, 73);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.RowTemplate.Height = 29;
            dgv.Size = new Size(757, 487);
            dgv.TabIndex = 3;
            // 
            // TableList
            // 
            TableList.FormattingEnabled = true;
            TableList.ItemHeight = 20;
            TableList.Location = new Point(37, 16);
            TableList.Name = "TableList";
            TableList.Size = new Size(193, 544);
            TableList.TabIndex = 4;
            TableList.SelectedIndexChanged += TableList_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 602);
            Controls.Add(TableList);
            Controls.Add(dgv);
            Controls.Add(save_btn);
            Controls.Add(fill_btn);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button fill_btn;
        private Button save_btn;
        private DataGridView dgv;
        private ListBox TableList;
    }
}