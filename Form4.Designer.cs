﻿namespace BChH
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.text_box = new System.Windows.Forms.RichTextBox();
            this.b_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text_box
            // 
            this.text_box.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.text_box.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.text_box.Location = new System.Drawing.Point(0, 0);
            this.text_box.Name = "text_box";
            this.text_box.ReadOnly = true;
            this.text_box.Size = new System.Drawing.Size(514, 580);
            this.text_box.TabIndex = 0;
            this.text_box.Text = "";
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(134, 595);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(225, 33);
            this.b_save.TabIndex = 1;
            this.b_save.Text = "Сохранить результаты в файл";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // Form4
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(514, 640);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.text_box);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "БЧХ код";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox text_box;
        private System.Windows.Forms.Button b_save;
    }
}