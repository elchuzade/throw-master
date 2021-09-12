using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public int score = 0;
    public string playerName = "";
    public bool playerCreated = false;
    public bool privacyPolicyAccepted = false;
    public bool privacyPolicyDeclined = false;
    public bool sounds = false;
    public bool haptics = false;
    public List<long> leaderboardClicks = new List<long>();

    // 0 - locked, 1 passed, -1 skippped
    public List<int> axeLevels = new List<int>() {
        1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };

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
        leaderboardClicks = new List<long>();
        axeLevels = new List<int>() {
            1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };

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
        leaderboardClicks = data.leaderboardClicks;
        axeLevels = data.axeLevels;
    }
}
