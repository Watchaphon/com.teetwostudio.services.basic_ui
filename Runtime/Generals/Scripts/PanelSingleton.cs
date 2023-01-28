using Services.Utility.Core;
using UnityEngine;

namespace Services.UI
{
    public abstract class PanelSingleton<Inherister> : Panel where Inherister : Panel
    {
        /// <summary>
        /// The access of instance finder type default is 'FindExited'.
        /// </summary>
        protected static SingleonAccessType AccessType { get; set; } = SingleonAccessType.FindExited;

        public static Inherister Instance
        {
            get
            {
                if (!_instance)
                    _instance = SingletonHelper.FindInstance(_instance, AccessType);

                return _instance;
            }
        }

        private static Inherister _instance;

        protected virtual void Awake()
        {
            _instance = SingletonHelper.GetInstance(gameObject, _instance);
        }

        /// <summary>
        /// Check the status of this instance static object can't check null form Instance property because Instance property away find the validable access can check only this function.
        /// </summary>
        /// <returns>Ture if 'Instance' not be null</returns>
        public bool IsInstanceValidable()
        {
            return _instance;
        }
    }
}