using System;
using Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dialogues
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Dialogue : MonoBehaviour
    {
        [Serializable]
        public class DialogueContent
        {
            public string Name;
            public string Text;
        }

        public bool OneTime;
        public DialogueContent[] DialogueContents;
        [Header("Nome da scene se for mudar ao acabar o dialogo")]
        public string SceneName;
        
        [SerializeField]
        private bool reachedEnd;
        private DialogueManager dialogueManager;
        private bool isTriggered;
        private bool onDialogue;
        private IconsCanvasManager iconsCanvasManager;
        private int currentDialogueIndex;
        
        
        private void Start()
        {
            dialogueManager = FindObjectOfType<DialogueManager>(true);
            iconsCanvasManager = GameObject.FindWithTag("IconsCanvas").GetComponent<IconsCanvasManager>();
        }

        private void Update()
        {
            if (reachedEnd && SceneName != "")
            {
                SceneManager.LoadScene(SceneName);
            }
            
            if (onDialogue && Input.GetKeyDown(KeyCode.Y))
            {
                if (currentDialogueIndex >= DialogueContents.Length)
                {
                    dialogueManager.Deactivate();
                    onDialogue = false;
                    currentDialogueIndex = 0;
                    if (OneTime)
                    {
                        reachedEnd = true;
                        iconsCanvasManager.IconChat.SetActive(false);
                    }
                    Time.timeScale = 1;
                    return;
                }
                
                dialogueManager.PrepareDialogue(DialogueContents[currentDialogueIndex].Name, DialogueContents[currentDialogueIndex].Text);
                dialogueManager.Activate();
                currentDialogueIndex++;
            } else if (isTriggered && Input.GetKeyDown(KeyCode.Y) && !onDialogue && !reachedEnd)
            {
                dialogueManager.PrepareDialogue(DialogueContents[currentDialogueIndex].Name, DialogueContents[currentDialogueIndex].Text);
                dialogueManager.Activate();
                onDialogue = true;
                currentDialogueIndex++;
                Time.timeScale = 0;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !reachedEnd)
            {
                isTriggered = true;
                iconsCanvasManager.IconChat.SetActive(true);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isTriggered = false;
                iconsCanvasManager.IconChat.SetActive(false);
            }
        }
    }
}
