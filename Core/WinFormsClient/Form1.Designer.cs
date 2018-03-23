namespace WinFormsClient
{
    partial class Form1
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
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.resultListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtSearchText
            // 
            this.txtSearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtSearchText.Location = new System.Drawing.Point(227, 12);
            this.txtSearchText.Multiline = true;
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(359, 37);
            this.txtSearchText.TabIndex = 0;
            this.txtSearchText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(593, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 37);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Go !";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // resultListBox
            // 
            this.resultListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultListBox.BackColor = System.Drawing.SystemColors.Control;
            this.resultListBox.FormattingEnabled = true;
            this.resultListBox.Location = new System.Drawing.Point(26, 58);
            this.resultListBox.Name = "resultListBox";
            this.resultListBox.Size = new System.Drawing.Size(786, 225);
            this.resultListBox.TabIndex = 2;
            this.resultListBox.DoubleClick += new System.EventHandler(this.resultListBox_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 301);
            this.Controls.Add(this.resultListBox);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchText);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinForm - Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox resultListBox;
    }
}

