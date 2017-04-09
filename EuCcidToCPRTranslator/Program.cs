using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Models;

namespace EuCcidToCPRTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            var messenger = new Messenger("TranslatorIn", "New CPR Service");
            var euccid = messenger.Receive<EUCCID>();

            Console.WriteLine($"Translator received EU-CCID:\n{euccid}\n");

            var preliminaryCpr = new Translator.EuccidCprTranslator().EuCcidToCpr(euccid);
            messenger.Send(preliminaryCpr);

            Console.WriteLine($"Translated it to preliminary CPR:\n{preliminaryCpr}\n And sent it to the New CPR Service");
        }
    }
}
