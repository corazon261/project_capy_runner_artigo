using UnityEngine;

namespace Utils
{
    public class CameraFollowPlayerX : MonoBehaviour
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
            cameraTransform.position = new Vector3(player.position.x, cameraTransform.position.y, -10);
        }
    }
}
