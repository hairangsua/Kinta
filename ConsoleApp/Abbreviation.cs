//using Kinta.Framework.Helper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace ConsoleApp
//{
//    public class Abbreviation
//    {
//        public static string Abbreviate(string input)
//        {
//            if (string.IsNullOrEmpty(input))
//            {
//                throw new ArgumentNullException();
//            }

//            var lst = input.Split().ToList();

//            if (lst.IsNullOrEmpty())
//            {
//                throw new Exception();
//            }

//            var lstRes = new List<string>();

//            foreach (var str in lst)
//            {
//                lstRes.Add(GetAbString(str));
//            }
//        }

//        public static string GetAbString(string input)
//        {
//            if (input.Length <= 3)
//            {
//                return input;
//            }

//            var allChar = input.ToCharArray().ToList();

//            var allWorldInAllChar = allChar.FindAll(x => char.IsLetter(x));
//            if (allWorldInAllChar.Count <= 3)
//            {
//                return input;
//            }

//            var countOfNonWordChar = allChar.Count(x => !char.IsLetter(x));
//            var countOfWordChar = allChar.Count(x => char.IsLetter(x));

//            if (countOfNonWordChar == 0 && countOfWordChar == 0)
//            {
//                //deo bao h xay ra
//            }

//            if (countOfNonWordChar == 0 && countOfWordChar == 1)
//            {
//                //deo bao h xay ra
//            }

//            if (countOfNonWordChar == 0 && countOfWordChar > 1)
//            {
//                //da loai bo truong hop chuoi <= 3 ky tu
//                //deo bao h xay ra
//                return GetAb(input);
//            }
//            if (countOfNonWordChar == 1 && countOfWordChar == 1)
//            {
//                //deo bao h xay ra
//            }

//            if (countOfNonWordChar == 1 && countOfWordChar > 1)
//            {
//                //da loai bo truong hop chuoi <= 3 ky tu       

//                var nonChar = allChar.Find(x => !char.IsLetter(x));

//                var splitByNonWordChar = input.Split(nonChar);

//                return $"{GetAb(new string(splitByNonWordChar[0]))}{nonChar}{GetAb(new string(splitByNonWordChar[1]))}";
//            }

//            if (countOfNonWordChar > 1 && countOfWordChar > 1)
//            {

//            }






//        }

//        public static string GetAb(this string input)
//        {
//            if (input.IsEmpty())
//            {
//                return "";
//            }

//            var allChar = input.ToArray().ToList();
//            return $"{allChar.First()}{allChar.Except(new List<char> { allChar.First(), allChar.Last() }).ToList().Count}{allChar.Last()}";
//        }
//    }
//}
