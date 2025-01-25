using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public List<LevelData> levels = new List<LevelData>();

    [SerializeField] private Dropper dropperPrefab;
    [SerializeField] private Catcher catcherPrefab;

    private int levelCatcherCount = 0;

    private int currentLevelIndex = 0;

    private void Start()
    {
        LoadLevel(0);
    }

    public void LoadLevel(int levelIndex)
    {
        ClearLevel();
        LevelData level = levels[levelIndex];
        GameObject instantiatedPrefab= Instantiate(level.levelPrefab, transform);
        GameController.Instance.SetValues(level.BubbleCount);
        levelCatcherCount = instantiatedPrefab.GetComponentsInChildren<Catcher>().ToList().Count;
        GameController.Instance.StartLevel();
        ActionManager.OnLevelLoaded?.Invoke();
    }
    
    
    public void NextLevel()
    {
        currentLevelIndex++;
        
        if (currentLevelIndex < levels.Count)
        {
            LoadLevel(currentLevelIndex);
        }
    }
    
    public void RestartLevel()
    {
        LoadLevel(currentLevelIndex);
    }
    
    public void CatcherFull()
    {
        levelCatcherCount--;
        if (levelCatcherCount == 0)
        {
            if (!GameController.Instance.IsGamePlaying()) return;
            GameController.Instance.WinLevel();

        }
    }
    
    
    
    private void ClearLevel()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
