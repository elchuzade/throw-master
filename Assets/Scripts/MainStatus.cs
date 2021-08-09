using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static GlobalVariables;

public class MainStatus : MonoBehaviour
{
    Player player;
    Navigator navigator;
    Server server;
    TV tv;

    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject settingsCanvas;
    [SerializeField] GameObject quitCanvas;
    [SerializeField] GameObject privacyPolicyCanvas;

    [SerializeField] GameObject leaderboardButton;
    [SerializeField] TextMeshPro scoreText;

    void Start()
    {
        navigator = FindObjectOfType<Navigator>();
        server = FindObjectOfType<Server>();
        tv = FindObjectOfType<TV>();
        player = FindObjectOfType<Player>();
        //player.ResetPlayer();
        player.LoadPlayer();
        server.GetVideoLink();

        if (player.privacyPolicyAccepted)
        {
            // Create a nwe player if it is not created yet, else save data
            if (player.playerCreated)
            {
                server.SavePlayerData(player);
            }
            else
            {
                server.CreatePlayer(player);
            }
        } else
        {

            ShowPrivacyPolicyWindow();
            leaderboardButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }

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
    public void SetVideoLinkSuccess(VideoJson response)
    {
        tv.SetAdLink(response.video);
        tv.SetAdButton(response.website);
    }

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
        if (player.privacyPolicyAccepted)
        {
            // Load Leaderboard canvas
            navigator.LoadLeaderboardScene();
        } else
        {
            ShowPrivacyPolicyWindow();
        }
    }

    public void ShowPrivacyPolicyWindow()
    {
        privacyPolicyCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }
    #endregion

    #region Private Methods
    void SetScore()
    {
        scoreText.text = player.score.ToString();
    }
    #endregion
}
