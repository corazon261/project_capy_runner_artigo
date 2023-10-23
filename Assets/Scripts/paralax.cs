using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    private float length;
    private float startPos;

    private Transform cam;
    public float paralaxSpeed;

    void Start()
    {
        startPos = transform.position.x; //posição inicial
        length = GetComponent<SpriteRenderer>().bounds.size.x; //largura do sprite
        cam = Camera.main.transform;
    }

    
    void Update()
    {
        float temp = (cam.position.x * (1 - paralaxSpeed));
        float Distance = (cam.position.x * paralaxSpeed);

        transform.position = new Vector3(startPos+Distance, transform.position.y, transform.position.z);

        if (temp > startPos + length / 2)
        {
            startPos += length;
        }
        else if (temp < startPos - length / 2)
        {
            startPos -= length;
        }

    }
}
