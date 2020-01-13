using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private LevelGenerator levelGeneratorPrefab;

    private LevelGenerator _levelGeneratorInstance;

    [SerializeField] private int noOfPlatformsToGenerate = 10;
    
    void Start()
    {
        BeginGame();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    void BeginGame()
    {
        _levelGeneratorInstance = Instantiate(levelGeneratorPrefab);
        _levelGeneratorInstance.GenerateLevel(noOfPlatformsToGenerate);
    }

    void RestartGame()
    {
        Destroy(_levelGeneratorInstance.gameObject);
        BeginGame();
    }
}
