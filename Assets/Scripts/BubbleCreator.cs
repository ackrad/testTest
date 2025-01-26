using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCreator : MonoBehaviour
{

    [SerializeField] private Rigidbody2D bouncerObject;
    [SerializeField] private float scaleSpeed = 4f;
    private Transform bouncerObjectTransform;
    
    [SerializeField] private float scaleToBouncinessFactor = 0.8f;
    GameController gameController;
    private int bubbleCount = 0;
    
    private List<Bouncer> bouncers = new List<Bouncer>();
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.Instance;
        ActionManager.OnLevelLoaded += ClearAllBubbles;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (IsThereABubbleAtMousePointer())
            {
            }

            else
            {
                if (gameController.GetBubbleCount() == 0)
                    return;



                CreateBubbleAtMousePosition();
            }
        }

        if (Input.GetMouseButton(0))
        {
            BlowUpBubble();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopBlowingUpBubble();
        }
        
        
        
        
    }
    
    
    

    private void BlowUpBubble()
    {
        
        if (bouncerObjectTransform != null)
        {
            bouncerObjectTransform.localScale += new Vector3(0.1f, 0.1f, 0.1f) *(scaleSpeed* Time.deltaTime);
            // set bounciness of physics2d material depending on size
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            bouncerObjectTransform.position = mousePos;
        }
        
    }
    
    
    private void StopBlowingUpBubble()
    {
        if (bouncerObjectTransform != null)
        {
            PhysicsMaterial2D mat = new PhysicsMaterial2D();
            mat.bounciness = bouncerObjectTransform.localScale.x * scaleToBouncinessFactor;
            bouncerObjectTransform.GetComponent<Rigidbody2D>().sharedMaterial = mat;
            bouncerObjectTransform = null;
        }
    }
    
    
    private void ClearAllBubbles()
    {
        bubbleCount = 0;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    public void BubbleBlownUp()
    {
        bubbleCount--;
        
    }
    
    public int GetBubbleCount()
    {
        return bubbleCount;
    }
    
    private bool IsThereABubbleAtMousePointer()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        bool isThereABubble = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePos, 0.1f);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Bubble"))
            {
                collider.GetComponentInParent<Bouncer>().PopOutOfGame();
                bubbleCount--;
                isThereABubble = true;
                gameController.BubblePickedUp();
                
            }
        }

        
        return isThereABubble;
    }
    
    
    
    private void CreateBubbleAtMousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Rigidbody2D bounce = Instantiate(bouncerObject, mousePos, Quaternion.identity,transform);
        bouncerObjectTransform = bounce.transform;
        
        bouncerObjectTransform.localScale = Vector3.zero;
        GameController.Instance.BubbleCreated();
        bubbleCount++;
        bouncers.Add(bounce.GetComponent<Bouncer>());

    }
}
