using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPSN.Models
{
    public class CourseLessons
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Course_Id { get; set; }
        public Nullable<int> Order_Number { get; set; }
        public string Type { get; set; }
        public string Unit_Name { get; set; }

        public virtual Cours Course { get; set; }
    }
}