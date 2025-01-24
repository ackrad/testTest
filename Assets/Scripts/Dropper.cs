using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dropper : MonoBehaviour
{

    [SerializeField] private Rigidbody2D dropObject;
    [SerializeField] private Transform posToDrop;

    [SerializeField] private int ballCount = 1;
    TextMeshPro textMeshPro;
    
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
        SetText();
    }

    
    
    private void SetText()
    {
        textMeshPro.text = ballCount.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBall();
            
        }
        
        
    }
    
    
    
    
    private void DropBall()
    {
        Rigidbody2D drop = Instantiate(dropObject, posToDrop.position, Quaternion.identity);
        drop.velocity = new Vector2(0, -5);
        ballCount--;
        SetText();
    }
}
