using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CPR
    {
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
    }
}
