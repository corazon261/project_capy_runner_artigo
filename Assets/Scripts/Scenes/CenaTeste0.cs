using System;
using UnityEngine;

namespace Scenes
{
    public class CenaTeste0 : MonoBehaviour
    {
        public Camera CameraIncial;
        private Camera[] cameras;
        private void Start()
        {
            cameras = GetComponents<Camera>();
            foreach (var camera in cameras)
            {
                camera.enabled = false;
            }

            CameraIncial.enabled = true;
        }
    }
}