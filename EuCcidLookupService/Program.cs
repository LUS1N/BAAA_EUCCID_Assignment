using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Models;

namespace EuCcidLookupService
{
    class Program
    {
        static void Main(string[] args)
        {
            var messenger = new Messenger("EU-CCID Lookup service");
            var lookupId = messenger.Receive<string>();

            Console.WriteLine($"EU-CCID Lookup service received request for {lookupId}");

            var euccid = Storage.GetUEuccidByNumber(lookupId);
            messenger.Reply(euccid);

            Console.WriteLine($"Replied with: {euccid}");
        }
    }
}
