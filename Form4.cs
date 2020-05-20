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

    public partial class Form4 : Form
    {
        private Form3 previous_form_;
        private CodingForm coding_form_;
        private DecodingForm decoding_form_;
        private int d_;
        public int d
        {
            get { return d_; }
        }
        public Form4(Form3 previous_form, BinaryString polynomial, int n, int k, int d)
        {
            InitializeComponent();
            d_ = d;
            previous_form_ = previous_form;
            coding_form_ = new CodingForm(polynomial, n, k, this);
            decoding_form_ = new DecodingForm(polynomial, n, k, this);
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void b_code_Click(object sender, EventArgs e)
        {
            coding_form_.Show();
            this.Hide();
        }

        private void b_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            previous_form_.Show();
        }

        private void text_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void b_decode_word_Click(object sender, EventArgs e)
        {
            decoding_form_.Show();
            this.Hide();
        }
    }
}
