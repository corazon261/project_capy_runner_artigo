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
        private IconsCanvasManager iconsCanvasManager;
        
        private void Start()
        {
            animals = FindObjectsOfType<ChangeOpacity>();
            iconsCanvasManager = GameObject.FindGameObjectWithTag("IconsCanvas").GetComponent<IconsCanvasManager>();
        }

        private void Update()
        {
            if (insideArea && Input.GetKeyDown(KeyCode.X))
            {
                ChangeAnimalsSprite();
            }
        }
        
        private void ChangeAnimalsSprite(bool transparent = false)
        {
            foreach (var animal in animals)
            {
                if (animal.GetIsTransparent() || transparent)
                {
                    animal.MudarNormal();
                }
                else
                {
                    animal.MudarTransparente();
                }
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                iconsCanvasManager.IconOlho.SetActive(true);
                insideArea = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                iconsCanvasManager.IconOlho.SetActive(false);
                insideArea = false;
                ChangeAnimalsSprite(true);
            }
        }   
    }
}
