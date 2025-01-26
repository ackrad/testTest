using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public List<LevelData> levels = new List<LevelData>();

    [SerializeField] private Dropper dropperPrefab;
    [SerializeField] private Catcher catcherPrefab;

    private int levelCatcherCount = 0;

    private int currentLevelIndex = 0;

    private List<Rigidbody2D> balls = new List<Rigidbody2D>();
    
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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }


    public void NextLevel()
    {
        currentLevelIndex++;
        
        if (currentLevelIndex < levels.Count)
        {
            LoadLevel(currentLevelIndex);
        }

        else
        {
            SceneManager.LoadScene(2);
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
            
            BubbleCreator bubbleCreator = FindObjectOfType<BubbleCreator>();
            
            if (bubbleCreator.GetBubbleCount() != 0)
            {
                GameController.Instance.NotAllBubblesPopped();
                return;
            }
            
            
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
    
    
 
    
    public void AddBall(Rigidbody2D ball)
    {
        balls.Add(ball);
    }
}
