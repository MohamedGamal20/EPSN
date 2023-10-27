using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPSN.Services
{
    public interface ITraineeService
    {
        Trainee Create(Trainee trainee);
    }
    public class TraineeService : ITraineeService
    {
        private readonly CoursesDBEntities courses_DB;
        public TraineeService()
        {
            courses_DB = new CoursesDBEntities();
        }

        public Trainee Create(Trainee trainee)
        {
            courses_DB.Trainees.Add(trainee);
            int savingResult = courses_DB.SaveChanges();
            if (savingResult > 0)
            {
                return trainee;
            }
            return null;
        }
    }
}