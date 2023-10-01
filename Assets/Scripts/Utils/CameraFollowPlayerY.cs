using UnityEngine;

namespace Utils
{
    public class CameraFollowPlayerY : MonoBehaviour
    {
        private Transform player;
        private Transform cameraTransform;
        void Start()
        {
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
            cameraTransform = GetComponent<Transform>();
        }
        
        void Update()
        {
            cameraTransform.position = new Vector3(cameraTransform.position.x, player.position.y, -10);
        }
    }
}