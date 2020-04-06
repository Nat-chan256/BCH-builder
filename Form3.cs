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
    public partial class Form3 : Form
    {
        private GF2 galois_field_;
        private BCHCode code;
        public BinaryString polynomial
        {
            get { return galois_field_.polynomial; }
        }
        private List<RadioButton> radio_button_;
        private List<BinaryString> primitive_elems_;
        private int n_;
        public int n
        {
            get { return n_; }
            set { n_ = value; }
        }
        private int d_;
        public int d
        {
            get { return d_; }
            set { d_ = value; }
        }
        private Form2 prev_form_;
        public Form3(int n, int d, BinaryString polynomial, Form2 prev_form)
        {
            InitializeComponent();
            //Создаем поле Галуа
            galois_field_ = new GF2(polynomial.degree, polynomial);
            n_ = n;
            d_ = d;
            prev_form_ = prev_form;

            radio_button_ = new List<RadioButton>();
            primitive_elems_ = new List<BinaryString>();
        }
        private int gcd(int num1, int num2)
        {
            if (num2 == 0) return num1;

            return gcd(num2, num1 % num2);
        }

        private bool isPrime(int num)
        {
            if (num < 2) return false;

            int sqrt = (int)Math.Sqrt(num);

            for (int i = 2; i <= sqrt; ++i)
                if (num % i == 0) return false;
            return true;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //Находим первый примитивный элемент
                BinaryString first_primitive = new BinaryString();
                for (int i = 2; i < Math.Pow(2, galois_field_.polynomial.size() - 1); ++i)
                {
                    if (galois_field_.isPrimitive(galois_field_.element(i)))
                    {
                        first_primitive = galois_field_.element(i);
                        break;
                    }
                }
                //Возводим примитивный элемент во все взаимно простые с 2^m - 1 степени
                int field_size = (int)Math.Pow(2, galois_field_.polynomial.degree);
                if (isPrime(field_size - 1)) //Если 2^m - 1 -  простое число
                {
                    //все элементы поля, кроме 0 и 1 - примитивные
                    for (int i = 2; i < Math.Pow(2, galois_field_.degree); ++i)
                        primitive_elems_.Add(galois_field_.element(i));
                }
                else
                {
                    for (int i = 1; i < field_size - 1; ++i)
                    {
                        if (i > 600) break;
                        if (gcd(i, field_size - 1) == 1)
                        {
                            primitive_elems_.Add(galois_field_.Pow(first_primitive, i));
                        }
                    }
                }

                //Создаем кнопки
                for (int i = 0; i < primitive_elems_.Count; ++i)
                {
                    RadioButton new_button = new RadioButton();
                    new_button.Text = primitive_elems_.ElementAt(i).transformToPolynomial();
                    new_button.AutoSize = true;
                    radio_button_.Add(new_button);
                }

                radio_button_.ElementAt(0).Location = new System.Drawing.Point(50, 10);
                radio_button_.ElementAt(0).Size = radio_button_.ElementAt(0).PreferredSize;
                panel.Controls.Add(radio_button_.ElementAt(0));
                for (int i = 1; i < radio_button_.Count; ++i)
                {
                    radio_button_.ElementAt(i).Location = new System.Drawing.Point(50, radio_button_.ElementAt(i - 1).Location.Y + 30);
                    radio_button_.ElementAt(i).Size = radio_button_.ElementAt(i).PreferredSize;
                    panel.Controls.Add(radio_button_.ElementAt(i));
                }
            
        }

        private void b_build_code_Click(object sender, EventArgs e)
        {
            //Проверяем, выбран ли примитивный элемент
            int i;
            for (i = 0; i < radio_button_.Count; ++i)
            {
                if (radio_button_.ElementAt(i).Checked)
                {
                    if (code == null || code.n != n_ || code.m != galois_field_.degree
                        || code.d != d_ || code.alpha.ToString() != primitive_elems_.ElementAt(i).ToString()
                        || code.polynomial.ToString() != galois_field_.polynomial.ToString())
                    {
                        code = new BCHCode(n_, galois_field_.degree, d_, primitive_elems_.ElementAt(i),
                              galois_field_.polynomial, this);
                    }
                    code.show();

                    break;
                }
            }

            if (i == radio_button_.Count)
            {
                MessageBox.Show("Выберите примитивный элемент.");
                return;
            }
        }

        private void b_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            prev_form_.Show();
        }
    }
}
