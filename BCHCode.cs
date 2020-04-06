using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BChH
{
    class BCHCode
    {
        private int n_, d_;
        private GF2 galois_field_;
        private BinaryString alpha_;
        private string text_;
        Form3 previous_form_;

        public int n
        {
            get { return n_; }
        }
        public int m
        {
            get { return galois_field_.degree; }
        }
        public int d
        {
            get { return d_; }
        }
        public BinaryString alpha
        {
            get { return alpha_; }
        }
        public BinaryString polynomial
        {
            get { return galois_field_.polynomial; }
        }
       
        public bool isRootOf(BinaryString root, BinaryString equation)
        {
            BinaryString result = new BinaryString("0");
            for (int i = 0; i <= equation.degree; ++i)
            {
                if (equation[equation.degree - i] == '1') result += galois_field_.Pow(root, i);
            }

            if (result.cutUnsignificantZeros().ToString() == "0") return true;
            else return false;
        }

        public bool inSameCyclClass(int first_index, int second_index, int mod)
        {
            if (first_index == second_index) return true;

            int cur_index = (first_index * 2) % mod;
            while (cur_index != first_index)
            {
                if (cur_index == second_index) return true;
                cur_index *= 2;
                cur_index %= mod;
            }
            return false;
        }
        public BCHCode(int n, int m, int d, BinaryString alpha, BinaryString polynomial, Form3 previous_form)
        {
            text_ = "Построим код БЧХ для следующих параметров: n = " + n
                + ", m = " + m + ", d = " + d;
            d_ = d;
            n_ = n;
            alpha_ = alpha;
            galois_field_ = new GF2(m, polynomial);
            previous_form_ = previous_form;

            int s = (int)(Math.Pow(2, m) - 1) / n;

            text_ += ",  α = " + alpha.transformToPolynomial() + ", P(x) = " + galois_field_.polynomial.transformToPolynomial();
            text_ += "\n\nНаходим s по формуле: s = ((2^m) - 1)/n, s = " + s;

            //Формируем элементы β, β^2,...,β^(d-1)
            BinaryString[] beta = new BinaryString[d_ - 1];
            beta[0] = galois_field_.Pow(alpha, s);
            text_ += "\n\nНаходим β по формуле: β = α^s, β = " + beta[0].transformToPolynomial();
            text_ += "\nВычисляем β^2,...,β^(d-1): ";
            for (int i = 1; i < d_ - 1; ++i)
            {
                beta[i] = beta[i - 1] * beta[0];
                if (i != 1) text_ += ", ";
                text_ += "\nβ^" + (i + 1) + " = (" + beta[0].transformToPolynomial() + ")*(" + beta[i - 1].transformToPolynomial()
                    + ")    =    " + beta[i].transformToPolynomial();
                if (beta[i].ToString() != (beta[i] % galois_field_.polynomial).ToString())
                    text_ += "    =    " + (beta[i] % galois_field_.polynomial).transformToPolynomial();
                beta[i] %= galois_field_.polynomial;
            }

            //Разбиваем β, β^2,...,β^(d-1) на цикломатические классы
            List<List<BinaryString>> cyclomatic_classes = new List<List<BinaryString>>();
            cyclomatic_classes.Add(new List<BinaryString>());
            cyclomatic_classes.ElementAt(0).Add(beta[0]);
            for (int i = 1; i < d - 1; ++i)
            {
                int j;
                for (j = 0; j < i; ++j) //Выясняем, входит ли beta[i] в к-л существующий цикл.класс
                    if (inSameCyclClass(i + 1, j + 1, (int)(Math.Pow(2, m) - 1) / s))
                    {
                        for (int k = 0; k < cyclomatic_classes.Count; ++k) //Ищем нужный цикл. класс
                            if (cyclomatic_classes.ElementAt(k).Contains(beta[j]))
                                cyclomatic_classes.ElementAt(k).Add(beta[i]);
                        break;
                    }
                if (j == i) //если цикл. класс не найден
                {
                    //cоздаем новый
                    cyclomatic_classes.Add(new List<BinaryString>());
                    cyclomatic_classes.ElementAt(cyclomatic_classes.Count - 1).Add(beta[i]);
                }
            }
            text_ += "\n\nРазбиваем элементы β, β^2,...,β^(d-1) на цикломатические классы:";
            for (int cycl_class = 0; cycl_class < cyclomatic_classes.Count; ++cycl_class)
            {
                text_ += "\n" + (cycl_class + 1) + "-й цикломатический класс:   ";
                for (int elem = 0; elem < cyclomatic_classes.ElementAt(cycl_class).Count; ++elem)
                {
                    text_ += cyclomatic_classes.ElementAt(cycl_class).ElementAt(elem).transformToPolynomial();
                    if (elem < cyclomatic_classes.ElementAt(cycl_class).Count - 1) text_ += ",   ";
                }
            }

            //Ищем минимальные полиномы, которые будем проверять
            List<BinaryString> polynomials_to_check = new List<BinaryString>();
            for (int i = 1; i <= m; ++i)
            {
                if (m % i == 0)
                {
                    List<BinaryString> temp_list = GF2.generatePolynomialsOfDegree(i);
                    polynomials_to_check.AddRange(temp_list);
                }
            }
            text_ += "\n\nРаскладываем полином x^" + (Math.Pow(2, m) - 1) + " + 1 на множители:\n"
                + "x^" + (Math.Pow(2, m) - 1) + " + 1 = ";
            for (int i = 0; i < polynomials_to_check.Count; ++i)
            {
                text_ += "(" + polynomials_to_check.ElementAt(i).transformToPolynomial() + ")";
                if (i < polynomials_to_check.Count - 1) text_ += "*";
            }

            //Составляем образующий многочлен
            text_ += "\n\nСреди делителей полинома x^" + (Math.Pow(2, m) - 1) + " + 1 ищем минимальный для каждого "
                + "цикломатического класса:";
            string main_pol_dividers = "";
            BinaryString main_polynomial = new BinaryString("1");
            int cur_cycl_class = 0;
            for (int i = 0; i < polynomials_to_check.Count && cur_cycl_class < cyclomatic_classes.Count; ++i)
            {
                if (isRootOf(cyclomatic_classes.ElementAt(cur_cycl_class).ElementAt(0), polynomials_to_check.ElementAt(i)))
                {
                    text_ += "\n\nДля " + (cur_cycl_class + 1) + "-го цикломатического класса: Р" + (i+1) + "(x) = " 
                        + polynomials_to_check.ElementAt(i).transformToPolynomial();
                    text_ += "\nP" + (i + 1) + "(" + cyclomatic_classes.ElementAt(cur_cycl_class).ElementAt(0).transformToPolynomial() + ") = ";
                    string temp_str1 = "";
                    string temp_str2 = "     =     ";
                    for (int j = 0; j <= polynomials_to_check.ElementAt(i).degree; ++j)
                    {
                        if (polynomials_to_check.ElementAt(i)[j] == '1')
                        {
                            if (temp_str1.Length > 0)
                            {
                                temp_str1 += " + ";
                                temp_str2 += " + ";
                            }
                            if (j == polynomials_to_check.ElementAt(i).degree)
                            {
                                temp_str1 += "1";
                                temp_str2 += "1";
                            }
                            else
                            {
                                temp_str1 += "(" + cyclomatic_classes.ElementAt(cur_cycl_class).ElementAt(0).transformToPolynomial()
                                    + ")^" + (polynomials_to_check.ElementAt(i).degree - j);
                                temp_str2 += (galois_field_.Pow(cyclomatic_classes.ElementAt(cur_cycl_class).ElementAt(0), polynomials_to_check.ElementAt(i).degree - j)
                                    % galois_field_.polynomial).transformToPolynomial();
                            }
                        }
                    }
                    text_ += temp_str1 + temp_str2 + " = 0";
                    if (main_pol_dividers.Length > 0) main_pol_dividers += " * ";
                    main_pol_dividers += "(" + polynomials_to_check.ElementAt(i).transformToPolynomial() + ")";
                    main_polynomial *= polynomials_to_check.ElementAt(i);
                    cur_cycl_class++; i = -1;
                }
            }

            text_ += "\n\nНаходим образующий многочлен для кода:\n";
            if (main_pol_dividers.Contains('*'))
                text_ += "F(x) = " + main_pol_dividers + "     =     " + main_polynomial.transformToPolynomial() + "\n\n";
            else
                text_ += "F(x) = " + main_polynomial.transformToPolynomial() + "\n\n";
        }

        public void show()
        {
            //Создаем форму, в которой отобразим текст
            Form4 new_form = new Form4(previous_form_);
            previous_form_.Hide();
            new_form.text_box.Text = text_;
            new_form.text_box.Font = new_form.Font;
            new_form.Show();
        }
    }
}
