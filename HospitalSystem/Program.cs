using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Models;

namespace HospitalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // create messenger with in and out channels
            var messenger = new Messenger("NewEuccidChannelResponse", "NewEuccidChannel");
            
            // create a euccid with all the available data
            var preEuccid = new EUCCID()
            {
                ChristianName = "Jesus",
                FamilyName = "Christ",
                City = "Berlin",
                StreetHouseNumber = "Friedrichstrasse 4",
                ApartmentNumber = "2a",
                CurrentCountry = "Germany",
                BirthCountry = "Germany",
                Gender = "Male",
                EuCcid = "01012017" // to pass on the birthdate
            };

            Console.WriteLine("Hospital sending request.");
            messenger.Send(preEuccid);

            var euccid = messenger.Receive<EUCCID>();
            Console.WriteLine("Hospital got response:");
            Console.WriteLine(euccid);
        }
    }
}
