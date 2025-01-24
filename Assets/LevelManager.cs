using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public List<LevelData> levels = new List<LevelData>();

    [SerializeField] private Dropper dropperPrefab;
    [SerializeField] private Catcher catcherPrefab;


    private void Start()
    {
        LoadLevel(0);
    }

    public void LoadLevel(int levelIndex)
    {
        LevelData level = levels[levelIndex];
        Instantiate(level.levelPrefab);
        GameController.Instance.SetValues(level.BubbleCount, level.BallCount);
        
        List<Vector3> ballDropPoints = level.ballDropPoints;
        List<Vector3> ballTargetPoints = level.ballTargetPoints;
        
        foreach (var t in ballDropPoints)
        {
            Dropper dropper = Instantiate(dropperPrefab,transform);
            dropper.transform.position = t;
        }
        
        foreach (var t in ballTargetPoints)
        {
            Catcher catcher = Instantiate(catcherPrefab,transform);
            catcher.transform.position = t;
        }
        
        
    }
    
    
    private void ClearLevel()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
