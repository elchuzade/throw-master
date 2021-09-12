using UnityEngine;
using static GlobalVariables;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] RotateDirection direction;

    int angularDirection;
    public bool rotating = false;

    void Start()
    {
        if (direction == RotateDirection.Clockwise)
        {
            angularDirection = 1;
        }
        else
        {
            angularDirection = -1;
        }
    }

    void FixedUpdate()
    {
        if (rotating)
        {
            transform.Rotate(Vector3.forward, rotateSpeed * angularDirection * Time.fixedDeltaTime);
        }
    }
}
