using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CPR
    {
        public string CprNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string MaritalStatus { get; set; }
        public string SpouseCprNumber { get; set; }
        public string[] ChildrensCprNumbers { get; set; }
        public string[] ParentsCprNumber { get; set; }
        public string DoctorsCvrNumber { get; set; }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName},\n {nameof(Surname)}: {Surname}, \n{nameof(Address1)}: {Address1}, \n{nameof(Address2)}: {Address2}, \n{nameof(PostalCode)}: {PostalCode}, \n{nameof(City)}: {City}, \n{nameof(MaritalStatus)}: {MaritalStatus}, \n{nameof(SpouseCprNumber)}: {SpouseCprNumber}, \n{nameof(ChildrensCprNumbers)}: {ChildrensCprNumbers}, \n{nameof(ParentsCprNumber)}: {ParentsCprNumber}, \n{nameof(DoctorsCvrNumber)}: {DoctorsCvrNumber}";
        }
    }
}
