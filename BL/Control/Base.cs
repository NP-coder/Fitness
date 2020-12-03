using System;
using System.Collections.Generic;

namespace BL.Control
{
    public abstract class Base
    {
        private readonly IDataSaver manager = new DatabaseDatasaver();

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
