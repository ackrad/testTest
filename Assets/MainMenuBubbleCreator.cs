using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainMenuBubbleCreator : MonoBehaviour
{
    [SerializeField] private MainMenuBubbles bubblePrefab;
    
    [SerializeField] private float xRange = 2.5f;
    
    private float timeToCreateBubble = 0.5f;
    
    [SerializeField] private Vector2 randomTimeRange = new Vector2(0.5f, 2f);
    private float lastBubbleTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        timeToCreateBubble = Random.Range(randomTimeRange.x, randomTimeRange.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time - lastBubbleTime >= timeToCreateBubble)
        {
            CreateBubble();
            lastBubbleTime = Time.time;
            timeToCreateBubble = Random.Range(randomTimeRange.x, randomTimeRange.y);
        }
        
    }
    
    private void CreateBubble()
    {
        MainMenuBubbles bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
        bubble.transform.position = new Vector3(Random.Range(-xRange, xRange), transform.position.y, transform.position.z);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-xRange, 0, 0), new Vector3(xRange, 0, 0));
    }
}
