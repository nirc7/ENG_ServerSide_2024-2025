﻿using System.Diagnostics;
using System.Xml.Linq;

namespace WebApplication1.Model
{
    public class DBStudentsMOCK
    {
        public static List<Student> students = new List<Student>()
        {
            new Student(){ID = 1, Name = "avi", Grade= 100},
            new Student(){ID = 2, Name = "cahrlie", Grade=98 },
            new Student(){ID = 3, Name = "dora", Grade=97 },
            new Student(){ID = 4, Name = "benny", Grade=99 },
        };
    }
}
