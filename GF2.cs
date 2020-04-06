using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BChH
{
    //Класс полей Галуа GF(2^degree_)
    class GF2
    {
        private int degree_;
        public int degree
        {
            get { return degree_; }
        }
        private BinaryString[] elements_;
        private BinaryString polynomial_;
        public BinaryString polynomial
        {
            get { return polynomial_; }
            set { polynomial_ = value; }
        }

        public GF2(int degree, BinaryString polynomial)
        {
            polynomial = polynomial.cutUnsignificantZeros();
            //Проверка на соответствие degree степени полинома polinomial
            if (degree != polynomial.size() - 1)
            {
                MessageBox.Show("Степень образующего многочлена не соответствует степени поля Галуа.");
                Application.Exit();
            }

            degree_ = degree;
            elements_ = new BinaryString[(int)Math.Pow(2, degree_)];
            polynomial_ = polynomial;

            //Формируем нулевой элемент
            string temp_str = "";
            for (int i = 0; i < degree_; ++i)
                temp_str += "0";
            elements_[0] = new BinaryString(temp_str);

            //Формируем ненулевые элементы поля
            for (int i = 1; i < elements_.Length; ++i)
            {
                elements_[i] = elements_[i - 1];
                ++elements_[i];
            }
        }

        public BinaryString element(int index)
        {
            try
            {
                return elements_[index];
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public bool isPrimitive(BinaryString element)
        {
            if (element.cutUnsignificantZeros().ToString() == "1" || element.cutUnsignificantZeros().ToString() == "0")
                return false;

            BinaryString el = element % polynomial_;
            for (int i = 1; i < (int)Math.Pow(2, degree_) - 1; ++i)
            {
                if (el.cutUnsignificantZeros().ToString() == "1") return false;
                el *= element;
                el %= polynomial_;
            }

            return true;
        }

        //Метод, генерирующий неприводимые полиномы нужной степени
        public static List<BinaryString> generatePolynomialsOfDegree(int deg)
        {
            List<BinaryString> result_list = new List<BinaryString>();
            
            //Генерируем первый полином нужной степени 
            string temp_str = "1";
            for (int i = 0; i < deg; ++i)
            {
                if (i == deg - 1)
                    temp_str += '1';
                else
                    temp_str += '0';
            }
            BinaryString cur_polynomial = new BinaryString(temp_str);

            //Проверяем на неприводимость все полиномы степени deg
            while (cur_polynomial.size() == deg + 1)
            {
                //Делим текущий полином на все неприводимые полиномы степеней вплоть до deg/2
                BinaryString cur_divider = new BinaryString("10");
                while (cur_divider.size() <= (deg + 2) / 2)
                {
                    if ((cur_polynomial % cur_divider).ToString() == "0") //Если нашли делитель полинома
                    {
                        break;
                    }
                    ++cur_divider;
                }
                if (cur_divider.size() > (deg + 2) / 2) result_list.Add(cur_polynomial);
                ++cur_polynomial;
            }
           
            return result_list;
        }

        public BinaryString Pow(BinaryString b_string, int degree)
        {
            if (degree < 0)
                return new BinaryString("0");
            if (degree == 0)
                return new BinaryString("1");

            BinaryString result = b_string;
            for (int i = 1; i < degree; ++i)
                result *= b_string;

            result %= polynomial_;

            return result;
        }
    }
}
