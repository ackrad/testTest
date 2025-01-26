using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelLostPanel : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI whyLoseText;
    
    
    public void SetText(string text)
    {
        whyLoseText.text = text;
    }
}
