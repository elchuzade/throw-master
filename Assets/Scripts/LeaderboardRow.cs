using UnityEngine;
using UnityEngine.UI;

public class LeaderboardRow : MonoBehaviour
{
    [SerializeField] Text rank;
    [SerializeField] Text playerName;
    [SerializeField] Text score;
    [SerializeField] GameObject meBackground;

    public void SetLeaderboardRow(int _rank, string _playerName, int _score, bool mine)
    {
        rank.text = _rank.ToString();
        playerName.text = _playerName;
        score.text = _score.ToString();

        if (mine)
        {
            meBackground.SetActive(true);
        } else
        {
            meBackground.SetActive(false);
        }
    }

    // For changing name from chang ename window after data has already been populated
    public void SetLeaderboardName(string _playerName)
    {
        playerName.text = _playerName;
    }
}
