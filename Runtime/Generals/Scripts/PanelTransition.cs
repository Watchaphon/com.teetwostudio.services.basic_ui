using Services.EventsSystem;
using System;
using UnityEngine;

namespace Services.UI
{
    [Serializable]
    public struct PanelTransition
    {
        [SerializeField] private Animation animation;
        [Space]
        [SerializeField] private GenericAnimationHandle fadeIn;
        [SerializeField] private GenericAnimationHandle fadeOut;

        public bool IsProcessing { get; private set; }

        public bool IsInitialized { get; private set; }

        private Panel _authorPanel;

        public void Initialize(Panel panel)
        {
            if (!animation)
                return;

            _authorPanel = panel;

            fadeIn.Initialize(animation);
            fadeOut.Initialize(animation);

            fadeIn.SetListener(OnFadeInStart, OnFadeInCompelte);
            fadeOut.SetListener(OnFadeOutStart, OnFadeOutComplete);

            IsInitialized = true;
        }

        public void FadeIn()
        {
            if (!IsInitialized)
            {
                Debug.LogWarningFormat("Panel trasition need to initialize first");
                return;
            }

            if (IsProcessing)
                return;

            fadeIn.Play();
        }

        public void FadeOut()
        {
            if (!IsInitialized)
            {
                Debug.LogWarningFormat("Panel trasition need to initialize first");
                return;
            }

            if (IsProcessing)
                return;

            fadeOut.Play();
        }

        #region FadeIn Event
        private void OnFadeInStart()
        {
            IsProcessing = true;

            _authorPanel.Enable();
        }

        private void OnFadeInCompelte()
        {
            IsProcessing = false;
        }

        #endregion

        #region FadeOut Event
        private void OnFadeOutStart()
        {
            IsProcessing = true;
        }

        private void OnFadeOutComplete()
        {
            IsProcessing = false;

            _authorPanel.Disable();
        }
        #endregion
    }
}