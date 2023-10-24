using CameraUtils;
using UnityEngine;

namespace Utils
{
    public class ChangeCamera : MonoBehaviour
    {
        public bool ChangeOnCollide;
        public Camera ToCamera;
        private CameraHandler cameraHandler;
        private Camera previousCamera;
        private bool isFirstTime = true;
        
        private void Start()
        {
            cameraHandler = FindObjectOfType<CameraHandler>();
        }

        public void ChangeActiveCamera()
        {
            if (isFirstTime)
            {
                isFirstTime = false;
                previousCamera = cameraHandler.GetCurrentActiveCamera().GetComponent<Camera>();

                if (previousCamera == null)
                {
                    Debug.LogError("Sem cameras disponiveis");
                }
            }
            
            if (ToCamera.enabled)
            {
                cameraHandler.DisableAllCameras();
                previousCamera.enabled = true;
            }
            else
            {
                cameraHandler.DisableAllCameras();
                ToCamera.enabled = true;
            }
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
