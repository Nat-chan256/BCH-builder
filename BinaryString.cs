using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BChH
{
    public class BinaryString
    {
        private string string_;

        public int degree
        {
            get { return string_.Length - 1; }
        }

        //Обыкновенное сложение (не по модулю 2)
        private BinaryString add(BinaryString bin_str)
        {
            int min_size = (size() < bin_str.size()) ? size() : bin_str.size();
            int max_size = (size() > bin_str.size()) ? size() : bin_str.size();
            string result_string = "";
            byte transp_digit = 0;//Разряд переноса
            //Складываем строки
            for (int i = 0; i < min_size; ++i)
            {
                if (string_[size() - i - 1] == '0' && bin_str.string_[bin_str.size() - i - 1] == '0')
                {
                    result_string += transp_digit.ToString();
                    transp_digit = 0;
                }
                else if (string_[size() - i - 1] == '0' && bin_str.string_[bin_str.size() - i - 1] == '1'
                    || string_[size() - i - 1] == '1' && bin_str.string_[bin_str.size() - i - 1] == '0')
                {
                    if (transp_digit == 0)
                        result_string += "1";
                    else
                        result_string += "0";
                }
                else
                {
                    result_string += transp_digit.ToString();
                    transp_digit = 1;
                }
            }

            string largest_string = (size() > bin_str.size()) ? string_ : bin_str.string_;
            for (int i = min_size; i < max_size; ++i)
            {
                if (transp_digit == 1)
                {
                    switch (largest_string[max_size - i - 1])
                    {
                        case '0':
                            result_string += "1"; transp_digit = 0; break;
                        case '1':
                            result_string += "0"; break;
                    }
                }
                else
                    result_string += largest_string[max_size - i - 1];
            }

            if (transp_digit == 1) result_string += "1";

            result_string = new string(result_string.ToCharArray().Reverse().ToArray()); //Переворачиваем результирующую строку
            return new BinaryString(result_string);
        }
        public BinaryString(string str)
        {
            string_ = str;
        }

        public BinaryString()
        {
            string_ = "0";
        }

        public int size()
        {
            return string_.Length;
        }

        public int weight()
        {
            int result = 0;
            for (int i = 0; i < string_.Length; ++i)
                if (string_[i] == '1') result += 1;
            return result;
        }

        public override string ToString()
        {
            return string_;
        }

        public static BinaryString operator ++(BinaryString bin_str)
        {
            string result_string = "";
            byte transp_digit = 0;//Разряд переноса
            //Прибавляем единицу
            if (bin_str.string_[bin_str.size() - 1] == '0')
            {
                result_string += "1";
                for (int i = 1; i < bin_str.size(); ++i)
                    result_string += bin_str[bin_str.size() - i - 1];
            }
            else
            {
                result_string += "0";
                transp_digit = 1;

                for (int i = 1; i < bin_str.size(); ++i)
                {
                    if (transp_digit == 1)
                    {
                        switch (bin_str[bin_str.size() - i - 1])
                        {
                            case '0':
                                result_string += "1"; transp_digit = 0; break;
                            case '1':
                                result_string += "0"; break;
                        }
                    }
                    else
                        result_string += bin_str[bin_str.size() - i - 1];
                }
           
           
            }

            if (transp_digit == 1) result_string += "1";

            result_string = new string(result_string.ToCharArray().Reverse().ToArray()); //Переворачиваем результирующую строку
            return new BinaryString(result_string);
        }

        //Сложение по модулю 2
        public static BinaryString operator +(BinaryString bin_str1, BinaryString bin_str2)
        {
            int min_size = (bin_str1.size() < bin_str2.size()) ? bin_str1.size() : bin_str2.size();
            int max_size = (bin_str1.size() > bin_str2.size()) ? bin_str1.size() : bin_str2.size();
            string result_string = "";
          
            //Складываем строки
            for (int i = 0; i < min_size; ++i)
            {
                if (bin_str1[bin_str1.size() - i - 1] == bin_str2[bin_str2.size() - i - 1]) result_string += "0";
                else result_string += "1";
            }

            string largest_string = (bin_str1.size() > bin_str2.size()) ? bin_str1.string_ : bin_str2.string_;
            for (int i = min_size; i < max_size; ++i)
            {
                result_string += largest_string[max_size - i - 1];
            }

            result_string = new string(result_string.ToCharArray().Reverse().ToArray()); //Переворачиваем результирующую строку
            return new BinaryString(result_string);
        }

        public static BinaryString operator *(BinaryString bin_str1, BinaryString bin_str2)
        {
            if (bin_str1.weight() == 0 || bin_str2.weight() == 0) //Проверка умножения на ноль
            {
                int size = (bin_str1.size() < bin_str2.size()) ? bin_str1.size() : bin_str2.size();
                string result_str = "";
                for (int i = 0; i < size; ++i)
                    result_str += "0";
                return new BinaryString(result_str);
            }

            string[] temp_arr = new string[bin_str2.weight()];
            string str_of_zeros = "";
            int cur_index = 0;

            for (int i = bin_str2.size() - 1; i >= 0; --i)
            {
                if (bin_str2[i] == '1') temp_arr[cur_index++] = bin_str1.ToString() + str_of_zeros;
                str_of_zeros += "0";
            }

            BinaryString result = new BinaryString(temp_arr[0]);

            for (int i = 1; i < temp_arr.Length; ++i)
            {
                result += new BinaryString(temp_arr[i]);
            }

            return result;
        }

        public static BinaryString operator %(BinaryString bin_str1, BinaryString bin_str2)
        {
            if (bin_str1.cutUnsignificantZeros().size() < bin_str2.cutUnsignificantZeros().size()) return bin_str1;

            BinaryString dividend = bin_str1.cutUnsignificantZeros(); //Делимое
            BinaryString divider = bin_str2.cutUnsignificantZeros(); //Делитель

            while (dividend.size() >= divider.size())
            {
                //Выделяем часть делимого, равную по размеру делителю
                string temp_str = dividend.ToString().Substring(0, divider.size());
                //То, что останется после сложения делителя и части делимого в виде строки
                string new_dividend = (new BinaryString(temp_str) + divider).cutUnsignificantZeros().ToString();
                if (dividend.size() > divider.size()) //Присоединяем оставшийся кусок делимого
                    new_dividend += dividend.ToString().Substring(divider.size(), dividend.size() - divider.size());
                dividend = new BinaryString(new_dividend);
                dividend = dividend.cutUnsignificantZeros();
            }

            if (dividend.size() == 0)
                dividend = new BinaryString("0");

            return dividend;
        }

        //public static BinaryString operator /(BinaryString bin_str1, BinaryString bin_str2)
        //{ 
            
        //}
        
        public char this[int index]
        {
            get
            {
                try
                { return string_[index]; }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            set
            {
                try
                { string_.ToArray()[index] = value; }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
        }

        //Метод, убирающий незначащие нули вначале
        public BinaryString cutUnsignificantZeros()
        {
            if (weight() == 0) return new BinaryString("0");
            string_ = string_.TrimStart('0');
            return this;
        }

        public string transformToPolynomial()
        {
            string result_string = "";
            for (int i = 0; i < size(); ++i)
            {
                if (this[i] == '1')
                {
                    if (result_string.Length > 0)
                        result_string += " + ";
                    if (i == size() - 1)
                        result_string += "1";
                    else
                    {
                        result_string += "x";

                        if (i != size() - 2)
                        result_string += "^" + (size() - i - 1).ToString();
                    }
                }
            }
            return result_string;
        }
    }
}

     
