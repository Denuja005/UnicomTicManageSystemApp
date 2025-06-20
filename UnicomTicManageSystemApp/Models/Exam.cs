using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManageSystemApp.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; } 
        public DateTime ExamDate { get; set; }
        public int SubjectId { get; set; }
    }
}
