using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class CameraSlide : MonoBehaviour
    {
        public Transform Position;
        private bool movendo;
        [SerializeField] private float velocidadeMovimento;
        private CameraFollowPlayerX scriptFollow;

        private void Start()
        {
            Position.position = new Vector3(Position.position.x, Position.position.y, -10);
            scriptFollow = GetComponent<CameraFollowPlayerX>();
        }
        
        public void IniciaMovimento()
        {
            StartCoroutine(SlideCamera());
        }

        private IEnumerator SlideCamera()
        {
            movendo = true;
            scriptFollow.enabled = false;

            Vector3 posicaoInicial = transform.position;
            float distanciaTotal = Vector3.Distance(posicaoInicial, Position.position);
            float distanciaPermanente = 0f;

            while (distanciaPermanente < distanciaTotal)
            {
                // Interpola suavemente entre a posição inicial e a posição de Position.position
                distanciaPermanente += velocidadeMovimento * Time.deltaTime;
                float fracaoMovimento = distanciaPermanente / distanciaTotal;
                transform.position = Vector3.Lerp(posicaoInicial, Position.position, fracaoMovimento);

                yield return null;
            }

            movendo = false;
            BackCameraToNormal();
        }

        private void BackCameraToNormal()
        {
            scriptFollow.enabled = true;
        }
    }
}
