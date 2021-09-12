using UnityEngine;
using UnityEngine.UI;

public class LevelsStatus : MonoBehaviour
{
    Player player;

    // Based on index of level color will change
    Color32 cyan = new Color32(0, 235, 255, 255);
    Color32 red = new Color32(223, 80, 100, 255);
    Color32 yellow = new Color32(212, 208, 66, 255);
    Color32 green = new Color32(63, 209, 84, 255);
    Color32 purple = new Color32(240, 126, 244, 255);

    // Skipped level
    Color32 levelPink = new Color32(227, 180, 227, 255);
    // Passed level
    Color32 levelGreen = new Color32(161, 223, 131, 255);
    // Unlocked level
    Color32 levelWhite = new Color32(255, 225, 255, 255);

    [SerializeField] LevelIcon[] levelIcons;

    [SerializeField] GameObject axeIcon;
    [SerializeField] GameObject shurikenIcon;
    [SerializeField] GameObject knifeIcon;

    // Change color based on the latest unlocked level of that weapon
    [SerializeField] GameObject weaponFrame;

    void Start()
    {
        int lastUnlockedIndex = 0;

        player = FindObjectOfType<Player>();
        player.LoadPlayer();

        for (int i = 0; i < levelIcons.Length; i++)
        {
            if (player.axeLevels[i] == -1)
            {
                levelIcons[i].SkipLevel(i);
            } else if (player.axeLevels[i] == 1)
            {
                lastUnlockedIndex = i;
                levelIcons[i].UnlockLevel(i);
            } else if (player.axeLevels[i] == 2)
            {
                levelIcons[i].PassLevel(i);
            }
        }

        // Get color of frame of last unlocked level based on its index
        weaponFrame.GetComponent<Image>().color = levelIcons[lastUnlockedIndex].GetColorFromLevelIndex(lastUnlockedIndex);
    }
}
