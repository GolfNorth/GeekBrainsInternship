using System.Collections.Generic;
using GeekBrainsInternship.Contexts;
using UnityObject = UnityEngine.Object;


namespace GeekBrainsInternship.Core
{
    public sealed class Director : Singleton<Director>
    {
        #region Fields

        private readonly List<Context> _contexts = new List<Context>();

        #endregion


        #region UnityMethods

        private void Start()
        {
            gameObject.name = "[director]";
        }

        #endregion
        

        #region Methods

        public static void AddContext(Context context)
        {
            if (Instance == null || Instance._contexts.Contains(context))
                return;
            
            Instance._contexts.Add(context);
        }
        
        public static void RemoveContext(Context context)
        {
            if (Instance == null || Instance._contexts.Contains(context))
                return;
            
            Instance._contexts.Remove(context);
        }
	
        public static T Get<T>()
        {
            var resolve = default(T);

            foreach (var context in Instance._contexts)
            {
                resolve = context.Get<T>(out var success);

                if (success)
                    return resolve;
            }

            return resolve;
        }

        #endregion
    }
}