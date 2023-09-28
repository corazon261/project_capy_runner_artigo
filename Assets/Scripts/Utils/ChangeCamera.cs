using UnityEngine;

namespace Utils
{
    public class ChangeCamera : MonoBehaviour
    {
        public Camera ToCamera;
        public Camera PreviousCamera;

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PreviousCamera.enabled = false;
                ToCamera.enabled = true;
                (PreviousCamera, ToCamera) = (ToCamera, PreviousCamera);
            }
        }
    }
}
