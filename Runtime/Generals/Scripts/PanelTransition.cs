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

        public bool IsInitialized { get; private set; }

        public void Initialize(EventAction OnFadeInComplete, EventAction onFadeOutComplete)
        {
            if (!animation)
                return;

            fadeIn.Initialize(animation);
            fadeOut.Initialize(animation);

            fadeIn.SetListener(null, OnFadeInComplete);
            fadeOut.SetListener(null, OnFadeInComplete);

            IsInitialized = true;
        }

        public void FadeIn()
        {
            if (!IsInitialized)
            {
                Debug.LogWarningFormat("Panel trasition need to initialize first");
                return;
            }

            fadeIn.Play();
        }

        public void FadeOut()
        {
            if (!IsInitialized)
            {
                Debug.LogWarningFormat("Panel trasition need to initialize first");
                return;
            }

            fadeOut.Play();
        }
    }
}