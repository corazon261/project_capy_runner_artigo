using System;
using Ui;
using UnityEngine;
using Utils;

namespace Animals.Jaileds
{
    public class DetectAndActiveEye : MonoBehaviour
    {
        private bool insideArea;
        private ChangeOpacity[] animals;
        
        private void Start()
        {
            animals = FindObjectsOfType<ChangeOpacity>();
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
                    }
                }
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameObject.FindGameObjectWithTag("IconsCanvas").GetComponent<IconsCanvasManager>().IconOlho.SetActive(true);
                insideArea = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameObject.FindGameObjectWithTag("IconsCanvas").GetComponent<IconsCanvasManager>().IconOlho.SetActive(true);
                insideArea = false;
                foreach (var animal in animals) {
                    animal.MudarNormal();
                }
            }
        }   
    }
}
