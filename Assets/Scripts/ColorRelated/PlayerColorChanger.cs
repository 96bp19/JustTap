using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    //Material myMat;

    public Material[] materialsToRandomize;

    private void Awake()
    {
        //myMat = GetComponentInChildren<Renderer>().sharedMaterial;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInChildren<Renderer>().sharedMaterial = materialsToRandomize[Random.Range(0, materialsToRandomize.Length)];
        }
    }
}
