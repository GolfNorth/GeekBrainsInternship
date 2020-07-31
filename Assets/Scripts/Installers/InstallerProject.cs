namespace GeekBrainsInternship.Installers
{
    public sealed class InstallerProject : InstallerBase
    {
        #region UnityMethods

        protected new void Awake()
        {
            base.Awake();
            
            DontDestroyOnLoad(gameObject);
        }

        #endregion
    }
}