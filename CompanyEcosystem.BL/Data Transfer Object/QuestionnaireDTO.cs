using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEcosystem.BL.Data_Transfer_Object
{
    public class QuestionnaireDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Photo { get; set; }
        public string AboutMyself { get; set; }
        public string LinkToLinkedIn { get; set; }
        public int EmployeeId { get; set; }
    }
}
