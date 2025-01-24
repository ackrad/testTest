using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Get these datas from level
    private int bubbleCount = 0;
    private static GameController instance;
    
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
        Debug.Log("Ball out of bounds");
    }
 
    
    public void BubbleCreated()
    {
        bubbleCount--;
        ActionManager.OnBubbleCountChanged?.Invoke(bubbleCount);
    }
}
