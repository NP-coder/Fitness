
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace BL.Control
{
    class SerializeDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            var formater = new BinaryFormatter();
            var filename = typeof(T).Name;

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formater.Deserialize(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            var formater = new BinaryFormatter();
            var filename = typeof(T).Name;

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, item);
            }
        }
    }
}
