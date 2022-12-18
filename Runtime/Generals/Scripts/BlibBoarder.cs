using UnityEngine;

namespace Services.UI
{
    public class BlibBoarder : MonoBehaviour
    {
        [SerializeField] private Camera _mainCam;

        private Vector3 _cameraDiraction;

        private void Start()
        {
            if (!_mainCam)
                _mainCam = Camera.main;
        }

        private void Update()
        {
            if (!_mainCam)
                return;

            _cameraDiraction = _mainCam.transform.forward;
            _cameraDiraction.y = 0;
            transform.rotation = Quaternion.LookRotation(_cameraDiraction);
        }
    } 
}
