using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Chave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().PegarChave();
            Destroy(gameObject);
        }
    }
}
