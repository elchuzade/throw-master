using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;

    LevelStatus levelStatus;

    [SerializeField] GameObject components;
    // To turn into obstacles (Only Rigidbody included objects are allowed)
    [SerializeField] GameObject[] componentsChildren;

    Rotate rotateScript;

    bool moving = false;

    void Start()
    {
        levelStatus = FindObjectOfType<LevelStatus>();

        rb = GetComponent<Rigidbody>();

        // If projectile is rotating then access the script
        rotateScript = components.GetComponent<Rotate>();
    }

    public void LaunchProjectile()
    {
        moving = true;

        rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);

        if (rotateScript != null)
        {
            rotateScript.rotating = true;
        }
    }

    public void HitObstacle(GameObject obstacle)
    {
        // There are 3 parts so 3 times hit obstacle might happen. Only once we need to create new projectile
        // ?? Comment above might be false with new designs of axe
        if (moving)
        {
            levelStatus.ConnectProjectileToObstacle();
        }

        moving = false;
        rb.velocity = Vector3.zero;

        // If rotating then stop it
        if (rotateScript != null)
        {
            rotateScript.rotating = false;
        }

        transform.SetParent(obstacle.transform);

        MakeProjectileStatic();
        levelStatus.ShakeCamera("Hit");
    }

    public void DestroyProjectile()
    {
        levelStatus.ShakeCamera("Lose");
        Invoke("RestartLevel", 0.2f);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }

    void MakeProjectileStatic()
    {
        // Projectile that has reached its target should be static, so it acts like an obstacle for the next projectile
        for (int i = 0; i < componentsChildren.Length; i++)
        {
            componentsChildren[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            componentsChildren[i].tag = "Obstacle";
        }
    }
}
