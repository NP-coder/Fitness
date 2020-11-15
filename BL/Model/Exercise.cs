using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int ID { get; set; }
        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public int ActivityID { get; set; }

        public virtual Activity Activity { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }

        public Exercise() { }
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
