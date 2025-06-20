using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManageSystemApp.Models
{
    public class Mark
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int ExamId { get; set; }
        public int Score { get; set; }
        public int StaffId { get; set; }

        public string SubjectName { get; set; }
        public string ExamName { get; set; }
    }
}
