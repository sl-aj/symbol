using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Program
{

	public static void Main()
	{
		string s = @"The Tao gave birth to machine language. Machine language gave birth
to the assembler.
The assembler gave birth to the compiler. Now there are ten thousand
languages.
Each language has its purpose, however humble. Each language
expresses the Yin and Yang of software. Each language has its place within
the Tao.
But do not program in COBOL if you can avoid it.
        -- Geoffrey James, ""The Tao of Programming""";

		TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
		s = textInfo.ToLower(s);

		
		var matches = Regex.Matches(s, @"(\w+)").OfType<Match>().Select(m => m.Groups[0].Value).Distinct().ToList();
		
		var symbols = matches.Where(i => !i.Substring(1).Contains(i[0])).Select(i => i[0].ToString()).ToList();
		bool flag = false;
		for (int i = 0; i < symbols.Count; i++)
		{
			for (int j = i + 1; j < symbols.Count; j++)
			{
				if (symbols[i] == symbols[j])
				{
					symbols.RemoveAt(j);
					flag = true;
					j--;
				}
			}
			if (flag)
			{
				symbols.RemoveAt(i);
				i--;
				flag = false;
			}
			else
			{
				Console.WriteLine(symbols[i]);
				break;
			}
		}
	}

}
