using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Animals.Jaileds
{
    public class ChangeOpacity : MonoBehaviour
    {
        public Sprite SpriteTransparente;
        public RuntimeAnimatorController ControllerTransparente;
        private Sprite spriteNormal;
        private RuntimeAnimatorController controllerNormal;
        private Animator anime;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            anime = GetComponent<Animator>();
            spriteNormal = spriteRenderer.sprite;
            controllerNormal = anime.runtimeAnimatorController;
        }

        public void MudarTransparente()
        {
            spriteRenderer.sprite = SpriteTransparente;
            anime.runtimeAnimatorController = ControllerTransparente;
        }

        public void MudarNormal()
        {
            spriteRenderer.sprite = spriteNormal;
            anime.runtimeAnimatorController = controllerNormal;
        }
    }
}
