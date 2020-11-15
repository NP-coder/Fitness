using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Model
{
    [Serializable]
    public class Gender
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Gender() { }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
