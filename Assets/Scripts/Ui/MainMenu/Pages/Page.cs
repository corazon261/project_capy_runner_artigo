using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using MenuSystem.Animation;

namespace MenuSystem.Pages
{
    [RequireComponent(typeof(AudioSource), typeof(CanvasGroup))]
    [DisallowMultipleComponent]
    public class Page : MonoBehaviour
    {
        private AudioSource audioSource;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;

        [SerializeField]
        private float animationSpeed = 1f;
        public bool ExitOnNewPagePush = false;
        [SerializeField]
        private AudioClip entryClip;
        [SerializeField]
        private AudioClip exitClip;
        [SerializeField]
        private AnimationMode entryMode = AnimationMode.FADE;
        [SerializeField]
        private AnimationDirection entryDirection = AnimationDirection.NONE;
        [SerializeField]
        private AnimationMode exitMode = AnimationMode.FADE;
        [SerializeField]
        private AnimationDirection exitDirection = AnimationDirection.NONE;
        [SerializeField]
        private UnityEvent prePushAction;
        [SerializeField]
        private UnityEvent postPushAction;
        [SerializeField]
        private UnityEvent prePopAction;
        [SerializeField]
        private UnityEvent postPopAction;

        private Coroutine animationCoroutine;
        private Coroutine audioCoroutine;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            audioSource = GetComponent<AudioSource>();

            audioSource.playOnAwake = false;
            audioSource.loop = false;
            audioSource.spatialBlend = 0;
            audioSource.enabled = false;
        }

        public void Disable()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }

        public void Enter(bool _playAudio)
        {
            prePushAction?.Invoke();

            switch (entryMode)
            {
                case AnimationMode.SLIDE:
                    SlideIn(_playAudio);
                    break;
                case AnimationMode.ZOOM:
                    ZoomIn(_playAudio);
                    break;
                case AnimationMode.FADE:
                    FadeIn(_playAudio);
                    break;
            }
        }

        public void Exit(bool _playAudio)
        {
            prePopAction?.Invoke();

            switch (exitMode)
            {
                case AnimationMode.SLIDE:
                    SlideOut(_playAudio);
                    break;
                case AnimationMode.ZOOM:
                    ZoomOut(_playAudio);
                    break;
                case AnimationMode.FADE:
                    FadeOut(_playAudio);
                    break;
            }
        }

        private void SlideIn(bool _playAudio)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            animationCoroutine = StartCoroutine(SimpleAnimations.SlideIn(rectTransform, entryDirection, animationSpeed, postPushAction));

            PlayEntryClip(_playAudio);
        }

        private void SlideOut(bool _playAudio)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            animationCoroutine = StartCoroutine(SimpleAnimations.SlideOut(rectTransform, exitDirection, animationSpeed, postPopAction));

            PlayExitClip(_playAudio);
        }

        private void ZoomIn(bool _playAudio)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            animationCoroutine = StartCoroutine(SimpleAnimations.ZoomIn(rectTransform, animationSpeed, postPushAction));

            PlayEntryClip(_playAudio);
        }

        private void ZoomOut(bool _playAudio)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            animationCoroutine = StartCoroutine(SimpleAnimations.ZoomOut(rectTransform, animationSpeed, postPopAction));

            PlayExitClip(_playAudio);
        }

        private void FadeIn(bool _playAudio)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            animationCoroutine = StartCoroutine(SimpleAnimations.FadeIn(canvasGroup, animationSpeed, postPushAction));

            PlayEntryClip(_playAudio);
        }

        private void FadeOut(bool _playAudio)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            animationCoroutine = StartCoroutine(SimpleAnimations.FadeOut(canvasGroup, animationSpeed, postPopAction));

            PlayExitClip(_playAudio);
        }

        private void PlayEntryClip(bool _playAudio)
        {
            if (_playAudio && entryClip != null && audioSource != null)
            {
                if (audioCoroutine != null)
                {
                    StopCoroutine(audioCoroutine);
                }

                audioCoroutine = StartCoroutine(PlayClip(entryClip));
            }
        }

        private void PlayExitClip(bool _playAudio)
        {
            if (_playAudio && exitClip != null && audioSource != null)
            {
                if (audioCoroutine != null)
                {
                    StopCoroutine(audioCoroutine);
                }

                audioCoroutine = StartCoroutine(PlayClip(exitClip));
            }
        }

        private IEnumerator PlayClip(AudioClip _clip)
        {
            audioSource.enabled = true;

            WaitForSeconds Wait = new WaitForSeconds(_clip.length);

            audioSource.PlayOneShot(_clip);

            yield return Wait;

            audioSource.enabled = false;
        }
    }
}
