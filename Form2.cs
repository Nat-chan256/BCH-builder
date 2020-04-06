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
    public partial class Form2 : Form
    {
        private int n_;
        public int n
        {
            get { return n_; }
            set { n_ = value; }
        }
        private int m_;
        public int m
        {
            get { return m_; }
            set { m_ = value; }
        }
        private int d_;
        public int d
        {
            get { return d_; }
            set { d_ = value; }
        }
        private List<RadioButton> radio_button_;
        private List<BinaryString> polynomials_;
        private Form1 prev_form_;
        private Form3 next_form_;

        public Form2(int n, int m, int d, Form1 prev_form)
        {
            InitializeComponent();

            n_ = n;
            m_ = m;
            d_ = d;
            prev_form_ = prev_form;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Label text = new Label();
            text.Text = $"Выберите образующий многочлен для поля GF(2^{m_}):";
            text.Location = new System.Drawing.Point(10, 0);
            text.Font = this.Font;
            text.Size = text.PreferredSize;
            this.Controls.Add(text);

            if (polynomials_ == null || polynomials_.ElementAt(0).degree != m_)
                polynomials_ = GF2.generatePolynomialsOfDegree(m_);
            radio_button_ = new List<RadioButton>();

            for (int i = 0; i < polynomials_.Count; ++i)
            {
                RadioButton new_button = new RadioButton();
                new_button.Text = polynomials_.ElementAt(i).transformToPolynomial();
                new_button.Size = new_button.PreferredSize;
                new_button.AutoSize = true;
                radio_button_.Add(new_button);
            }

            radio_button_.ElementAt(0).Location = new System.Drawing.Point(50, 10);
            panel.Controls.Add(radio_button_.ElementAt(0));
            for (int i = 1; i < radio_button_.Count; ++i)
            {
                if (i > 1087) break;
                
                radio_button_.ElementAt(i).Location = new System.Drawing.Point(50, radio_button_.ElementAt(i - 1).Location.Y + 30);
                panel.Controls.Add(radio_button_.ElementAt(i));
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            //Ищем выбранный пользователем полином
            int i;
            for (i = 0; i < radio_button_.Count; ++i)
            {
                if (radio_button_.ElementAt(i).Checked)
                {
                    break;
                }
            }

            if (i == radio_button_.Count)
            {
                MessageBox.Show("Выберите образующий многочлен.");
                return;
            }
            else
            {
                if (next_form_ == null || next_form_.polynomial.ToString() != polynomials_.ElementAt(i).ToString())
                    next_form_ = new Form3(n_, d_, polynomials_.ElementAt(i), this);
                else
                {
                    next_form_.n = n_;
                    next_form_.d = d_;
                }
                this.Hide();
                next_form_.Show();
            }
        }

        private void b_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            prev_form_.Show();
        }
    }
}
