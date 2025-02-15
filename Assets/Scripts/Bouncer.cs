using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    
    [SerializeField] private SpriteTest spriteTest;
    [SerializeField] private float timeToChangeSprite = 0.2f;
    private float timeSinceLastSpriteChange = 0;
    private int spriteIndex = 0;
    
    private SpriteRenderer spriteRenderer;
    [SerializeField] private PopParticle popParticlePrefab;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if(spriteTest == null)
        {
            return;
        }
        if(timeSinceLastSpriteChange >= timeToChangeSprite)
        {
            spriteTest.ChangeSprite();
            timeSinceLastSpriteChange = 0;
        }
        else
        {
            timeSinceLastSpriteChange += Time.deltaTime;
        }
        
        
        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Pop();
        }
    }


    public void Pop()
    {
        PopParticle popParticle = Instantiate(popParticlePrefab, transform.position, Quaternion.identity);
        popParticle.Pop(transform.localScale);
        ActionManager.OnBubbleBlownUp?.Invoke();
        BubbleCreator bubbleCreator = GetComponentInParent<BubbleCreator>();

        if (bubbleCreator != null)
        {
           bubbleCreator.BubbleBlownUp();
        }

        Destroy(gameObject);
        
        
    }
    
    
    
    public void PopOutOfGame()
    {
        PopParticle popParticle = Instantiate(popParticlePrefab, transform.position, Quaternion.identity);
        popParticle.Pop(transform.localScale);
        ActionManager.OnBubbleBlownUp?.Invoke();
        Destroy(gameObject);    }
}
