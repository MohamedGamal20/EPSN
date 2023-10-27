using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace EPSN.Models
{
    public class CourseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int Category_Id { get; set; }
        public Nullable<int> Trainer_Id { get; set; }
        public string Image_ID { get; set; }
        public string Description_Details { get; set; }
        public string Discound { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual Category Category { get; set; }
        public virtual Trainer Trainer { get; set; }
        public virtual ICollection<Course_units> Course_units { get; set; }
        public virtual ICollection<Trainee_courses> Trainee_courses { get; set; }
    }
}