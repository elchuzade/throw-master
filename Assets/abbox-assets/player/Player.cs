using UnityEngine;

public class Player : MonoBehaviour
{
    public int score = 0;
    public string playerName = "";
    public bool playerCreated = false;
    public bool privacyPolicyAccepted = false;
    public bool privacyPolicyDeclined = false;
    public bool sounds = false;
    public bool haptics = false;

    void Awake()
    {
        transform.SetParent(transform.parent.parent);
        // Singleton
        int instances = FindObjectsOfType<Player>().Length;
        if (instances > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void ResetPlayer()
    {
        score = 0;
        playerName = "";
        playerCreated = false;
        privacyPolicyAccepted = false;
        privacyPolicyDeclined = false;
        sounds = false;
        haptics = false;

        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null)
        {
            ResetPlayer();
            data = SaveSystem.LoadPlayer();
        }

        score = data.score;
        playerName = data.playerName;
        playerCreated = data.playerCreated;
        privacyPolicyAccepted = data.privacyPolicyAccepted;
        privacyPolicyDeclined = data.privacyPolicyDeclined;
        sounds = data.sounds;
        haptics = data.haptics;
    }
}
