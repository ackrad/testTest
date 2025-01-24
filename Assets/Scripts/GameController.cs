using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Get these datas from level
    private int bubbleCount = 0;
    private static GameController instance;

    private bool isGamePlaying = false;
    
    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameController();
            }

            return instance;
        }
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    public void SetValues(int bubbleCountForLevel)
    {
        bubbleCount = bubbleCountForLevel;
        ActionManager.OnBubbleCountChanged?.Invoke(bubbleCount);
    }
    
    public void BubbleBlownUp()
    {
        bubbleCount--;
        if (bubbleCount == 0)
        {
            Debug.Log("Level completed");
        }
    }
    
 
    public void BallCaught()
    {
        
    }
    
    public int GetBubbleCount()
    {
        return bubbleCount;
    }
    
    public void IncreaseBubbleCount()
    {
        bubbleCount++;
    }
    
    public void BallOutOfBounds()
    {
        LoseLevel();
    }
 
    
    private void LoseLevel()
    {
        EndLevel();
        Debug.Log("Level lost");
    }
    
    public void WinLevel()
    {
        EndLevel();
        Debug.Log("Level won");
    }
    
    
    public void BubbleCreated()
    {
        bubbleCount--;
        ActionManager.OnBubbleCountChanged?.Invoke(bubbleCount);
    }
    
    public void StartLevel()
    {
        isGamePlaying = true;
    }
    
    public void EndLevel()
    {
        isGamePlaying = false;
    }
    
    
    
    public bool IsGamePlaying()
    {
        return isGamePlaying;
    }
}
