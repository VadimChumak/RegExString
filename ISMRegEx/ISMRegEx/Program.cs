using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISMRegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //string reg1 = @"\w+[aeiouy]\b";
            string reg1 = @"\w+[aeiouyаоуеиіїяюєыэ]\b";
            string str = Console.ReadLine();
            Regex RegEx = new Regex(reg1, RegexOptions.IgnoreCase);
            MatchCollection match = RegEx.Matches(str);
            if (match.Count > 0)
            {
                int i = 0;
                foreach (Match m in match)
                {
                    i++;
                }
                Console.WriteLine("Знайдено слів , що закінчуються на голосну літеру - {0}", i);
            }
            else { Console.WriteLine("Слова , що закінчуються на голосну , відсутні!"); }
            Console.ReadKey();
            string reg2 = @"\b\w{1,4}\b";
            Regex RegEx2 = new Regex(reg2, RegexOptions.IgnoreCase);
            MatchCollection match2 = RegEx2.Matches(str);
            if (match2.Count > 0) {
                foreach (Match a in match2)
                {
                   Console.WriteLine(a.Value);
                }
            }
            Console.ReadKey();
            string reg3 = @"((([А-Яа-я]+)*)[A-Za-z]+([А-Яа-я]+)*)";
            Regex RegEx3 = new Regex(reg3);
            string result = RegEx3.Replace(str,"");
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
