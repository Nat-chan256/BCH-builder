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
    public partial class Form4 : Form
    {
        private Form3 previous_form_;
        public Form4(Form3 previous_form)
        {
            InitializeComponent();
            previous_form_ = previous_form;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            previous_form_.Show();
        }
    }
}
