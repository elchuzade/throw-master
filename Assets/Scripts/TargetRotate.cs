using UnityEngine;

public class TargetRotate : MonoBehaviour
{
    // Such as 0, 0, 1
    [SerializeField] Vector3 rotateDirection;

    void Update()
    {
        transform.Rotate(rotateDirection, Space.Self);
    }
}
