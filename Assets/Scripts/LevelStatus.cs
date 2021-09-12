using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelStatus : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectilePosition;
    // To connect weapon to target when they collide
    List<GameObject> projectiles = new List<GameObject>();
    List<Projectile> projectileScripts = new List<Projectile>();

    GameObject projectile;
    Projectile projectileScript;

    [SerializeField] int totalProjectiles;
    [SerializeField] TextMeshPro projectilesCount;
    Camera mainCamera;

    bool launched = false;

    int connectedProjectilesCount = 0;

    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        InstantiateProjectile();
        SetProjectilesCount();
    }

    #region Public Methods
    public void LaunchProjectile()
    {
        if (!launched)
        {
            // When launching we need to access the last projectile in the list
            projectileScripts[projectileScripts.Count - 1].LaunchProjectile();
            launched = true;

            StartCoroutine(InstantiateNewProjectile());
        }
    }

    public void ConnectProjectileToObstacle()
    {
        // When connecting we need to access the first projectile in the list
        projectiles.Remove(projectiles[0]);
        projectileScripts.Remove(projectileScripts[0]);
        IncrementProjectilesCount();
    }

    public void InstantiateProjectile()
    {
        projectile = Instantiate(projectilePrefab, projectilePosition.position, Quaternion.identity);
        projectileScript = projectile.GetComponent<Projectile>();

        projectiles.Add(projectile);
        projectileScripts.Add(projectileScript);
    }

    public void ClickSkipButton()
    {

    }

    public void ShakeCamera(string shakeType)
    {
        // Shake the camera for hit or lose animation
        mainCamera.GetComponent<AnimationTrigger>().Trigger(shakeType);
    }
    #endregion

    #region Private Methods
    void IncrementProjectilesCount()
    {
        connectedProjectilesCount++;
        SetProjectilesCount();
    }

    void SetProjectilesCount()
    {
        projectilesCount.text = connectedProjectilesCount.ToString() + "/" + totalProjectiles.ToString();
    }
    #endregion

    IEnumerator InstantiateNewProjectile()
    {
        yield return new WaitForSeconds(0.5f);

        launched = false;

        InstantiateProjectile();
    }
}
