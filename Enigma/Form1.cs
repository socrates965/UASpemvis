using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma
{
    public partial class Form1 : Form
    {
        Class1 class1 = new Class1();
        int rotor1, rotor2, rotor3;
        public Form1()
        {
            InitializeComponent();
            
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            
            //machine.SetCode(rotor1, rotor2, rotor3);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotor1 = Int32.Parse(comboBox1.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotor2 = Int32.Parse(comboBox2.Text);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotor3 = Int32.Parse(comboBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (class1.backspace == true)
            {
                if (textBox2.Text.Substring(textBox2.Text.Length - 1, 1) != " " && class1.ralpha.IsMatch(textBox2.Text.Substring(textBox2.Text.Length - 1, 1)))
                    Decrement_Rotors();
                class1.l--;
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                return;
            }

            if (textBox1.Text.Length <= 0)
            {
                textBox2.Text = "";
                return;
            }
            if (class1.l == textBox1.Text.Length)
            {
                //If pasted value is same length
                class1.l = 0;
                textBox2.Text = "";
            }
            if (class1.l + 1 < textBox1.Text.Length)
            {
                //If pasted value is greater
                class1.l = 0;
                textBox2.Text = "";
            }
            if (class1.l + 1 > textBox1.Text.Length)
            {
                //If pasted value is less
                class1.l = 0;
                textBox2.Text = "";
            }
            if (class1.l + 1 != textBox1.Text.Length)
            {
                Geschichten();
                int o = class1.l;
                for (int x = 1; x <= textBox1.Text.Length - o; x++)
                {
                    Encrypt();
                    class1.l++;
                }
            }
            else//encrypt by one
            {
                if (textBox1.Text.Length == 1)
                    Geschichten();
                Encrypt();
            }
            class1.l = textBox1.Text.Length;
        }
    }
}
