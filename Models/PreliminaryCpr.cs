using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PreliminaryCpr : CPR
    {
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName},\n {nameof(Surname)}: {Surname},\n {nameof(CprNumber)}: {CprNumber},\n {nameof(Gender)}: {Gender}, \n{nameof(Address1)}: {Address1}, \n{nameof(Address2)}: {Address2}, \n{nameof(PostalCode)}: {PostalCode}, \n{nameof(City)}: {City}, \n{nameof(MaritalStatus)}: {MaritalStatus}, \n{nameof(SpouseCprNumber)}: {SpouseCprNumber}, \n{nameof(ChildrensCprNumbers)}: {ChildrensCprNumbers}, \n{nameof(ParentsCprNumber)}: {ParentsCprNumber}, \n{nameof(DoctorsCvrNumber)}: {DoctorsCvrNumber}";
        }
    }
}
