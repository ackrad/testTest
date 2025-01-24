using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteRenderer : MonoBehaviour
{
    
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Image image;
    
    
    private float timeToChangeSprite = 0.2f;
    private float timeSinceLastSpriteChange = 0;
    private int spriteIndex = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spriteIndex = Random.Range(0, sprites.Count);
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
        image.sprite = sprites[spriteIndex];
    }
}
