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
        private bool isPositiveX;
        private bool isPositiveY;

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
                var playerPosition = other.gameObject.transform.position;
                var position = gameObject.transform.position;
                isPositiveX = playerPosition.x > position.x;
                isPositiveY = playerPosition.y > position.y;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player") && ChangeOnCollide)
            {
                var playerPosition = other.gameObject.transform.position;
                var position = gameObject.transform.position;
                var thisPositiveX = playerPosition.x > position.x;
                var thisPositiveY = playerPosition.y > position.y;

                if (thisPositiveY != isPositiveY || thisPositiveX != isPositiveX)
                {
                    ChangeActiveCamera();   
                }
            }
        }
    }
}
