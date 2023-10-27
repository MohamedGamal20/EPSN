using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPSN.Services
{
    public interface ITraineeCourseService
    {
        IEnumerable<Trainee_courses> GetTrainees(int? courseId = null);
    }
    public class TraineeCourseService : ITraineeCourseService
    {
        private readonly CoursesDBEntities courses_DB;
        public TraineeCourseService()
        {
            courses_DB = new CoursesDBEntities();
        }
        public IEnumerable<Trainee_courses> GetTrainees(int? courseId = null)
        {
          return courses_DB.Trainee_courses.Where(t => courseId == null || t.Course_Id == courseId);
        }

    }
}