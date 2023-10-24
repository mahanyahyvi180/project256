using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp128
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog op = new OpenFileDialog();
            op.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*";
            op.ShowDialog();
            System.IO.StreamReader reader = new System.IO.StreamReader(op.FileName);
            while (reader.Peek()!= -1)
            {
                string s = reader.ReadLine();
                string[] temp = s.Split(';');
                listBox1.Items.Add(temp[0]);
                listBox1.Items.Add(temp[1]);
                listBox1.Items.Add(temp[2]);
                listBox1.Items.Add(temp[3]);

            }
            reader.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            System.IO.FileStream f = new System.IO.FileStream("G:\\Users\\test.txt", System.IO.FileMode.Create);
            byte[] b = System.Text.Encoding.Unicode.GetBytes(textBox1.Text);
            //f.Write(b, 0, b.Length);
            foreach (byte temp in b)
            {
                if (temp != 32 && temp != 0)
                    f.WriteByte(temp);
            }



            f.Flush();
            f.Close();
        }
    }
}
