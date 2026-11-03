using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudios : MonoBehaviour
    {
        public AudioClip Footstep;
        
        private Rigidbody2D rb;
        private AudioSource audioSource;
        private float footstepTimer;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            PlayFootstep();
        }

        public void PlayFootstep()
        {
            footstepTimer -= Time.deltaTime;
            if (Mathf.Abs(rb.linearVelocity.x) > 0.1f && footstepTimer <= 0)
            {
                audioSource.PlayOneShot(Footstep);
                footstepTimer = Footstep.length;
            }
            else if (Mathf.Abs(rb.linearVelocity.x) < 0.1f)
            {
                audioSource.Stop();
                footstepTimer = 0;
            }
        }
    }
}