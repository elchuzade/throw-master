using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] Projectile projectile;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Target")
        {
            projectile.HitObstacle(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            projectile.DestroyProjectile();
        }
        else if (collision.gameObject.tag == "Limit")
        {
            projectile.DestroyProjectile();
        }
    }
}
