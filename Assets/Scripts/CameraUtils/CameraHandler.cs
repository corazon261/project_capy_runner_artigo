using UnityEngine;

namespace CameraUtils
{
    public class CameraHandler : MonoBehaviour
    {
        public void DisableAllCameras()
        {
            var cameras = FindObjectsOfType<Camera>();
            foreach (var camera1 in cameras)
            {
                camera1.enabled = false;
            }
        }
    }
}