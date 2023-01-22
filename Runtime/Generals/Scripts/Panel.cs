using UnityEngine;

namespace Services.UI
{
    public class Panel : MonoBehaviour
    {
        [SerializeField] private GameObject root;
        [Space]
        [SerializeField] private PanelTransition transition;

        public PanelTransition Transition
        {
            get => transition;
        }

        /// <summary>
        /// Intialize this panel and transition (transition can initable when property 'animation' is not null or empty only).
        /// </summary>
        protected virtual void Start()
        {
            transition.Initialize(this);

            if (root)
                return;

            root = gameObject;
        }

        /// <summary>
        /// Enable or show this pnael.
        /// </summary>
        public virtual void Open()
        {
            if (!transition.IsInitialized)
            {
                Enable();
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

        /// <summary>
        /// Nagative switch open or close when invoke.
        /// </summary>
        public void ShowNagative()
        {
            if (root.activeSelf)
                Close();
            else
                Open();
        }

        internal void Enable()
        {
            root.SetActive(true);
        }

        internal void Disable()
        {
            root.SetActive(false);
        }
    }
}