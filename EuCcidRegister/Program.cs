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

            Console.WriteLine("New EU-CCID Service waiting for requests\n");

            var newEuccid = messenger.Receive<EUCCID>();

            Console.WriteLine($"Request received:\n {newEuccid}\n");

            newEuccid.EuCcid = EuCcidGenerator.Generate(newEuccid.EuCcid);
            EuCcidSaver.Save(newEuccid);

            Console.WriteLine("\nSending response.");
            messenger.Reply(newEuccid);
        }
    }
}
