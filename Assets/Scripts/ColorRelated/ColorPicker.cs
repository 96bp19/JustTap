using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public Material[] materialsUsed;

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Material collisionMat = collision.GetComponent<Renderer>().sharedMaterial;
        Material myMaterial = this.GetComponent<Renderer>().sharedMaterial;

        if (ColorChecker.CheckColor(collisionMat , myMaterial))
        {
            Debug.Log("same mat");
        }
        else
        {
            Debug.Log("different mat");
        }

    }
}
