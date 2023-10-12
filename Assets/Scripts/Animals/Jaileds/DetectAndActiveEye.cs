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
        
        private void Start()
        {
            uiManager = FindObjectOfType<Canvas>().GetComponent<UIManager>();
            animals = FindObjectsOfType<ChangeOpacity>();
        }

        private void Update()
        {
            if (insideArea && Input.GetButtonDown("Vertical"))
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
