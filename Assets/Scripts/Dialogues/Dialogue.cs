using Ui;
using UnityEngine;

namespace Dialogues
{
    public class Dialogue : MonoBehaviour
    {
        public string Name;
        public string Text;
        private DialogueManager dialogueManager;
        private bool isTriggered;
        private bool onDialogue;
        
        private void Start()
        {
            dialogueManager = FindObjectOfType<DialogueManager>(true);
        }

        private void Update()
        {
            if (onDialogue && Input.GetKeyDown(KeyCode.X))
            {
                dialogueManager.Deactivate();
                onDialogue = false;
                Time.timeScale = 1;
            } else if (isTriggered && Input.GetKeyDown(KeyCode.X) && !onDialogue)
            {
                dialogueManager.PrepareDialogue(Name, Text);
                dialogueManager.Activate();
                onDialogue = true;
                Time.timeScale = 0;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isTriggered = true;
                GameObject.FindGameObjectWithTag("IconsCanvas").GetComponent<IconsCanvasManager>().IconChat.SetActive(true);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isTriggered = false;
                GameObject.FindGameObjectWithTag("IconsCanvas").GetComponent<IconsCanvasManager>().IconChat.SetActive(false);
            }
        }
    }
}
