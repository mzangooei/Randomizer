using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Randomizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            List<int> randomList = new List<int>();
            randomList.Clear();
            int set1 = Convert.ToInt32(textBox1.Text);
            int[] int1 = new int[set1];
            Random rnd1 = new Random();

            richTextBox1.Clear();

            for (int i = 0; i < set1; i++)
            {

                int1[i] = rnd1.Next(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text)+1);

                if (!randomList.Contains(int1[i]))
                {
                    randomList.Add(int1[i]);

                }
                else i--;
            }

            if (checkBox1.Checked) randomList.Sort();
            int j = 0;
           foreach (int x in randomList)
           {
               richTextBox1.Text += randomList[j].ToString() + ", ";
               j++;
           }

           if (richTextBox1.Text == "")
               button2.Enabled = false;
           else button2.Enabled = true;
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private PrintDocument docToPrint = new PrintDocument();    

        private void PrintPage(object sender, PrintPageEventArgs e)
        {

            RectangleF drawRect = new RectangleF(45, 40, 740,990);
  e.Graphics.DrawString("\n " + "1 Set of " + textBox1.Text + " Unique Numbers \n Range: From " + textBox2.Text + " to " + textBox3.Text + " \n\n Results:\n " + richTextBox1.Text, new Font("Segoe UI", 13),
              Brushes.Black, drawRect,
                         StringFormat.GenericTypographic);
        }




        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (richTextBox1.Text == "")
                button2.Enabled = false;
            else button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Name = "PrintPreviewControl1";
            printPreviewDialog1.Dock = DockStyle.Fill;
            printPreviewDialog1.Location = new Point(88, 80);
            printPreviewDialog1.Document = docToPrint;
            printPreviewDialog1.Document.DocumentName = "Research Randomizer";
            printPreviewDialog1.UseAntiAlias = true;
            this.docToPrint.PrintPage +=
            new System.Drawing.Printing.PrintPageEventHandler(PrintPage);
            printPreviewDialog1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
         
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {

                if (Convert.ToInt32(textBox2.Text) < Convert.ToInt32(textBox3.Text))
                    button1.Enabled = true;
                else button1.Enabled = false;

                if ((Convert.ToInt32(textBox1.Text)) >= (Convert.ToInt32(textBox3.Text) - Convert.ToInt32(textBox2.Text))+2)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                }

            }

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }

            if (richTextBox1.Text == "")
                button2.Enabled = false;
            else button2.Enabled = true;
        }
    }
}
