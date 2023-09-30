using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;
    private Transform cameraTransform;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = new Vector3(player.position.x, cameraTransform.position.y, -10);
    }
}
