using Kinta.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public static class Abbreviation
    {
        public static string Abbreviate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException();
            }

            var rs = new List<char>();

            var allChars = input.ToCharArray().ToList();

            int wordCount = 0;
            for (int i = 0; i < allChars.Count; i++)
            {
                if (i == 0 && char.IsLetter(allChars[i]))
                {
                    rs.Add(allChars[i]);
                }

                if (allChars[i] == ' ')
                {

                }

                if (!char.IsLetter(allChars[i]))
                {

                }
            }


            return new string(rs.ToArray());
        }

        public static string GetAb(this string input)
        {
            if (input.IsEmpty())
            {
                return "";
            }

            var allChar = input.ToArray().ToList();
            return $"{allChar.First()}{allChar.Except(new List<char> { allChar.First(), allChar.Last() }).ToList().Count}{allChar.Last()}";
        }
    }
}
