using UnityEngine;


namespace GeekBrainsInternship.Managers
{
    public class ManagerUpdateComponent : MonoBehaviour
    {
        #region Fields

        private ManagerUpdate _manager;

        #endregion
        

        #region Methods

        public void Setup(ManagerUpdate manager)
        {
            _manager = manager;
        }

        #endregion

        
        #region UnityMethods

        private void Update()
        {
            _manager.Tick();
        }

        private void FixedUpdate()
        {
            _manager.TickFixed();
        }


        private void LateUpdate()
        {
            _manager.TickLate();
        }

        #endregion
    }
}