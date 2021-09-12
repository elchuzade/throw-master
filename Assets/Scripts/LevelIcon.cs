using UnityEngine;
using static GlobalVariables;

public class LevelIcon : MonoBehaviour
{
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

    [SerializeField] GameObject frame;
    [SerializeField] GameObject background;
    [SerializeField] GameObject count;

    void Start()
    {
        // Lock every level initially
        count.SetActive(false);
    }

    public void SkipLevel(int index)
    {
        GetColorFromLevelIndex(index);
    }

    public void UnlockLevel(int index)
    {
        GetColorFromLevelIndex(index);
    }

    public void PassLevel(int index)
    {
        GetColorFromLevelIndex(index);
    }

    public Color32 GetColorFromLevelIndex(int index)
    {
        switch (index / 10)
        {
            case 0:
                return cyan;
            case 1:
                return red;
            case 2:
                return yellow;
            case 3:
                return green;
            case 4:
                return purple;
        }
        return levelWhite;
    }
}
