using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManageSystemApp.Models
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string LecturName { get; set; } 
        public string LecturEmail { get; set; } 
        public string LecturPhone { get; set; }  
        public string LecturCity { get; set; }
        public int SectionId { get; set; }
    }
}
