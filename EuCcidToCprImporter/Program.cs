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
            // send message with reply address of translator
            var sendMessenger = new Messenger("TranslatorIn", "EU-CCID Lookup service");
            var euccidNumber = "09042017-123456";
            sendMessenger.Send(euccidNumber);

            Console.WriteLine($"Import data request sent about EU-CCID: {euccidNumber}\n");

            var receiverMessenger = new Messenger("New CPR Service");
            var prelCpr = receiverMessenger.Receive<PreliminaryCpr>();

            Console.WriteLine($"Received data from translator:\n{prelCpr}\n");

            var completeCPR = CPRService.CreateNew(prelCpr);
            CprSaver.Save(completeCPR);

            Console.WriteLine($"Generate CPR number to make this CPR complete. Generated CPR number for '{prelCpr.Gender}' : {completeCPR.CprNumber}\n {completeCPR}");
        }
    }

}
