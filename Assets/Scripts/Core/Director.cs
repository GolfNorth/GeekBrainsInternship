using System;
using System.Collections.Generic;
using GeekBrainsInternship.Interfaces;
using UnityObject = UnityEngine.Object;


namespace GeekBrainsInternship.Core
{
    public class Director : Singleton<Director>
    {
        #region Fields
        
        private readonly Dictionary<Type, object> _data = new Dictionary<Type, object>();

        #endregion


        #region Methods

        public static void Add(UnityObject obj)
        {
            var type = obj.GetType();
            
            if (Instance._data.ContainsKey(type))
                return;
            
            var add = Instantiate(obj);
                
            Instance._data.Add(type, add);

            if (add is IInitializable initializable)
            {
                initializable.Initialize();
            }
        }
        
        public static void Add(object obj)
        {
            var type = obj.GetType();
            
            if (Instance._data.ContainsKey(type))
                return;
            
            Instance._data.Add(type, obj);
        }

        public static void Remove(Type type)
        {
            if (!Instance._data.ContainsKey(type))
                return;

            Instance._data.Remove(type);
        }
	
        public static T Get<T>()
        {
            Instance._data.TryGetValue(typeof(T), out var resolve);
            
            return (T) resolve;
        }

        #endregion
    }
}