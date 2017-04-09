using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Models;

namespace EuCcidToCprImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var messenger = new Messenger("EU-CCID Lookup response", "EU-CCID Lookup service");

            var euccidNumber = "09042017-123456";
            Console.WriteLine($"Import data about EU-CCID: {euccidNumber}");

            messenger.Send(euccidNumber);
            var euCcid = messenger.Receive<EUCCID>();

            Console.WriteLine($"Received data: {euCcid}");

            var preliminaryCpr = new Translator.EuccidCprTranslator().EuCcidToCpr(euCcid);
            Console.WriteLine($"Translate values into CPR: {preliminaryCpr}");

            var completeCPR = CPRService.CreateNew(preliminaryCpr, euCcid.Gender);
            Console.WriteLine($"Generate CPR number to make this CPR complete. Generated CPR number for '{euCcid.Gender}' : {completeCPR.CprNumber}");
            
            CprSaver.Save(completeCPR);

            Console.WriteLine();

        }
    }

}
