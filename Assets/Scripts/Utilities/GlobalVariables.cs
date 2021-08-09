using UnityEngine;
using System.Collections.Generic;

public class GlobalVariables : MonoBehaviour
{
    public enum RotateDirection { Clockwise, CounterClockwise }

    public enum ChestColors { None, Red, Gold, Silver }

    public enum Rewards { Diamond, Coin, RedKey, SilverKey, GoldKey }

    public enum Currency { Diamond, Coin }

    public enum Boxes { Lightning, Shield, Bullet, Speed, Diamond, Coin, Question }

    public enum TrapTypes { Bomb, Dynamite, Chainsaw };

    public enum ChestPrizeTypes { Coin, Diamond, Skill, Ball };

    public enum BallTypes { Common, Uncommon, Rare, Legendary, Special };

    // Video Link
    public class VideoJson
    {
        public string id; // link id to measure clicks
        public string video; // link to video
        public string name; // product title
        public string website; // link to follow on click
        public string playMarket; // link to follow on click
        public string appStore; // link to follow on click
    }

    public class Header
    {
        public string deviceId;
        public string deviceOS;
    }

    public class LeaderboardItem
    {
        public string playerName;
        public int rank;
        public int score;
    }

    public class PlayerSaveData
    {
        public int score;
        public bool sounds;
        public bool haptics;
        public string playerName;
        // Clicks
        public List<long> leaderboardClicks;
    }
}
