using UnityEngine;
using UnityEngine.UI;

public class ChangeNameWindow : MonoBehaviour
{
    Player player;
    [SerializeField] InputField nameInput;

    [SerializeField] GameObject leaderboardCanvas;
    [SerializeField] GameObject changeNameCanvas;

    LeaderboardStatus leaderboardStatus;

    void Start()
    {
        leaderboardStatus = FindObjectOfType<LeaderboardStatus>();
        player = FindObjectOfType<Player>();
        player.LoadPlayer();
    }

    public void ClickSaveButton()
    {
        player.playerName = nameInput.text;
        player.SavePlayer();

        leaderboardStatus.UpdatePlayerName();

        ClickCloseButton();
    }

    public void ClickCloseButton()
    {
        changeNameCanvas.SetActive(false);
        leaderboardCanvas.SetActive(true);
    }
}
