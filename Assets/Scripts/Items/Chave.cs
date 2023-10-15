using Player;
using UnityEngine;

namespace Items
{
    public class Chave : MonoBehaviour
    {
        public GameObject OpenDoor;
            
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OpenDoor.GetComponent<EntrarSair>().GetKey();
                Destroy(gameObject);
            }
        }
    }
}
