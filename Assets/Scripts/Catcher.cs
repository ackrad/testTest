using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    [SerializeField] private int ballsToCatch = 1;
    private int ballsCaught = 0;
    private TextMeshPro text;


    private void Start()
    {
        text = GetComponentInChildren<TextMeshPro>();
        SetText();
    }

    
    private void SetText()
    {
        text.text = ballsCaught + "/" + ballsToCatch;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            
            if(ballsCaught >= ballsToCatch)
            {
                return;
            }
            
            Destroy(other.gameObject);
            GameController.Instance.BallCaught();
            ballsCaught++;
            SetText();
            
        }
    }
}
