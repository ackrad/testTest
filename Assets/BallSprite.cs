using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSprite : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    private SpriteRenderer spriteRenderer;
    private float timeToChangeSprite = 0.2f;
    private float timeSinceLastSpriteChange = 0;
    private int spriteIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeSinceLastSpriteChange >= timeToChangeSprite)
        {
            ChangeSprite();
            timeSinceLastSpriteChange = 0;
        }
        else
        {
            timeSinceLastSpriteChange += Time.deltaTime;
        }
        
    }
    
    private void ChangeSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Count)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
