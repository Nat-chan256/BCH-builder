namespace BChH
{
    partial class ResultDecodingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultDecodingForm));
            this.b_save = new System.Windows.Forms.Button();
            this.text_box = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // b_save
            // 
            this.b_save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.b_save.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_save.Location = new System.Drawing.Point(140, 598);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(225, 33);
            this.b_save.TabIndex = 7;
            this.b_save.Text = "Сохранить результаты в файл";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // text_box
            // 
            this.text_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_box.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.text_box.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_box.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.text_box.Location = new System.Drawing.Point(0, 9);
            this.text_box.Name = "text_box";
            this.text_box.ReadOnly = true;
            this.text_box.Size = new System.Drawing.Size(514, 580);
            this.text_box.TabIndex = 6;
            this.text_box.Text = "";
            // 
            // ResultDecodingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 640);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.text_box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResultDecodingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Декодирование слова";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultDecodingForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_save;
        public System.Windows.Forms.RichTextBox text_box;
    }
}