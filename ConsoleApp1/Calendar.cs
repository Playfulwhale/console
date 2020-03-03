using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Calendar
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }

        public int LeaderID { get; set; }

        public int DepartmentID { get; set; }
    }
}


