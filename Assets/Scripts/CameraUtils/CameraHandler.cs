using UnityEngine;

namespace CameraUtils
{
    public class CameraHandler : MonoBehaviour
    {
        public Camera StartCamera;
        
        private void Start()
        {
            DisableAllCameras();
            StartCamera.enabled = true;
        }
        
        public void DisableAllCameras()
        {
            var cameras = FindObjectsOfType<Camera>();
            foreach (var camera1 in cameras)
            {
                camera1.enabled = false;
            }
        }
        
        public GameObject GetCurrentActiveCamera()
        {
            Camera[] todasCameras = FindObjectsOfType<Camera>();
            foreach (Camera camera1 in todasCameras)
            {
                if (camera1.isActiveAndEnabled)
                {
                    return camera1.gameObject;
                }
            }
            return null;
        }
    }
}