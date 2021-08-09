using UnityEngine;
using UnityEngine.UI;

public class PrivacyPolicyWindow : MonoBehaviour
{
    Player player;

    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject privacyPolicyCanvas;
    [SerializeField] GameObject leaderboardButton;

    void Start()
    {
        player = FindObjectOfType<Player>();
        player.LoadPlayer();
    }

    public void ClickTermsOfUse()
    {
        Application.OpenURL("https://abboxgames.com/terms-of-use");
    }

    public void ClickPrivacyPolicy()
    {
        Application.OpenURL("https://abboxgames.com/privacy-policy");
    }

    public void ClickAcceptButton()
    {
        player.privacyPolicyAccepted = true;
        player.SavePlayer();
        ClickCloseButton();
        leaderboardButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void ClickCloseButton()
    {
        player.privacyPolicyDeclined = true;
        player.SavePlayer();

        privacyPolicyCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
