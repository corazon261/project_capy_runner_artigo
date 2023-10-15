using TMPro;
using UnityEngine;

namespace Dialogues
{
    public class DialogueManager : MonoBehaviour
    {
        public GameObject Name;
        public GameObject Text;
        public GameObject NamePanel;
        
        private bool nameEmpty = true;
        
        private void SetName(string characterName)
        {
            Name.GetComponent<TextMeshProUGUI>().text = characterName;
            if (string.IsNullOrEmpty(characterName))
            {
                nameEmpty = true;
            }
            else
            {
                nameEmpty = false;
            }
        }

        private void SetText(string text)
        {
            Text.GetComponent<TextMeshProUGUI>().text = text;
        }
        
        public void PrepareDialogue(string characterName, string text)
        {
            SetName(characterName);
            SetText(text);
        }
        
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
        
        public void Activate()
        {
            NamePanel.SetActive(!nameEmpty);
            gameObject.SetActive(true);
        }
    }
}