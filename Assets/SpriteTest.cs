using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTest : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] SpriteRenderer spriteRenderer;
    
    private int spriteIndex = 0;
    // Start is called before the first frame update
    void Start()
    {

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

  
    
    public void ChangeSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Count)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
