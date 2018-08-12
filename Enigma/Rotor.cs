using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma
{
    public class Rotor
    {
        public string Wiring { get; set; }
        private const string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Rotor(string rotor)
        {
            Wiring = rotor;
        }

        private string Advance(string wiring, int number)
        {
            string rotor;
            if (number == 0)
                return wiring;
            if (number < 0)
            {
                int adv = wiring.Length + (number % wiring.Length);
                rotor = wiring.Substring(adv) + wiring.Substring(0, adv);
            }
            else
                rotor = wiring.Substring(number) + wiring.Substring(0, number);
            return rotor;
        }

        public string Encrypt(int advance, string letter)
        {
            string rotor = Advance(Wiring,advance);
            int n = alpha.IndexOf(letter);
            return rotor.Substring(n, 1);
        }

        public string Decrypt(int advance, string letter)
        {
            /*string rotor = Advance(advance);
            int n = rotor.IndexOf(letter);
            return alpha.Substring(n, 1);*/

            string rotor = Advance(Wiring, advance);
            string bet = Advance(alpha, advance);
            letter = bet.Substring(alpha.IndexOf(letter), 1);
            int n = rotor.IndexOf(letter);
            return alpha.Substring(n, 1);
        }
    }
}
