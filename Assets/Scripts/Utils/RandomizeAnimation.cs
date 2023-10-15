using UnityEngine;

namespace Utils
{
    public class RandomizeAnimation : MonoBehaviour
    {
        private void Start()
        {
            var anime = GetComponent<Animator>();
            anime.speed = Random.Range(0.2f, 1.3f);
        }
    }
}