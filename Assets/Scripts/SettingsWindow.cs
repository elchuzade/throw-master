using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
    Player player;

    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject settingsCanvas;

    [SerializeField] GameObject soundsDisableIcon;
    [SerializeField] GameObject hapticsDisableIcon;

    void Start()
    {
        player = FindObjectOfType<Player>();
        player.LoadPlayer();

        SetInitialValues();
    }

    #region Public Methods
    public void ClickCloseButton()
    {
        settingsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void ClickSoundsButton()
    {
        player.sounds = !player.sounds;
        player.SavePlayer();
        SetInitialValues();
    }

    public void ClickHapticsButton()
    {
        player.haptics = !player.haptics;
        player.SavePlayer();
        SetInitialValues();
    }
    #endregion

    #region Private Methods
    void SetInitialValues()
    {
        if (player.sounds)
        {
            soundsDisableIcon.SetActive(false);
        } else
        {
            soundsDisableIcon.SetActive(true);
        }

        if (player.haptics)
        {
            hapticsDisableIcon.SetActive(false);
        } else
        {
            hapticsDisableIcon.SetActive(true);
        }
    }
    #endregion
}
