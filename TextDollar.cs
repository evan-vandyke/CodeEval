using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextDollar
{
	class Program
	{
		static Dictionary<char, string> GetOnes()
		{
			Dictionary<char, string> Ones = new Dictionary<char, string>();
			Ones.Add('1', "One");
			Ones.Add('2', "Two");
			Ones.Add('3', "Three");
			Ones.Add('4', "Four");
			Ones.Add('5', "Five");
			Ones.Add('6', "Six");
			Ones.Add('7', "Seven");
			Ones.Add('8', "Eight");
			Ones.Add('9', "Nine");
			return Ones;
		}
		static Dictionary<char, string> GetTeens()
		{
			Dictionary<char, string> Teens = new Dictionary<char, string>();
			Teens.Add('0', "Ten");
			Teens.Add('1', "Eleven");
			Teens.Add('2', "Twelve");
			Teens.Add('3', "Thirteen");
			Teens.Add('4', "Fourteen");
			Teens.Add('5', "Fifteen");
			Teens.Add('6', "Sixteen");
			Teens.Add('7', "Seventeen");
			Teens.Add('8', "Eighteen");
			Teens.Add('9', "Nineteen");
			return Teens;
		}
		static Dictionary<char, string> GetTens()
		{
			Dictionary<char, string> Tens = new Dictionary<char, string>();
			Tens.Add('2', "Twenty");
			Tens.Add('3', "Thirty");
			Tens.Add('4', "Forty");
			Tens.Add('5', "Fifty");
			Tens.Add('6', "Sixty");
			Tens.Add('7', "Seventy");
			Tens.Add('8', "Eighty");
			Tens.Add('9', "Ninety");
			return Tens;
		}
		static void Main(string[] args)
		{
			string[] eachline = File.ReadAllLines(args[0]);
			Dictionary<char, string> Ones = GetOnes();
			Dictionary<char, string> Teens = GetTeens();
			Dictionary<char, string> Tens = GetTens();


			foreach (string val in eachline)
			{
				StringBuilder sb = new StringBuilder();
				string hundreds = "";
				string thousands = "";
				string millions = "";

				if (val.Length <= 3)
				{
					Convert(val, Ones, Teens, Tens, sb);
					Console.WriteLine(sb + "Dollars");
				}
				else if (val.Length <= 6)
				{
					hundreds = val.Substring(val.Length - 3);
					thousands = val.Substring(0, val.Length - 3);

					thousands = Convert(thousands, Ones, Teens, Tens, sb) + "Thousand";
					sb.Clear();
					hundreds = Convert(hundreds, Ones, Teens, Tens, sb) + "Dollars";
					Console.WriteLine(thousands + hundreds);
				}
				else
				{
					hundreds = val.Substring(val.Length - 3);
					thousands = val.Substring(val.Length - 6, 3);
					millions = val.Substring(0, val.Length - 6);

					millions = Convert(millions, Ones, Teens, Tens, sb) + "Million";
					sb.Clear();
					if (thousands != "000")
					{
						thousands = Convert(thousands, Ones, Teens, Tens, sb) + "Thousand";
						sb.Clear();
						hundreds = Convert(hundreds, Ones, Teens, Tens, sb) + "Dollars";
						Console.WriteLine(millions + thousands + hundreds);
					}
					else
					{
						hundreds = Convert(hundreds, Ones, Teens, Tens, sb) + "Dollars";
						Console.WriteLine(millions + hundreds);
					}
				}
			}
		}

		static StringBuilder Convert(string val, Dictionary<char, string> Ones, Dictionary<char, string> Teens, Dictionary<char, string> Tens, StringBuilder sb)
		{
			if ((val.Length == 3) && (val != "000"))
			{
				if (Ones.ContainsKey(val[0]))
				{
					sb.Append(Ones[val[0]] + "Hundred");
				}
				if (val[1] == '1')
				{
					sb.Append(Teens[val[2]]);
					return sb;
				}
				else
				{
					if (Tens.ContainsKey(val[1]))
					{
						sb.Append(Tens[val[1]]);
					}
				}
				if (Ones.ContainsKey(val[2]))
				{
					sb.Append(Ones[val[2]]);
				}
				return sb;  
			}
			if (val.Length == 2)
			{
				if (val[0] == '1')
				{
					sb.Append(Teens[val[1]]);
					return sb;
				}
				else
				{
					sb.Append(Tens[val[0]]);
					sb.Append(Ones[val[1]]);
					return sb;
				}
			}
			else
			{
				if(Ones.ContainsKey(val[0]))
				{
					sb.Append(Ones[val[0]]);
				}
			}
			return sb;
		}
	}
}