using UnityEngine;
using Utils;

namespace Items
{
    public class Chave : MonoBehaviour
    {
        public GameObject OpenDoor;
            
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (OpenDoor != null)
                {
                    OpenDoor.GetComponent<EntrarSair>().GetKey();
                }
                Destroy(gameObject);
            }
        }
    }
}
