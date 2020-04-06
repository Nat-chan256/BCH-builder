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
    public partial class Form1 : Form
    {
        private Form2 next_form_;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void tb_input_n_m_d_TextChanged(object sender, EventArgs e)
        {
            //Убираем все символы, кроме цифр
            TextBox text_box = (TextBox)sender;
            for (int i = 0; i < text_box.Text.Length; ++i)
            {
                if (text_box.Text[i] < '0' || text_box.Text[i] > '9')
                    text_box.Text = text_box.Text.Remove(i, 1);
                else if (text_box.Text[0] == '0')
                    text_box.Text = text_box.Text.Remove(0, 1);
            }
            //Проверка на ввод значения, большего, чем MAX_INT
            if (text_box.Text.Length == Int32.MaxValue.ToString().Length)
                text_box.Text = text_box.Text.Remove(text_box.Text.Length - 1, 1);

            text_box.SelectionStart = text_box.Text.Length; //Перемещаем каретку в конец строки
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            //Проверяем, все ли поля заполнены
            if (tb_input_n.Text.Length == 0)
            {
                MessageBox.Show("Введите параметр n.");
                return;
            }
            if (tb_input_d.Text.Length == 0)
            {
                MessageBox.Show("Введите параметр d.");
                return;
            }

            //Проверка введенных параметров на корректность
            
            int d = Int32.Parse(tb_input_d.Text);
            int n = Int32.Parse(tb_input_n.Text);

            if (n > Math.Pow(2, 15) - 1)
            {
                MessageBox.Show("Параметр n не должен превышать значение 32767.");
                return;
            }

            if (n % 2 == 0)
            {
                MessageBox.Show("Параметр n должен быть нечетным числом.");
                return;
            }
            if (d % 2 == 0)
            {
                MessageBox.Show("Параметр d должен быть нечетным числом.");
                return;
            }

            if (n < d)
            {
                MessageBox.Show("Параметр d не должен превосходить n.");
                return;
            }

            if (n == 1)
            {
                MessageBox.Show("Длина кода не может быть равна 1.");
                return;
            }
            if (d == 1)
            {
                MessageBox.Show("Конструктивное расстояние не может быть равным 1.");
                return;
            }

            //Вычисляем степень образующего многочлена
            int m;
            for (m = 1; (Math.Pow(2, m) - 1) % n != 0 && m < 16; ++m) ;
            
            //int t = (d - 1) / 2;//Число ошибок, которые может исправлять код на основании параметра d
            //if (m * t >= n)
            //{
            //    t = (n - 1) / m;
            //    MessageBox.Show($"Параметр  d не может превышать значение {2 * t + 1} для данной длины кода.");
            //    return;
            //}

            if (m > 15)
            {
                MessageBox.Show("Для данного кода значение m превышает 15. " +
                    "Для корректной работы программы должно выполняться условие: m <= 15.");
                return;
            }

            if (next_form_ == null || next_form_.m != m)
            { next_form_ = new Form2(n, m, d, this); }
            else
            {
                next_form_.n = n;
                next_form_.d = d;
            }
            this.Hide();
            next_form_.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
