using System;
using UnityEngine;

namespace Utils
{
    public class TeleportPlayer : MonoBehaviour
    {
        public Transform Destination;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherGameObject = other.gameObject;
            if (otherGameObject.CompareTag("Player"))
            {
                otherGameObject.transform.position = Destination.position;
            }
        }
    }
}
