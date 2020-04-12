using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyDruggystore_172244_172442
{
    public partial class Form2 : Form
    {
        CrazyDrugstore crazy = new CrazyDrugstore();
        PriorityQueue priority = new PriorityQueue();
        NodeQueue customer = new NodeQueue();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e) //lineup button
        {
            richTextBox1.Clear();
            string name = textBox1.Text.ToUpper();
            string need = textBox3.Text;

            crazy.BawalUmulit(name);

            if(textBox1.Text.All(char.IsLetter) && textBox3.Text.All(char.IsLetter) && textBox2.Text.All(char.IsDigit))
            {
                if (crazy.BawalUmulit(name) == true)
                {
                    int age = int.Parse(textBox2.Text.ToUpper());
                    if (age >= 65)
                    {
                        crazy.Lineup(name, age);
                        MessageBox.Show("Welcome! " + name);
                        richTextBox1.AppendText("Class: Priority \nName: " + name + "\n" + "Age: " + age + "\n" + "Need: " + need + "\n");

                    }
                    else if (age >= 0 && age < 65)
                    {
                        crazy.Lineup(name, age);
                        MessageBox.Show("Welcome! " + name);
                        richTextBox1.AppendText("Class: Normal \nName: " + name + "\n" + "Age: " + age + "\n" + "Need: " + need + "\n");
                    }
                }
                else
                {
                    MessageBox.Show("Already Queued " + name + "!");
                }
                textBox1.Text = "Name";
                textBox2.Text = "Age";
                textBox3.Text = "Need";
            }
            else
            {
                MessageBox.Show("Invalid input!");
                textBox1.Text = "Name";
                textBox2.Text = "Age";
                textBox3.Text = "Need";
            }
            
            //CALL A METHOD HERE U BITCH
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            //richTextBox1.AppendText("                   -Normal class-                 \n" + crazy.Display() + "\n" + "                   -Priority class-                 \n" + crazy.Displaytwo());
            richTextBox1.AppendText(crazy.Displayfirst());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(crazy.Rotate());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(crazy.Serve());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panel2.Width == 100)
            {
                panel2.Width = 46;
                //richTextBox1.Width = 720;
                label3.Location = new Point(130, 25);
                groupBox1.Location = new Point(100, 70);
            }
            else
            {
                panel2.Width = 100;
                label3.Location = new Point(170, 25);
                groupBox1.Location = new Point(140, 70);
                //richTextBox1.Width = 635;
                //richTextBox1.Location = new Point(614, 136);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText(crazy.Displayfirst());

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(crazy.Rotate());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(crazy.Serve());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //name 
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("                   -Priority class-                 \n" + crazy.Displaytwo());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
