using CameraUtils;
using UnityEngine;

namespace Utils
{
    public class ChangeCamera : MonoBehaviour
    {
        public bool ChangeOnCollide;
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
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && ChangeOnCollide)
            {
                ChangeActiveCamera();
            }
        }
    }
}
