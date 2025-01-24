using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PopParticle : MonoBehaviour
{
    [SerializeField] private List<Sprite> popSprites;
    [SerializeField] private SpriteRenderer spRend;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        spRend.sprite = popSprites[Random.Range(0, popSprites.Count)];
        spRend.transform.localScale = Vector3.zero;
    }

   
    
    public void Pop(Vector3 scale)
    {
        spRend.transform.DOScale(scale, 0.2f).OnComplete(() =>
        {
            Destroy(spRend);
        });
        
        
        Destroy(gameObject,4f);
    }
    
}
