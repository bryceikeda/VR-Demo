using UnityEngine;

public class BlasterWithConfig : MonoBehaviour
{
    [SerializeField] private BlasterConfiguration config;
    [SerializeField] private GameObject boltPrefab;

    private float fireRate = 1.0f;
    private float initialDelay = 1.0f; 
    private int maxShots = 3;

    private float nextFireTime = 0f;
    private int shotsFired = 0; 

    private void Start()
    {
        fireRate = config.FireRate;
        initialDelay = config.InitialDelay;
        maxShots = config.MaxShots;
        nextFireTime = Time.time + initialDelay;
    }

    private void Update()
    {
        // Check if enough time has passed to fire again
        if (Time.time >= nextFireTime && shotsFired < maxShots)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
            shotsFired++;
        }
    }

    private void Fire()
    {
        Instantiate(boltPrefab, transform.position, transform.rotation);
    }
}