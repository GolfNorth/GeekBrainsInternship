using System.Collections.Generic;
using GeekBrainsInternship.Core;
using GeekBrainsInternship.Managers;
using UnityEngine;


namespace GeekBrainsInternship.Installers
{
    public sealed class SceneInstaller : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private List<ManagerBase> _managers = new List<ManagerBase>();

        #endregion
        
        
        #region UnityMethods

        private void Awake()
        {
            foreach (var manager in _managers)
            {
                Director.Add(manager);
            }
        }

        #endregion
    }
}