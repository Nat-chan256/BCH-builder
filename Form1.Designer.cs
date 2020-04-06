namespace BChH
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_input_n = new System.Windows.Forms.TextBox();
            this.tb_input_d = new System.Windows.Forms.TextBox();
            this.b_next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Длина кодового слова (n)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Конструктивное расстояние (d)";
            // 
            // tb_input_n
            // 
            this.tb_input_n.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_input_n.Location = new System.Drawing.Point(334, 39);
            this.tb_input_n.Name = "tb_input_n";
            this.tb_input_n.Size = new System.Drawing.Size(235, 26);
            this.tb_input_n.TabIndex = 9;
            this.tb_input_n.TextChanged += new System.EventHandler(this.tb_input_n_m_d_TextChanged);
            // 
            // tb_input_d
            // 
            this.tb_input_d.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_input_d.Location = new System.Drawing.Point(334, 77);
            this.tb_input_d.Name = "tb_input_d";
            this.tb_input_d.Size = new System.Drawing.Size(235, 26);
            this.tb_input_d.TabIndex = 11;
            this.tb_input_d.TextChanged += new System.EventHandler(this.tb_input_n_m_d_TextChanged);
            // 
            // b_next
            // 
            this.b_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_next.Location = new System.Drawing.Point(477, 134);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(92, 36);
            this.b_next.TabIndex = 14;
            this.b_next.Text = "Далее";
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 182);
            this.Controls.Add(this.b_next);
            this.Controls.Add(this.tb_input_d);
            this.Controls.Add(this.tb_input_n);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод параметров";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_input_n;
        private System.Windows.Forms.TextBox tb_input_d;
        private System.Windows.Forms.Button b_next;
    }
}

