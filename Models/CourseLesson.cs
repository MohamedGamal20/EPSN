using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPSN.Models
{
    public class CourseLesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> Order_Number { get; set; }
        public string Type { get; set; }
        public int Unit_Id { get; set; }

        public virtual Course_units Course_units { get; set; }
    }
}