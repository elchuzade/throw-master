using UnityEngine;
using UnityEngine.UI;

public class VerticalScroll : MonoBehaviour
{
    [SerializeField] Scrollbar scrollbar;

    void Start()
    {
        scrollbar.value = 1;
    }
}
