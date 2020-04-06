namespace BChH
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.b_build_code = new System.Windows.Forms.Button();
            this.b_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(94, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите примитивный элемент α:";
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel.Location = new System.Drawing.Point(2, 32);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(506, 547);
            this.panel.TabIndex = 1;
            // 
            // b_build_code
            // 
            this.b_build_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_build_code.Location = new System.Drawing.Point(347, 589);
            this.b_build_code.Name = "b_build_code";
            this.b_build_code.Size = new System.Drawing.Size(151, 35);
            this.b_build_code.TabIndex = 2;
            this.b_build_code.Text = "Построить код";
            this.b_build_code.UseVisualStyleBackColor = true;
            this.b_build_code.Click += new System.EventHandler(this.b_build_code_Click);
            // 
            // b_back
            // 
            this.b_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_back.Location = new System.Drawing.Point(12, 589);
            this.b_back.Name = "b_back";
            this.b_back.Size = new System.Drawing.Size(78, 35);
            this.b_back.TabIndex = 3;
            this.b_back.Text = "Назад";
            this.b_back.UseVisualStyleBackColor = true;
            this.b_back.Click += new System.EventHandler(this.b_back_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 636);
            this.Controls.Add(this.b_back);
            this.Controls.Add(this.b_build_code);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор примитивного элемента";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button b_build_code;
        private System.Windows.Forms.Button b_back;
    }
}