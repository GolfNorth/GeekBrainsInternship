using System;
using System.Collections.Generic;
using GeekBrainsInternship.Core;
using GeekBrainsInternship.Installers;
using GeekBrainsInternship.Interfaces;
using UnityEngine;
using UnityObject = UnityEngine.Object;


namespace GeekBrainsInternship.Contexts
{
    public abstract class Context : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        protected Installer[] _installers;
        private readonly Dictionary<Type, object> _data = new Dictionary<Type, object>();

        #endregion


        #region UnityMethods

        protected void Awake()
        {
            Director.AddContext(this);
            
            for (var i = 0; i < _installers.Length; i++)
            {
                _installers[i].Initialize(this);
            }
        }

        protected void OnDestroy()
        {
            Director.RemoveContext(this);
        }

        #endregion
        

        #region Methods

        public void Add(UnityObject obj)
        {
            var type = obj.GetType();
            
            if (_data.ContainsKey(type))
                return;
            
            var add = Instantiate(obj);
                
            _data.Add(type, add);

            if (add is IInitializable initializable)
            {
                initializable.Initialize();
            }
        }
        
        public void AddAs<T>(T obj) 
        {
            var type = typeof(T);
            
            if (_data.ContainsKey(type))
                return;

            _data.Add(type, obj);
        }

        public void Remove(Type type)
        {
            if (!_data.TryGetValue(type, out var resolve))
                return;

            if (resolve is UnityObject unityObject)
                Destroy(unityObject);

            _data.Remove(type);
        }
	
        public T Get<T>(out bool success)
        {
            success = _data.TryGetValue(typeof(T), out var resolve);

            return (T) resolve;
        }

        #endregion
    }
}