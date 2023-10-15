using UnityEngine;

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
        private bool isTransparent;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            anime = GetComponent<Animator>();
            spriteNormal = spriteRenderer.sprite;
            controllerNormal = anime.runtimeAnimatorController;
            isTransparent = false;
        }

        public void MudarTransparente()
        {
            spriteRenderer.sprite = SpriteTransparente;
            anime.runtimeAnimatorController = ControllerTransparente;
            isTransparent = true;
        }

        public void MudarNormal()
        {
            spriteRenderer.sprite = spriteNormal;
            anime.runtimeAnimatorController = controllerNormal;
            isTransparent = false;
        }

        public bool GetIsTransparent()
        {
            return isTransparent;
        }
    }
}
