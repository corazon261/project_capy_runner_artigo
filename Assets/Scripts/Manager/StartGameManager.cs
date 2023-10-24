using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartGameManager : MonoBehaviour
{
    public RectTransform logoTransform;
    public float speedMove = 1;

    private void Awake()
    {
        logoTransform.localScale = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ZoomIn(logoTransform, speedMove));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ZoomIn(RectTransform Transform, float Speed)
    {
        yield return new WaitForSeconds(0.5f);
        
        float time = 0;
        while (time < 1)
        {
            Transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, time);
            yield return null;
            time += Time.unscaledDeltaTime * Speed;
        }

        Transform.localScale = Vector3.one;

        StartCoroutine(ZoomOut(logoTransform, speedMove));
    }

    public IEnumerator ZoomOut(RectTransform Transform, float Speed)
    {
        yield return new WaitForSeconds(2f);
        
        float time = 0;
        while (time < 1)
        {
            Transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, time);
            yield return null;
            time += Time.unscaledDeltaTime * Speed;
        }

        Transform.localScale = Vector3.zero;

        GameManager.Instance.LoadScene("Main Menu");
    }
}
