using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAskBox : MonoBehaviour
{
    public GameObject gameObjectBtnFirstSelected;    
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SetFisrtSelected(gameObjectBtnFirstSelected);
    }    
}
