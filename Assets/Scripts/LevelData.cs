using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public List<Vector3> ballDropPoints = new List<Vector3>();
    public List<Vector3> ballTargetPoints = new List<Vector3>();
    public int BubbleCount = 0;
    public int BallCount = 0;
    public GameObject levelPrefab;
    
}
