using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services.UI
{
    public abstract class PanelSingleton<Inherister> : Panel where Inherister : Panel
    {
        public static Inherister Instance { get; private set; }

        protected override void Start()
        {
            base.Start();

            SetInstance(GetComponent<Inherister>());
        }

        /// <summary>
        /// Set this panel to instance
        /// </summary>
        /// <param name="inheriter"></param>
        protected void SetInstance(Inherister inheriter, PanelReplacementType replacementType = PanelReplacementType.Noramal)
        {
            if (inheriter == null)
                return;

            if (replacementType == PanelReplacementType.DontroyPrivious && Instance != null)
                Destroy(Instance.gameObject);

            Instance = inheriter;
        }
    }
}