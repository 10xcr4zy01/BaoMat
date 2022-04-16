using System;

namespace BaoMat
{
    public partial class Form1 : Form
    {
		public string input;
		public string output;
		public string key;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }




		#region Vigenere

		private static int Mod(int a, int b)
		{
			return (a % b + b) % b;
		}

		private string Cipher(string input, string key, bool encipher)
		{
			for (int i = 0; i < key.Length; ++i)
				if (!char.IsLetter(key[i]))
					return null; // Error

			string output = string.Empty;
			int nonAlphaCharCount = 0;

			for (int i = 0; i < input.Length; ++i)
			{
				if (char.IsLetter(input[i]))
				{
					bool cIsUpper = char.IsUpper(input[i]);
					char offset = cIsUpper ? 'A' : 'a';
					int keyIndex = (i - nonAlphaCharCount) % key.Length;
					int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
					k = encipher ? k : -k;
					char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
					output += ch;
				}
				else
				{
					output += input[i];
					++nonAlphaCharCount;
				}
			}

			return output;
		}

		public string Encipher(string input, string key)
		{
			return Cipher(input, key, true);
		}

		public string Decipher(string input, string key)
		{
			return Cipher(input, key, false);
		}

        private void encipherBtn_Click(object sender, EventArgs e)
        {
			if(viInputTxB.Text != "" && viKeyTxB.Text != "")
            {
				input = viInputTxB.Text;
				key = viKeyTxB.Text;
				output = Encipher(input, key);
				SetOutPutLbl(output);
			}
        }

        private void decipherBtn_Click(object sender, EventArgs e)
        {
			if (viInputTxB.Text != "" && viKeyTxB.Text != "")
			{
				input = viInputTxB.Text;
				key = viKeyTxB.Text;
				output = Decipher(input, key);
				SetOutPutLbl(output);
			}

		}

		private void SetOutPutLbl (string text)
        {
			viOutPutTxB.Text = text;
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}