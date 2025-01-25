using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBubbles : MonoBehaviour
{
    private float timeToBlowUp = 5f;
    private float floatUpMoveSpeed = 0.1f;
    
    [SerializeField] private Vector2 randomTimeRange = new Vector2(0.5f, 2f);
    [SerializeField] private Vector2 randomFloatSpeedRange = new Vector2(0.05f, 0.2f);
    
    private float createTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        timeToBlowUp = Random.Range(randomTimeRange.x, randomTimeRange.y);
        floatUpMoveSpeed = Random.Range(randomFloatSpeedRange.x, randomFloatSpeedRange.y);
        createTime = Time.time;
        transform.localScale = Vector3.one * Random.Range(0.5f, 2f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * (floatUpMoveSpeed * Time.deltaTime);
        floatUpMoveSpeed = Mathf.Lerp(floatUpMoveSpeed, 0, Time.deltaTime);
        
        if(Time.time - createTime >= timeToBlowUp)
        {
            GetComponent<Bouncer>().Pop();

        }
    }
}
