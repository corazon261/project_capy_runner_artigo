using CameraUtils;
using UnityEngine;

namespace Utils
{
    public class ChangeCamera : MonoBehaviour
    {
        public Camera ToCamera;
        private CameraHandler cameraHandler;
        
        private void Start()
        {
            cameraHandler = FindObjectOfType<CameraHandler>();
        }

        public void ChangeActiveCamera()
        {
            cameraHandler.DisableAllCameras();
            ToCamera.enabled = true;
        }
    }
}
