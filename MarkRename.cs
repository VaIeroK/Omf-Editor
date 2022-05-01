using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMF_Editor
{
    public partial class MarkRename : Form
    {
        public MarkRename(string name)
        {
            InitializeComponent();

            textBox1.Text = name;
            this.ActiveControl=textBox1;
        }
        public bool res = false;
        public string content = "";
        private void button1_Click(object sender, EventArgs e)
        {
            content = textBox1.Text;
            res = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            res = false;
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.Control && e.KeyCode == Keys.S)
                button1_Click(sender, e);
            else if (e.KeyCode == Keys.Escape)
                button2_Click(sender, e);
        }

        private void ButtonRename_Click(object sender, EventArgs e)
        {
            Button current = sender as Button;
            content = current.Tag.ToString();
            res = true;
            Close();
        }
    }
}
