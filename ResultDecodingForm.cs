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
    using Word = Microsoft.Office.Interop.Word;

    public partial class ResultDecodingForm : Form
    {
        private DecodingForm previous_form_;
        public ResultDecodingForm(DecodingForm prev_form, BinaryString polynomial, BinaryString code_word)
        {
            InitializeComponent();

            //Связываем с предыдущей формой
            previous_form_ = prev_form;

            text_box.Text += "Пусть B' - полученное кодовое слово (с ошибками или без), \nB - отправленное " +
                "кодовое слово\nB = B', если B' не " +
                "содержит ошибок;\nB = B' + e, иначе (e - вектор ошибок)\n\nДекодируем кодовое " +
                "слово " + code_word.ToString() + ". Для этого разделим его на " +
                "образующий многочлен " + polynomial.ToString() + ":\nI' = B' / F = " + code_word.ToString() + 
                " / " + polynomial.ToString() + " = ";
            BinaryString inf_word = code_word / polynomial;

            text_box.Text += inf_word.ToString() + "\n\nОстаток от деления: e = ";
            BinaryString remainder = code_word % polynomial;
            text_box.Text += remainder.ToString();

            if (remainder.weight() == 0)
            {
                text_box.Text += "\nВес остатка равен 0, следовательно, кодовое слово В не содержит ошибок. Значит, " +
                    "I =  I' = " + inf_word.ToString() + " - искомое информационное слово.";
                return;
            }

            if (remainder.weight() <= (prev_form.d - 1) / 2)
            {
                text_box.Text += "\n\nКоличество исправляемых ошибок: r = " + (prev_form.d - 1) / 2 + "\n\nВес " +
                    "остатка w(e) = " + remainder.weight() + "\n\nТак как выполняется неравенство w <= r, то мы " +
                    "можем исправить ошибки в полученном кодовом слове и найти информационное слово следующим " +
                    "образом:\nI = (B' + e) / F = (" + code_word.ToString() + " + " + remainder.ToString() + ") / " +
                    polynomial.ToString() + " = ";
                BinaryString B = code_word + remainder;
                text_box.Text += B.ToString() + " / " + polynomial.ToString() + " = ";
                BinaryString I = B / polynomial;
                text_box.Text += I.ToString();
                return;
            }

            text_box.Text += "\nВес остатка: w(e) = " + remainder.weight() + ".\n\nКоличество исправляемых ошибок:" +
                " r =" + (prev_form.d - 1) / 2 + "\n\nТак как w > r   (1), то для исправления ошибок в полученном кодовом" +
                " слове необходимо делать циклические сдвиги B' до тех пор, пока условие (1) не нарушится.\n\nПусть " +
                "Bi - слово, полученное после i циклических сдвигов вправо слова B', ei - остаток от деления Bi на F." +
                " Выполним сдвиги: ";

            BinaryString cur_b = code_word.RightCyclShift(1);
            int i;
            for (i = 1; i < code_word.size(); ++i)
            {
                text_box.Text += "\n\nB" + i + " = " + cur_b.ToString() + ", e" + i + " = ";
                BinaryString cur_rem = cur_b % polynomial;
                text_box.Text += cur_rem.ToString() + ", w(e" + i + ") = " + cur_rem.weight();

                if (cur_rem.weight() <= (prev_form.d - 1) / 2)
                {
                    text_box.Text += "\n\nУсловие (1) нарушилось, следовательно, можно исправить ошибки:\nB'" + i +
                        " = B" + i + " + e" + i + " = " + cur_b.ToString() + " + " + cur_rem.ToString() + " = ";
                    BinaryString res_of_add = cur_b + cur_rem;
                    text_box.Text += res_of_add.ToString() + "\nДля этого необходимо сделать " + i + " циклических " +
                        "сдвигов влево полученного слова: B = ";
                    BinaryString new_b = res_of_add.LeftCyclShift(i);
                    text_box.Text += new_b.ToString() + "\n\nТеперь мы можем получить информационное слово: I = B / F = " +
                        new_b.ToString() + " / " + polynomial.ToString() + " = ";
                    BinaryString I = new_b / polynomial;
                    text_box.Text += I.ToString();
                    break;
                }

                cur_b = cur_b.RightCyclShift(1);
            }
            if (i == code_word.size())
                text_box.Text += "\n\nНи один сдвиг слова B' не дал треубемого остатка от деления. Следовательно, " +
                    "в полученном слове невозможно исправить ошибки.";
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_file_dialog = new SaveFileDialog();
            save_file_dialog.Filter = "Microsoft Word Files (*.doc)|*.doc" +
                "| Microsoft Word Compressed Files (*.docx)|*.docx";
            save_file_dialog.DefaultExt = "doc";
            if (save_file_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && save_file_dialog.FileName.Length > 0)
            {
                //Сохраняем документ
                Word.Application app = new Word.Application();
                app.Visible = false;
                Word.Document doc = app.Documents.Add();
                doc.Paragraphs[1].Range.Text = this.text_box.Text;

                for (int i = 1; i <= doc.Paragraphs.Count; ++i)
                {
                    doc.Paragraphs[i].Range.Font.Name = "Times New Roman";
                    doc.Paragraphs[i].Range.Font.Size = 14;
                }

                doc.SaveAs2(save_file_dialog.FileName);
                doc.Close();
                app.Quit();
            }
        }

        private void ResultDecodingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            previous_form_.Show();
        }
    }
}
