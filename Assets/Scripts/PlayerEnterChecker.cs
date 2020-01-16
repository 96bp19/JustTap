using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterChecker : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           // Debug.Log("game over");
        }
    }
}
