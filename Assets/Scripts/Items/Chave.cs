using Player;
using UnityEngine;

namespace Items
{
    public class Chave : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().PegarChave();
                Destroy(gameObject);
            }
        }
    }
}
