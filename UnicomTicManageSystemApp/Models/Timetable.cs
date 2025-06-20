using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManageSystemApp.Models
{
    public class Timetable
    {
        public int TimetableId { get; set; }
        public int SectionId { get; set; }
        public int SubjectId { get; set; }
        public int LectureId { get; set; }
        public int RoomId { get; set; }
        public string Date {  get; set; }
        public string Day { get; set; } 
        public string TimeSlot { get; set; } 
        public int StaffId {  get; set; }
    }

}
