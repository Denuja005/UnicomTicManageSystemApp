﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManageSystemApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string City { get; set; } 
        public int? SectionId { get; set; }
    }
}
