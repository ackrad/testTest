using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsCatcher : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            GameController.Instance.BallOutOfBounds();
        }
    }
}
