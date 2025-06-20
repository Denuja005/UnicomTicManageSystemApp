using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManageSystemApp.Models
{
    public class StaffAttendance
    {
        public int AttendanceId { get; set; }
        public int StaffId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; }  // "Present" or "Absent"
    }
}
