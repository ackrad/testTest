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
    private bool firstDrop = true;
    
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
            if (GameController.Instance.GetBubbleCount() != 0)
            {
                return;
            }
            
            if(firstDrop)
            {

                StartCoroutine(DropBalls());
                firstDrop = false;
            }
            
        }
        
        
    }
    
    
    
    
    private void DropBall()
    {
        Rigidbody2D drop = Instantiate(dropObject, posToDrop.position, Quaternion.identity);
        drop.velocity = new Vector2(0, -5);
        ballCount--;
        SetText();
    }
    
    private IEnumerator DropBalls()
    {
        while (ballCount > 0)
        {
            DropBall();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
