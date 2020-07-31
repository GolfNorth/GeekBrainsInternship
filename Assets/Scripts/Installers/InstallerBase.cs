﻿using System.Collections.Generic;
using GeekBrainsInternship.Core;
using GeekBrainsInternship.Managers;
using UnityEngine;


namespace GeekBrainsInternship.Installers
{
    public class InstallerBase : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        protected List<ManagerBase> _managers = new List<ManagerBase>();

        #endregion
        
        
        #region UnityMethods

        protected void Awake()
        {
            foreach (var manager in _managers)
            {
                Director.Add(manager);
            }
        }

        #endregion
    }
}