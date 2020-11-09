using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BL.Control
{
    public abstract class Base
    {
        protected void Save(string filename, object item)
        {
            var formater = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, item);
            }
        }

        protected T Load<T>(string filename)
        {
            var formater = new BinaryFormatter();

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length > 1 && formater.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
