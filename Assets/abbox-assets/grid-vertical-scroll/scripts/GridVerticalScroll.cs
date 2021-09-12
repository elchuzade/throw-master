using UnityEngine;
using UnityEngine.UI;

public class GridVerticalScroll : MonoBehaviour
{
    [SerializeField] Scrollbar scrollbar;

    void Start()
    {
        scrollbar.value = 1;
    }
}
