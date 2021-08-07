using UnityEngine;

public class MainStatus : MonoBehaviour
{
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject settingsCanvas;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #region Public Methods
    public void ClickPlayButton()
    {
        // Load Play Scene
    }

    public void ClickSettingsButton()
    {
        // Open settings canvas and hide main status canvas
        settingsCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void ClickLeaderboardButton()
    {
        // Load Leaderboard canvas
    }
    #endregion

    #region Private Methods
    #endregion
}
