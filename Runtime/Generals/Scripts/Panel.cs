using UnityEngine;

namespace Services.UI
{
    public class Panel<Inherister> : MonoBehaviour where Inherister : Panel<Inherister>
    {
        public static Inherister Instance { get; private set; }

        [SerializeField] private GameObject root;
        [Space]
        [SerializeField] private PanelTransition transition;

        /// <summary>
        /// Intialize this panel and transition (transition can initable when property 'animation' is not null or empty only).
        /// </summary>
        protected virtual void Start()
        {
            transition.Initialize(Eanble, Disable);

            if (root)
                return;

            root = gameObject;
        }

        /// <summary>
        /// Set this panel to instance
        /// </summary>
        /// <param name="inheriter"></param>
        protected void SetInstance(Inherister inheriter, PanelReplacementType replacementType = PanelReplacementType.Noramal)
        {
            if (inheriter == null)
                return;

            if(replacementType == PanelReplacementType.DontroyPrivious && Instance != null)
                Destroy(Instance.gameObject);

            Instance = inheriter;
        }

        /// <summary>
        /// Enable or show this pnael.
        /// </summary>
        public virtual void Open()
        {
            if (!transition.IsInitialized)
            {
                Eanble();
                return;
            }

            transition.FadeIn();
        }

        /// <summary>
        /// Disable or hide this panel.
        /// </summary>
        public virtual void Close()
        {
            if (!transition.IsInitialized)
            {
                Disable();
                return;
            }

            transition.FadeOut();
        }

        private void Eanble()
        {
            root.SetActive(true);
        }

        private void Disable()
        {
            root.SetActive(false);
        }
    }
}