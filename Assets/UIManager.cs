using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private LevelBubbleCounter levelBubbleCounter;
    [SerializeField] private GameObject levelWinPanel;
    [SerializeField] private GameObject levelFailPanel;
    
    
    private LevelManager levelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        ActionManager.OnLevelCompleted += ShowLevelWinPanel;
        ActionManager.OnLevelFailed += ShowLevelFailPanel;
        
        levelManager = FindObjectOfType<LevelManager>();
        CloseWinLosePanels();
        
        
    }
    
    private void ShowLevelWinPanel()
    {
        levelWinPanel.SetActive(true);
    }
    
    private void ShowLevelFailPanel()
    {
        levelFailPanel.SetActive(true);
    }
    
    public void CloseWinLosePanels()
    {
        levelWinPanel.SetActive(false);
        levelFailPanel.SetActive(false);
    }

    public void NextLevelButtonPressed()
    {
        CloseWinLosePanels();
        levelManager.NextLevel();

    }
    
    
    public void RestartLevelButtonPressed()
    {
        CloseWinLosePanels();
        levelManager.RestartLevel();
    }
    
}
