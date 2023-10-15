using UnityEngine;

namespace Utils
{
    public class TeleportPlayer : MonoBehaviour
    {
        public Transform Destination;
        public bool WillChangeCamera;
        public Camera NextCamera;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherGameObject = other.gameObject;
            if (otherGameObject.CompareTag("Player"))
            {
                if (WillChangeCamera && NextCamera != null)
                {
                    var cameras = FindObjectsOfType<Camera>();
                    foreach (var camera1 in cameras)
                    {
                        camera1.enabled = false;
                    }
                    NextCamera.enabled = true;
                }
                otherGameObject.transform.position = Destination.position;
            }
        }
    }
}
