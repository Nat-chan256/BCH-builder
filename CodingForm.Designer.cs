namespace BChH
{
    partial class CodingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodingForm));
            this.l_n = new System.Windows.Forms.Label();
            this.l_k = new System.Windows.Forms.Label();
            this.tb_inf_word = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.b_gen_word = new System.Windows.Forms.Button();
            this.l_polynomial = new System.Windows.Forms.Label();
            this.b_code_word = new System.Windows.Forms.Button();
            this.b_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_n
            // 
            this.l_n.AutoSize = true;
            this.l_n.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_n.Location = new System.Drawing.Point(38, 74);
            this.l_n.Name = "l_n";
            this.l_n.Size = new System.Drawing.Size(42, 23);
            this.l_n.TabIndex = 0;
            this.l_n.Text = "n = ";
            // 
            // l_k
            // 
            this.l_k.AutoSize = true;
            this.l_k.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_k.Location = new System.Drawing.Point(38, 106);
            this.l_k.Name = "l_k";
            this.l_k.Size = new System.Drawing.Size(42, 23);
            this.l_k.TabIndex = 1;
            this.l_k.Text = "k = ";
            // 
            // tb_inf_word
            // 
            this.tb_inf_word.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_inf_word.Location = new System.Drawing.Point(214, 168);
            this.tb_inf_word.Name = "tb_inf_word";
            this.tb_inf_word.Size = new System.Drawing.Size(289, 29);
            this.tb_inf_word.TabIndex = 2;
            this.tb_inf_word.TextChanged += new System.EventHandler(this.tb_inf_word_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Информационное слово";
            // 
            // b_gen_word
            // 
            this.b_gen_word.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_gen_word.Location = new System.Drawing.Point(308, 223);
            this.b_gen_word.Name = "b_gen_word";
            this.b_gen_word.Size = new System.Drawing.Size(195, 39);
            this.b_gen_word.TabIndex = 5;
            this.b_gen_word.Text = "Сгенерировать слово";
            this.b_gen_word.UseVisualStyleBackColor = true;
            this.b_gen_word.Click += new System.EventHandler(this.b_gen_word_Click);
            // 
            // l_polynomial
            // 
            this.l_polynomial.AutoSize = true;
            this.l_polynomial.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_polynomial.Location = new System.Drawing.Point(12, 41);
            this.l_polynomial.Name = "l_polynomial";
            this.l_polynomial.Size = new System.Drawing.Size(68, 23);
            this.l_polynomial.TabIndex = 6;
            this.l_polynomial.Text = "F(x) = ";
            // 
            // b_code_word
            // 
            this.b_code_word.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_code_word.Location = new System.Drawing.Point(268, 360);
            this.b_code_word.Name = "b_code_word";
            this.b_code_word.Size = new System.Drawing.Size(234, 43);
            this.b_code_word.TabIndex = 7;
            this.b_code_word.Text = "Закодировать слово";
            this.b_code_word.UseVisualStyleBackColor = true;
            this.b_code_word.Click += new System.EventHandler(this.b_code_word_Click);
            // 
            // b_back
            // 
            this.b_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_back.Location = new System.Drawing.Point(12, 361);
            this.b_back.Name = "b_back";
            this.b_back.Size = new System.Drawing.Size(112, 42);
            this.b_back.TabIndex = 8;
            this.b_back.Text = "Назад";
            this.b_back.UseVisualStyleBackColor = true;
            this.b_back.Click += new System.EventHandler(this.b_back_Click);
            // 
            // CodingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 424);
            this.Controls.Add(this.b_back);
            this.Controls.Add(this.b_code_word);
            this.Controls.Add(this.l_polynomial);
            this.Controls.Add(this.b_gen_word);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_inf_word);
            this.Controls.Add(this.l_k);
            this.Controls.Add(this.l_n);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CodingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Закодировать слово";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CodingForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_n;
        private System.Windows.Forms.Label l_k;
        private System.Windows.Forms.TextBox tb_inf_word;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_gen_word;
        private System.Windows.Forms.Label l_polynomial;
        private System.Windows.Forms.Button b_code_word;
        private System.Windows.Forms.Button b_back;
    }
}