using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma
{
    public partial class Form1 : Form
    {
        public Regex ralpha = new Regex("[A-Z]");
        public int i, ii, iii, iv;
        public int n;
        public int l = 0;
        public bool backspace = false;
        
        public static string sModel = "Enigma I";
        public static string sRotor1 = "I";
        public static string sRotor2 = "II";
        public static string sRotor3 = "III";
        public static string sRotor4 = "";
        public static string sReflector = "B";
        public int[,] ringgeschichte = new int[5, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        public int geschichte = 0;
        //B style reflector
        public static Rotor reflector1 = new Rotor("YRUHQSLDPXNGOKMIEBFZCWVJAT");
        //public string input, output;

        public static int notch1 = 0;
        public static int notch2 = 5;
        public static int notch3 = 22;
        public static int notch1second = 0;
        public static int notch2second = 52;
        public static int notch3second = 52;

        public static string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string shidden = "";
        public static Rotor rotor1 = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
        public static Rotor rotor2 = new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE");
        public static Rotor rotor3 = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO");
        public static Rotor rotor4 = new Rotor("ESOVPZJAYQUIRHXLNFTGKDCMWB");

        public static string[] steckerbrett = new string[2] { "", "" };
        public static int[] ringstellung = new int[4] { 0, 0, 0, 0 };

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 27)
                numericUpDown1.Value = 1;
            if (numericUpDown1.Value == 0)
                numericUpDown1.Value = 26;
            //lblRotorI.Text = alpha.Substring(Int32.Parse((numericUpDown1.Value - 1).ToString()), 1);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 27)
                numericUpDown2.Value = 1;
            if (numericUpDown2.Value == 0)
                numericUpDown2.Value = 26;
            //lblRotorII.Text = alpha.Substring(Int32.Parse((numericUpDown2.Value - 1).ToString()), 1);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value == 27)
                numericUpDown3.Value = 1;
            if (numericUpDown3.Value == 0)
                numericUpDown3.Value = 26;
            //lblRotorIII.Text = alpha.Substring(Int32.Parse((numericUpDown3.Value - 1).ToString()), 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            EnigmaKeyDown(sender,e);
        }

        private void EnigmaKeyDown(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Upper;
            if (backspace == true)
            {
                if (textBox2.Text.Substring(textBox2.Text.Length - 1, 1) != " " && ralpha.IsMatch(textBox2.Text.Substring(textBox2.Text.Length - 1, 1)))
                    Decrement_Rotors();
                l--;
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                return;
            }

            if (textBox1.Text.Length <= 0)
            {
                textBox2.Text = "";
                return;
            }
            if (l == textBox1.Text.Length)
            {
                //If pasted value is same length
                l = 0;
                textBox2.Text = "";
            }
            if (l + 1 < textBox1.Text.Length)
            {
                //If pasted value is greater
                l = 0;
                textBox2.Text = "";
            }
            if (l + 1 > textBox1.Text.Length)
            {
                //If pasted value is less
                l = 0;
                textBox2.Text = "";
            }
            if (l + 1 != textBox1.Text.Length)
            {
                Geschichten();
                int o = l;
                for (int x = 1; x <= textBox1.Text.Length - o; x++)
                {
                    Encrypt();
                    l++;
                }
            }
            else//encrypt by one
            {
                if (textBox1.Text.Length == 1)
                    Geschichten();
                Encrypt();
            }
            l = textBox1.Text.Length;
        }

        private void Geschichten()
        {
            //Geschichte
            if (geschichte == 5)
            {
                ringgeschichte[0, 0] = ringgeschichte[1, 0];
                ringgeschichte[0, 1] = ringgeschichte[1, 1];
                ringgeschichte[0, 2] = ringgeschichte[1, 2];
                ringgeschichte[0, 3] = ringgeschichte[1, 3];
                ringgeschichte[1, 0] = ringgeschichte[2, 0];
                ringgeschichte[1, 1] = ringgeschichte[2, 1];
                ringgeschichte[1, 2] = ringgeschichte[2, 2];
                ringgeschichte[1, 3] = ringgeschichte[2, 3];
                ringgeschichte[2, 0] = ringgeschichte[3, 0];
                ringgeschichte[2, 1] = ringgeschichte[3, 1];
                ringgeschichte[2, 2] = ringgeschichte[3, 2];
                ringgeschichte[2, 3] = ringgeschichte[2, 3];
                ringgeschichte[3, 0] = ringgeschichte[4, 0];
                ringgeschichte[3, 1] = ringgeschichte[4, 1];
                ringgeschichte[3, 2] = ringgeschichte[4, 2];
                ringgeschichte[3, 3] = ringgeschichte[4, 3];
                geschichte--;
            }
            ringgeschichte[geschichte, 0] = (int)(numericUpDown1.Value);
            ringgeschichte[geschichte, 1] = (int)(numericUpDown2.Value);
            ringgeschichte[geschichte, 2] = (int)(numericUpDown3.Value);
            //ringgeschichte[geschichte, 3] = (int)(numericUpDown4.Value);
            geschichte++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            l = 0;
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1;
        }

        private void Increment_Rotors()
        {
            iii++;
            if (iii > 25)
                iii = iii - 26;

            if (ii == (notch2 - 1) || ii == (notch2second - 1))
            {
                i++;
                ii++;
            }
            else
            {

                if (iii == notch3 || iii == notch3second)
                {
                    ii++;
                }
            }
            if (ii > 25)
                ii = ii - 26;

            if (i > 25)
                i = i - 26;
        }

        private void Decrement_Rotors()
        {
            iii--;
            if (iii < 0)
                iii = iii + 26;

            if (ii == (notch2) || ii == notch3second)
            {
                i--;
                ii--;
            }
            else
            {
                if (iii == (notch3 - 1) || iii == (notch2second - 1))
                {
                    ii--;
                }
            }
            if (ii < 0)
                ii = ii + 26;
            if (i < 0)
                i = i + 26;
            numericUpDown1.Value = i + 1;
            numericUpDown2.Value = ii + 1;
            numericUpDown3.Value = iii + 1;
        }

        private void Encrypt()
        {
            shidden = "";
            string sOutput = "";
            string sInput = textBox1.Text.Substring(l, 1);
            i = Int32.Parse(numericUpDown1.Value.ToString()) - 1;
            ii = Int32.Parse(numericUpDown2.Value.ToString()) - 1;
            iii = Int32.Parse(numericUpDown3.Value.ToString()) - 1;
            //iv = Int32.Parse(numericUpDown4.Value.ToString()) - 1;

            if (sInput == " ")
            {
                sOutput = " ";
                textBox2.Text += " ";
                return;
            }
            if (ralpha.IsMatch(sInput) == false)
            {
                sOutput = sInput;
                textBox2.Text += sOutput;
                return;
            }
            if (steckerbrett[0].Contains(sInput))
            {
                sOutput = steckerbrett[1].Substring(steckerbrett[0].IndexOf(sInput), 1);
                shidden = sInput + "->" + sOutput;
            }
            else if (steckerbrett[1].Contains(sInput))
            {
                sOutput = steckerbrett[0].Substring(steckerbrett[1].IndexOf(sInput), 1);
                shidden = sInput + "->" + sOutput;
            }
            else//Not a plugged character
            {
                shidden = sInput;
                sOutput = sInput;
            }
            Increment_Rotors();//step on typing and before encryption

            sOutput = rotor3.Encrypt(iii - ringstellung[2], sOutput);
            shidden += sOutput;
            sOutput = rotor2.Encrypt(ii - iii - ringstellung[1] + ringstellung[2], sOutput);
            shidden += sOutput;
            sOutput = rotor1.Encrypt(i - ii - ringstellung[0] + ringstellung[1], sOutput);
            shidden += sOutput;

            if (sRotor4 != "")
            {
                sOutput = rotor4.Encrypt(iv - ringstellung[3], sOutput);
                shidden += sOutput;
            }

            shidden += "<-->";
            sOutput = reflector1.Encrypt(ringstellung[0] - i, sOutput);
            shidden += sOutput;

            if (sRotor4 != "")
            {
                sOutput = rotor4.Decrypt(iv - ringstellung[3], sOutput);
                shidden += sOutput;
            }

            sOutput = rotor1.Decrypt(i - ringstellung[0], sOutput);
            shidden += sOutput;
            sOutput = rotor2.Decrypt(ii - ringstellung[1], sOutput);
            shidden += sOutput;
            sOutput = rotor3.Decrypt(iii - ringstellung[2], sOutput);
            shidden += sOutput;

            if (steckerbrett[0].Contains(sOutput))
            {
                sOutput = steckerbrett[1].Substring(steckerbrett[0].IndexOf(sOutput), 1);
                shidden += sInput + "->" + sOutput;
            }
            else if (steckerbrett[1].Contains(sOutput))
            {
                sOutput = steckerbrett[0].Substring(steckerbrett[1].IndexOf(sOutput), 1);
                shidden += sInput + "->" + sOutput;
            }

            //numericUpDown4.Value = iv + 1;
            numericUpDown3.Value = iii + 1;
            numericUpDown2.Value = ii + 1;
            numericUpDown1.Value = i + 1;
            textBox2.Text += sOutput;
            //tbxHidden.Text = shidden;
        }


    }
}
