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

            text_box.Text += "Декодируем кодовое слово " + code_word.ToString() + ". Для этого разделим его на " +
                "образующий многочлен " + polynomial.ToString() + ":\nI' = B / F = " + code_word.ToString() + 
                " / " + polynomial.ToString() + " = ";
            //BinaryString inf_word = 
           
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

                for (int i = 1; i < doc.Paragraphs.Count; ++i)
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
