using UnityEngine;

public class QuitWindow : MonoBehaviour
{
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject quitCanvas;

    public void ClickCloseButton()
    {
        quitCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
