﻿using System.Collections.Generic;
using GeekBrainsInternship.Core;
using GeekBrainsInternship.Interfaces;
using UnityEngine;


namespace GeekBrainsInternship.Managers
{
    [CreateAssetMenu(fileName = "UpdateManager",menuName = "GolfNorth/Managers/Update Manager")]
    public sealed class UpdateManager : Manager, IInitializable
    {
        #region Fields
        
        private readonly List<ITickable> _ticks = new List<ITickable>();
        private readonly List<ILateTickable> _lateTicks = new List<ILateTickable>();
        private readonly List<IFixedTickable> _fixedTicks = new List<IFixedTickable>();
        private UpdateManagerComponent _updateManagerComponent;

        #endregion
        

        #region Methods

        public void Add(object updatable)
        {
            var managerUpdate = Director.Get<UpdateManager>();

            if (updatable is IInitializable initializable)
            {
                initializable.Initialize();
            }
            
            if (updatable is ITickable tick)
            {
                managerUpdate._ticks.Add(tick);
            }
            
            if (updatable is ILateTickable lateTick)
            {
                managerUpdate._lateTicks.Add(lateTick);
            }
            
            if (updatable is IFixedTickable fixedTick)
            {
                managerUpdate._fixedTicks.Add(fixedTick);
            }
        }
        
        public void Remove(object updatable)
        {
            var managerUpdate = Director.Get<UpdateManager>();
            
            if (updatable is ITickable tick)
            {
                managerUpdate._ticks.Remove(tick);
            }
            
            if (updatable is ILateTickable lateTick)
            {
                managerUpdate._lateTicks.Remove(lateTick);
            }
            
            if (updatable is IFixedTickable fixedTick)
            {
                managerUpdate._fixedTicks.Remove(fixedTick);
            }
        }

        public void Tick()
        {
            for (var i = 0; i < _ticks.Count; i++)
            {
                _ticks[i].Tick();
            }
        }

        public void TickLate()
        {
            for (var i = 0; i < _lateTicks.Count; i++)
            {
                _lateTicks[i].LateTick();
            }
        }

        public void TickFixed()
        {
            for (var i = 0; i < _fixedTicks.Count; i++)
            {
                _fixedTicks[i].FixedTick();
            }
        }

        #endregion


        #region UnityMethods

        private void OnDestroy()
        {
            if (_updateManagerComponent != null)
                Destroy(_updateManagerComponent);
        }

        #endregion
        

        #region IInitializable

        public void Initialize()
        {
            _updateManagerComponent = AddComponent<UpdateManagerComponent>();
            _updateManagerComponent.Setup(this);
        }

        #endregion
    }
}