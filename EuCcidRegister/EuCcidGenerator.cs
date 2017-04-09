using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuCcidRegister
{
    public class EuCcidGenerator
    {
        public static string Generate(string birthDate)
        {
            Random generator = new Random();
            // generate a random 6 digit number 
            return $"{birthDate}-{generator.Next(0, 1000000):D6}";
        }
    }
}
