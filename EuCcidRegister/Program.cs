using System;
using EuCcidRegister;
using Helpers;
using Models;

namespace NewEuCcidService
{
    class Program
    {
        static void Main(string[] args)
        {
            var messenger = new Messenger("NewEuccidChannel");

            Console.WriteLine("New EU-CCID Service waiting for requests");
            var newEuccid = messenger.Receive<EUCCID>();

            Console.WriteLine("Request received:");
            Console.WriteLine(newEuccid);

            newEuccid.EuCcid = EuCcidGenerator.Generate(newEuccid.EuCcid);
            EuCcidSaver.Save(newEuccid);

            Console.WriteLine("Sending response.");
            messenger.Reply(newEuccid);
        }
    }
}
