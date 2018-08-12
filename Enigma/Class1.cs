using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Enigma
{
    class Class1
    {
        public static string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string shidden = "";
        public static Rotor rotor1 = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
        public static Rotor rotor2 = new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE");
        public static Rotor rotor3 = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO");
        public static Rotor rotor4 = new Rotor("ESOVPZJAYQUIRHXLNFTGKDCMWB");

        public static int notch1 = 0;
        public static int notch2 = 5;
        public static int notch3 = 22;
        public static int notch1second = 0;
        public static int notch2second = 52;
        public static int notch3second = 52;

        //Global Variables
        public int i, ii, iii, iv;
        public int n;
        public int l = 0;
        public bool backspace = false;
        public Regex ralpha = new Regex("[A-Z]");
        public static string sModel = "Enigma I";
        public static string sRotor1 = "I";
        public static string sRotor2 = "II";
        public static string sRotor3 = "III";
        public static string sRotor4 = "";
        public static string sReflector = "B";
        public int[,] ringgeschichte = new int[5, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        public int geschichte = 0;

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

        private void validateN()
        {
            n = n % 26;
            if (n < 0)
                n = n + 26;
            return;
            //if (n < 0)
            //    n = n + 26;
            //if (n > 25)
            //    n = n - 26;
            //if (n < 0 || n > 25)
            //    validateN();
        }
    }
}
