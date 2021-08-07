using UnityEngine;
using TMPro;

public class MainStatus : MonoBehaviour
{
    Player player;
    Navigator navigator;

    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject settingsCanvas;
    [SerializeField] GameObject quitCanvas;
    [SerializeField] GameObject privacyPolicyCanvas;

    [SerializeField] TextMeshPro scoreText;

    void Start()
    {
        navigator = FindObjectOfType<Navigator>();
        player = FindObjectOfType<Player>();
        player.LoadPlayer();

        SetScore();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitCanvas.SetActive(true);
            mainCanvas.SetActive(false);
        }
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
        navigator.LoadLeaderboardScene();
    }
    #endregion

    #region Private Methods
    void SetScore()
    {
        scoreText.text = player.score.ToString();
    }
    #endregion
}
