using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikMvcApp4
{
    public class Procedure
    {
        [Key]
        public int taskID { get; set; }

        public string ProcedureTitle { get; set; }
        public string ProcedureDetails { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        public string SurgeonFirstName { get; set; }
        public string SurgeonLastName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientMRN { get; set; }
        public string PatientRoom { get; set; }
        public string ProcedureType { get; set; }



    }
}
