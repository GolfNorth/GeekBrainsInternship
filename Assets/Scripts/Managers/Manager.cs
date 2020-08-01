using UnityEngine;


namespace GeekBrainsInternship.Managers
{
    public abstract class Manager : ScriptableObject
    {
        #region Fields

        protected const string MANAGERS_OBJECT_NAME = "[managers]";
        protected GameObject ManagersGameObject;

        #endregion
        

        #region Methods

        protected T AddComponent<T>() where T : Component
        {
            if (ManagersGameObject == null)
                ManagersGameObject = FindManagersGameObject();
            
            var component = ManagersGameObject.AddComponent<T>();

            return component;
        }

        private GameObject FindManagersGameObject()
        {
            if (ManagersGameObject != null)
                return ManagersGameObject;
            
            var result = GameObject.Find(MANAGERS_OBJECT_NAME);

            if (result != null)
                return result;
            
            var allObjects = FindObjectsOfType<GameObject>();
            
            foreach(var go in allObjects)
                if (go.name == MANAGERS_OBJECT_NAME)
                    result = go;

            return result;
        }

        #endregion
    }
}