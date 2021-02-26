using System;
using System.Text;

namespace Profit
{
	public class Encoder
	{
		public string Base64Encode(string text)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
		}
		public string Base64Decode(string base64EncodedData)
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
		}
		private int Mod(int a, int b)
		{
			return (a % b + b) % b;
		}
		private string Cipher(string input, string key, bool encipher)
		{		
			for (int i = 0; i < key.Length; ++i)
				if (!char.IsLetter(key[i]))
					return null;

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
	}
}
