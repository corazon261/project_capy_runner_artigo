using UnityEngine;
using Utils;

namespace Items
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Chave : MonoBehaviour
    {
        public AudioSource audioPegandoChave;
        
        public GameObject OpenDoor;
            
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if(audioPegandoChave != null)
                {
                    audioPegandoChave.Play();
                }                

                if (OpenDoor != null)
                {
                    OpenDoor.GetComponent<EntrarSair>().GetKey();
                }                

                Destroy(gameObject, 0.15f);
            }
        }
    }
}
