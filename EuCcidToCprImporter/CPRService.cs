using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace EuCcidToCprImporter
{
    public class CPRService
    {
        public static CPR CreateNew(CPR cpr, string gender)
        {
            cpr.CprNumber = GenerateCpr(cpr.CprNumber, gender);
            return cpr;
        }

        private static string GenerateCpr(string cpr, string gender)
        {
            return $"{cpr}-{Generate3Digits()}{(gender == "Male" ? GenerateOddDigit() : GenerateEvenDigit())}";
        }

        private static string Generate3Digits()
        {
            Random generator = new Random();
            return $"{generator.Next(0, 100):D3}";
        }

        private static int GenerateEvenDigit()
        {
            var digits = new List<int> { 0, 2, 4, 6, 8 };
            return ReturnRandom(digits);
        }

        private static int ReturnRandom(List<int> digits)
        {
            var index = new Random().Next(digits.Count);
            return digits[index];
        }

        private static int GenerateOddDigit()
        {
            var digits = new List<int> { 1, 3, 5, 7, 9 };
            return ReturnRandom(digits);
        }
    }
}
