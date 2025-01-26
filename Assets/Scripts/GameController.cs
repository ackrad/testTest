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
    
    
    
 
    public void BallCaught()
    {
        
    }
    
    public int GetBubbleCount()
    {
        return bubbleCount;
    }
    
  
    
    public void BallOutOfBounds()
    {
        Debug.Log("Ball Out of Bounds");
        LoseLevel();
    }
 
    
    private void LoseLevel()
    {
        EndLevel();
        ActionManager.OnLevelFailed?.Invoke();
    }
    
    public void WinLevel()
    {
        EndLevel();
        ActionManager.OnLevelCompleted?.Invoke();
    }
    
    
    public void BubbleCreated()
    {
        bubbleCount--;
        ActionManager.OnBubbleCountChanged?.Invoke(bubbleCount);
    }
    
    public void BubblePickedUp()
    {
        bubbleCount++;
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
    
    public void NotAllBubblesPopped()
    {
        Debug.Log("Not all bubbles popped");
        LoseLevel();
    }
    
    public bool IsGamePlaying()
    {
        return isGamePlaying;
    }
    
    
   
}
