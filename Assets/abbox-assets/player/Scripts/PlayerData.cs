using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public int score = 0;
    public string playerName = "";
    public bool playerCreated = false;
    public bool privacyPolicyAccepted = false;
    public bool privacyPolicyDeclined = false;
    public bool sounds = false;
    public bool haptics = false;
    public List<long> leaderboardClicks = new List<long>();

    // -1 skippped, 0 - locked, 1 unlocked, 2 passed
    public List<int> axeLevels = new List<int>() {
        1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };

    public PlayerData (Player player)
    {
        score = player.score;
        playerName = player.playerName;
        playerCreated = player.playerCreated;
        privacyPolicyAccepted = player.privacyPolicyAccepted;
        privacyPolicyDeclined = player.privacyPolicyDeclined;
        sounds = player.sounds;
        haptics = player.haptics;
        leaderboardClicks = player.leaderboardClicks;
        axeLevels = player.axeLevels;
    }
}
