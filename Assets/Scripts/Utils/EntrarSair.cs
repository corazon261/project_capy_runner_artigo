using Dialogues;
using Ui;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class EntrarSair : MonoBehaviour
    {
        public Transform Destino;
        public bool KeyRequired;
        #if UNITY_EDITOR
            public SceneAsset SceneToLoad; 
        #endif

        [SerializeField] private string SceneName;
        private IconsCanvasManager iconCanvasScript;
        private GameObject jogador;
        private ChangeCamera scriptChangeCamera;
        private bool isInside;
        private bool hasKey;
        private DialogueManager dialogueManager;
        private bool onDialogue;
        
        private void Start()
        {
            jogador = GameObject.FindWithTag("Player");
            scriptChangeCamera = GetComponent<ChangeCamera>();
            iconCanvasScript = GameObject.FindGameObjectWithTag("IconsCanvas").GetComponent<IconsCanvasManager>();
            dialogueManager = FindObjectOfType<DialogueManager>(true);
        }

        private void Update()
        {
            if (isInside && Input.GetKeyDown(KeyCode.Y))
            {
                Time.timeScale = 0;
                if (KeyRequired && !hasKey && !onDialogue)
                {
                    dialogueManager.PrepareDialogue("", "Você não tem a chave :/");
                    dialogueManager.Activate();
                    onDialogue = true;
                    return;
                }
            
                if (onDialogue)
                {
                    dialogueManager.Deactivate();
                    onDialogue = false;
                    Time.timeScale = 1;
                    return;
                }
            
                iconCanvasScript.AskBox.SetActive(true);
            }
        }

        public void Confirm(bool yes)
        {
            if (yes)
            {
                Time.timeScale = 1;
                if (Destino != null)
                {
                    jogador.transform.position = Destino.position;
                }
                iconCanvasScript.AskBox.SetActive(false);
                if (scriptChangeCamera != null)
                {
                    scriptChangeCamera.ChangeActiveCamera();
                }
                
                #if UNITY_EDITOR
                    if (SceneToLoad != null)
                    {
                        SceneManager.LoadScene(SceneToLoad.name);
                        return;
                    }
                #endif

                if (SceneName != "")
                {
                    SceneManager.LoadScene(SceneName);
                }
                
            }
            else
            {
                Time.timeScale = 1;
                iconCanvasScript.AskBox.SetActive(false);
            }
        }
    
        private void OnTriggerStay2D(Collider2D other)
        {
            var iconsCanvasManager = iconCanvasScript;
            iconsCanvasManager.ScriptEntrarSair = GetComponent<EntrarSair>();
            iconsCanvasManager.IconIteraction.SetActive(true);
            if (other.gameObject.CompareTag("Player"))
            {
                isInside = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            iconCanvasScript.IconIteraction.SetActive(false);
            isInside = false;
        }

        public void GetKey()
        {
            hasKey = true;
        }
    }
}
