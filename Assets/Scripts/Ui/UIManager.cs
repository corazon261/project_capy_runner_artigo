using UnityEngine;

namespace Ui
{
    public class UIManager : MonoBehaviour
    {
        public GameObject PainelOlho;

        public void ShowEye(bool value)
        {
            PainelOlho.SetActive(value);
        }
    }
}
