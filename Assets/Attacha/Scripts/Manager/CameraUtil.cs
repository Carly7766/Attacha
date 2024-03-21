using UnityEngine;

namespace Attacha.Scripts.Manager
{
    public static class CameraUtil
    {
        private static Camera _mainCamera;
        public static Camera Main
        {
            get
            {
                if (_mainCamera == null)
                    _mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
                return _mainCamera;
            }
        }

        private static Camera _uiCamera;
        public static Camera UI
        {
            get
            {
                if (_uiCamera == null)
                    _uiCamera = GameObject.FindWithTag("UICamera").GetComponent<Camera>();
                return _uiCamera;
            }
        }
    }
}