using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator : MonoBehaviour
{
    public Material[] allMaterials;
    int materialLength;
    private void Awake()
    {
         materialLength= allMaterials.Length;
    }
    public  void AssignRandomMaterials(List<GameObject> objectsToAssing , GameObject player)
    {
        List<Material> spawnedMats = new List<Material>();
        Material matToAdd;
        foreach (var item in objectsToAssing)
        {
            matToAdd = allMaterials[Random.Range(0, materialLength)];
            item.GetComponentInChildren<Renderer>().sharedMaterial = matToAdd;
            if (!spawnedMats.Contains(matToAdd))
            {
                spawnedMats.Add(matToAdd);
            }
        }
        player.GetComponentInChildren<Renderer>().sharedMaterial = spawnedMats[Random.Range(0, spawnedMats.Count)];
    }
  
}
