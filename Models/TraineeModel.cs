using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPSN.Models
{
    public class TraineeCoursesModel
    {
        public int Course_Id { get; set; }
        public DateTime Registration_date { get; set; }
        public virtual Trainee Trainee { get; set; }

    }

    public class TraineeModel
    {
        public string Name { get; set; }
        public string E_mail { get; set; }
    }
}