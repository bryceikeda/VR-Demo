using UnityEngine;

public class BlasterBasic : MonoBehaviour
{
    [SerializeField] private GameObject boltPrefab;

    [Header("Blaster Configuration")]
    [SerializeField] private float fireRate = 1.0f;
    [SerializeField] private float initialDelay = 1.0f; 
    [SerializeField] private int maxShots = 3;

    private float nextFireTime = 0f;
    private int shotsFired = 0; 

    private void Start()
    {
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