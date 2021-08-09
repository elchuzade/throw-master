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
    }
}
