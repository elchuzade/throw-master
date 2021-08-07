using UnityEngine;

public class PrivacyPolicyWindow : MonoBehaviour
{
    Player player;

    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject privacyPolicyCanvas;

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
    }

    public void ClickCloseButton()
    {
        player.privacyPolicyDeclined = true;
        player.SavePlayer();

        privacyPolicyCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
