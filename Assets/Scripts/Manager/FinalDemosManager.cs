using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDemosManager : MonoBehaviour
{
    public void ClickJogarNovamente()
    {
        GameManager.Instance.ReturnMainMenu();
    }
}
