using UnityEngine;


namespace GeekBrainsInternship.Contexts
{
    public sealed class ProjectContext : Context
    {
        #region Methods

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnRuntimeMethodLoad()
        {
            var prefab = Resources.Load<GameObject>("ProjectContext");
            var gameObject = Instantiate(prefab);

            gameObject.name = "[project-context]";
            DontDestroyOnLoad(gameObject);
        }

        #endregion
    }
}