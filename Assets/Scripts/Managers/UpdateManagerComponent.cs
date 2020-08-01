using UnityEngine;


namespace GeekBrainsInternship.Managers
{
    public sealed class UpdateManagerComponent : MonoBehaviour
    {
        #region Fields

        private UpdateManager _updateManager;

        #endregion
        

        #region Methods

        public void Setup(UpdateManager updateManager)
        {
            _updateManager = updateManager;
        }

        #endregion

        
        #region UnityMethods

        private void Update()
        {
            _updateManager.Tick();
        }

        private void FixedUpdate()
        {
            _updateManager.TickFixed();
        }


        private void LateUpdate()
        {
            _updateManager.TickLate();
        }

        #endregion
    }
}