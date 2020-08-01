using GeekBrainsInternship.Contexts;
using GeekBrainsInternship.Interfaces;
using GeekBrainsInternship.Managers;
using UnityEngine;


namespace GeekBrainsInternship.Installers
{
    [CreateAssetMenu(fileName = "NewInstaller",menuName = "GolfNorth/Installer")]
    public sealed class Installer : ScriptableObject, IInitializable<Context>
    {
        #region Fields

        [SerializeField]
        private Manager[] _managers;
        private Context _context;

        #endregion
        
        
        #region UnityMethods

        private void OnDestroy()
        {
            if (_context == null)
                return;
            
            foreach (var manager in _managers)
            {
                _context.Remove(manager.GetType());
            }
        }

        #endregion
        

        #region IInitializable<Context>

        public void Initialize(Context context)
        {
            _context = context;
            
            foreach (var manager in _managers)
            {
                _context.Add(manager);
            }
        }

        #endregion
    }
}