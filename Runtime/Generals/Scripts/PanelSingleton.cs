using UnityEngine;

namespace Services.UI
{
    public abstract class PanelSingleton<Inherister> : Panel where Inherister : Panel
    {
        public static Inherister Instance
        {
            get
            {
                if (!_instance)
                    SetInstance();

                return _instance;
            }
        }

        private static Inherister _instance;

        protected virtual void Awake()
        {
            SetInstance(GetComponent<Inherister>());
        }

        /// <summary>
        /// Force set global instance.
        /// </summary>
        public static void SetInstance()
        {
            if (_instance)
                return;

            Inherister[] inheristers = FindObjectsOfType<Inherister>();

            if (inheristers == null)
            {
                Debug.LogError("The type of <{nameof(Inherister)}> not arriv or found.");
                return;
            }

            if (inheristers.Length > 1)
                Debug.LogWarning($"The type of <{nameof(Inherister)}> arrived more that one.");

            _instance = inheristers[0];
        }

        /// <summary>
        /// Set this panel to instance
        /// </summary>
        /// <param name="inheriter"></param>
        protected void SetInstance(Inherister inheriter, SigletonPlacementType replacementType = SigletonPlacementType.Noramal)
        {
            if (inheriter == null)
                return;

            switch (replacementType)
            {
                case SigletonPlacementType.Noramal:
                    if (_instance)
                        return;
                    break;
                case SigletonPlacementType.DontroyPrivious:
                    if (_instance)
                        Destroy(Instance.gameObject);
                    break;
            }

            _instance = inheriter;
        }
    }
}