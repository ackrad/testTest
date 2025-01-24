using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBubbleCounter : MonoBehaviour
{
    
    private List<Image> bubbleList = new List<Image>();
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        ActionManager.OnBubbleCountChanged += UpdateBubbleCount;
        bubbleList = new List<Image>(GetComponentsInChildren<Image>());
    }

    
    private void UpdateBubbleCount(int bubbleCount)
    {
        
        for (int i = 0; i < bubbleList.Count; i++)
        {
            if (i < bubbleCount)
            {
                bubbleList[i].enabled = true;
            }
            else
            {
                bubbleList[i].enabled = false;
            }
        }
        
    }
}
