using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    
    [SerializeField] private float offsetIncreaseSpeed = 0.1f;
    
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        material = lineRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
        material.mainTextureOffset += new Vector2(0, offsetIncreaseSpeed * Time.deltaTime);
        
        
    }
}
