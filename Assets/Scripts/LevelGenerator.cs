using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] PlatformPrefabs;

    [SerializeField]
    private float platformWidth=10f;

    private List<Transform> spawnedPlatforms = new List<Transform>();

    // generates specified no of platforms 
    public void GenerateLevel(int noOfPlatformsToGenerate)
    {
        RemovePreviousPlatforms();
        Vector2 SpawnedObjPos = Vector2.zero;
        int randomIndex = 0;
        for (int i = 0; i < noOfPlatformsToGenerate; i++)
        {
            randomIndex = Random.Range(0, PlatformPrefabs.Length);
            Transform platform = Instantiate(PlatformPrefabs[randomIndex]).transform;
            platform.SetParent(transform);
            SpawnedObjPos.x = i * platformWidth;
            platform.localPosition = SpawnedObjPos;
            spawnedPlatforms.Add(platform);
                  
        }

    }

    // removes any spawned platforms from the level
    public void RemovePreviousPlatforms()
    {
        foreach (var item in spawnedPlatforms)
        {
            Destroy(item.gameObject);
        }
        spawnedPlatforms.Clear();
    }
}
