using GeekBrainsInternship.Core;
using GeekBrainsInternship.Interfaces;
using GeekBrainsInternship.Managers;
using UnityEngine;


namespace Panda
{
    public class PandaComponent : MonoBehaviour, ITickable, IFixedTickable
    {
        #region Fields

        [SerializeField] 
        private float _a = 0.1f;
        [SerializeField] 
        private float _b = 0.1f;
        private float _f = 0;
        private Transform _transform;

        #endregion
        
        
        #region UnityMethods

        private void Awake()
        {
            Director.Get<ManagerUpdate>().Add(this);
        }

        #endregion

        #region ITickable

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                Debug.Log("Panda!");
                
                _f = 0;
                transform.position = Vector3.zero;
            }
            
            Debug.Log("Press Space for reset position");
        }

        #endregion
        

        #region IFixedTickable

        public void FixedTick()
        {
            transform.position = new Vector3(
                (_a + _b * _f) * Mathf.Cos(_f), 
                (_a + _b * _f) * Mathf.Sin(_f)
            );
            
            _f += Time.deltaTime;
        }

        #endregion
    }
}