using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public List<LevelData> levels = new List<LevelData>();

    [SerializeField] private Dropper dropperPrefab;
    [SerializeField] private Catcher catcherPrefab;


    private void Start()
    {
        LoadLevel(0);
    }

    public void LoadLevel(int levelIndex)
    {
        LevelData level = levels[levelIndex];
        Instantiate(level.levelPrefab);
        GameController.Instance.SetValues(level.BubbleCount);
        
    }
    
    
    private void ClearLevel()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
