using BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Control
{
    public class ExerciseControl : Base
    {
        private readonly User user;
        public List<Exercise> Exercises { get; }

        public List<Activity> Activities { get; }



        public ExerciseControl(User user)
        {
            this.user = user;
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime start, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            
            if(act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(start, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(start, end, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
