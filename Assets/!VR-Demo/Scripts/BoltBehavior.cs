using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class BoltBehavior : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxDistance = 50f;
    [SerializeField] private float destroyDelay = 1f;
    [SerializeField] private LayerMask hitLayer;

    private Vector3 initialPosition;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        float distanceTraveled = Vector3.Distance(initialPosition, transform.position);
        if (distanceTraveled >= maxDistance)
        {
            DestroyShot();
            return;
        }

        HandleMovement();
    }

    private void HandleMovement()
    {
        float moveDistance = speed * Time.deltaTime;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, moveDistance, hitLayer))
        {
            DestroyShot();
        }
        else
        {
            transform.Translate(Vector3.forward * moveDistance);
        }
    }

    private void DestroyShot()
    {
        meshRenderer.enabled = false;
        Destroy(gameObject, destroyDelay);
        Destroy(this);
    }
}