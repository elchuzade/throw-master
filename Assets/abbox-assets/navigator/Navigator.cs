using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadLeaderboardScene()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }
}
