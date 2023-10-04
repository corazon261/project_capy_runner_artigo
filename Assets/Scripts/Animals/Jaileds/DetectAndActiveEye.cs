using System;
using Ui;
using UnityEngine;
using Utils;

namespace Animals.Jaileds
{
    public class DetectAndActiveEye : MonoBehaviour
    {
        private UIManager uiManager;
        private bool insideArea;
        private ChangeOpacity[] animals;
        private CameraSlide[] cameraSlides;
        
        private void Start()
        {
            uiManager = FindObjectOfType<Canvas>().GetComponent<UIManager>();
            animals = FindObjectsOfType<ChangeOpacity>();
            cameraSlides = FindObjectsOfType<CameraSlide>();
        }

        private void Update()
        {
            if (insideArea && Input.GetKeyDown(KeyCode.X))
            {
                foreach (var animal in animals)
                {
                    if (animal.GetIsTransparent())
                    {
                        animal.MudarNormal();
                    }
                    else
                    {
                        animal.MudarTransparente();
                        foreach (var cameraSlide in cameraSlides)
                        {
                            cameraSlide.IniciaMovimento();
                        }
                    }
                }
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                uiManager.ShowEye(true);
                insideArea = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                uiManager.ShowEye(false);
                insideArea = false;
                foreach (var animal in animals) {
                    animal.MudarNormal();
                }
            }
        }   
    }
}
