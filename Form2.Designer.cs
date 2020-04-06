namespace BChH
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.b_next = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.b_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_next
            // 
            this.b_next.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_next.Location = new System.Drawing.Point(419, 589);
            this.b_next.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(78, 33);
            this.b_next.TabIndex = 0;
            this.b_next.Text = "Далее";
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel.Location = new System.Drawing.Point(2, 25);
            this.panel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(504, 555);
            this.panel.TabIndex = 1;
            // 
            // b_back
            // 
            this.b_back.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_back.Location = new System.Drawing.Point(13, 589);
            this.b_back.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.b_back.Name = "b_back";
            this.b_back.Size = new System.Drawing.Size(78, 33);
            this.b_back.TabIndex = 2;
            this.b_back.Text = "Назад";
            this.b_back.UseVisualStyleBackColor = true;
            this.b_back.Click += new System.EventHandler(this.b_back_Click);
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(510, 636);
            this.Controls.Add(this.b_back);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.b_next);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор образующего многочлена";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button b_back;
    }
}