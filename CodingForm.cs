using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BChH
{
    public partial class CodingForm : Form
    {
        private Form4 previous_form_;
        private int k_;
        private ResultCodingForm next_form_;
        private BinaryString polynomial_;

        public CodingForm(BinaryString polynomial, int n, int k, Form4 prev_form)
        {
            InitializeComponent();
            //Записываем параметры на форму
            l_polynomial.Text += polynomial.ToString();
            l_n.Text += n;
            l_k.Text += k;
            //Связываем с предыдущей формой
            previous_form_ = prev_form;

            k_ = k;
            polynomial_ = polynomial;
        }

        private void CodingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void b_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            previous_form_.Show();
        }

        private void tb_inf_word_TextChanged(object sender, EventArgs e)
        {
            //Финальная позиция каретки
            int final_selection_start = tb_inf_word.SelectionStart;

            //Убираем нули из начала слова
            if (tb_inf_word.TextLength > 0 && tb_inf_word.Text[0] == '0')
                tb_inf_word.Text = tb_inf_word.Text.Remove(0, 1);

            //Предотвращаем ввод символов, отличных от 0 и 1
            for (int i = 0; i < tb_inf_word.TextLength; ++i)
                if (tb_inf_word.Text[i] != '0' && tb_inf_word.Text[i] != '1')
                {
                    tb_inf_word.Text = tb_inf_word.Text.Remove(i, 1);
                    if (i <= final_selection_start) final_selection_start--;
                }
            tb_inf_word.SelectionStart = final_selection_start;
        }

        private void b_gen_word_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            //Очищаем текстБокс
            tb_inf_word.Text = String.Empty;

            //Генерируем слово
            tb_inf_word.Text += "1";
            for (int i = 1; i < k_; ++i)
                tb_inf_word.Text += rand.Next(0,2);
        }

        private void b_code_word_Click(object sender, EventArgs e)
        {
            //Проверка введенного слова
            if (tb_inf_word.TextLength != k_)
            {
                MessageBox.Show("Длина информационного слова должна равняться " + k_ + ". Вы ввели " + tb_inf_word.TextLength + " символов.");
                return;
            }

            //Считываем информационное слово
            BinaryString information_word = new BinaryString(tb_inf_word.Text);

            next_form_ = new ResultCodingForm(this, polynomial_, information_word);
            next_form_.Show();
            this.Hide();
        }
    }
}
