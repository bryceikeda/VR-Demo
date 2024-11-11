using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeAnimation : MonoBehaviour
{
    [SerializeField, Range(0, 1)]
    private float animationDuration = 0.1f;

    [SerializeField]
    private bool isExtended;

    [SerializeField]
    private float minLength = 0f;

    [SerializeField]
    private float maxLength = 0.7f;

    [SerializeField]
    private float initialScaleX = 0.05f;

    [SerializeField]
    private float initialScaleZ = 0.05f;

    [SerializeField]
    private List<GameObject> BladeBases; 

    private float animationStep = 0f;
    private float currentLength = 0f;
    private Coroutine animationCoroutine;

    // Initialize animation properties
    void Start()
    {
        if (BladeBases.Count > 0)
        {
            initialScaleX = BladeBases[0].transform.localScale.x;
            initialScaleZ = BladeBases[0].transform.localScale.z;
            maxLength = BladeBases[0].transform.localScale.y;
        }
        currentLength = maxLength;
        animationStep = maxLength / animationDuration;
        isExtended = true;
    }

    // Handle input to trigger saber animation
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            animationCoroutine = StartCoroutine(AnimateSaber());
        }
    }

    // Coroutine to animate saber extension and retraction
    private IEnumerator AnimateSaber()
    {
        float targetLength = isExtended ? minLength : maxLength;
        float direction = isExtended ? -1 : 1;
        isExtended = !isExtended;

        if(isExtended)
        {
            SetAllBladesActive(true);
        }

        while ((direction > 0 && currentLength < targetLength) || (direction < 0 && currentLength > targetLength))
        {
            currentLength += direction * animationStep * Time.deltaTime;
            currentLength = Mathf.Clamp(currentLength, minLength, maxLength);
            SetAllBladeLengths(currentLength);
            yield return null;
        }

        if (!isExtended)
        {
            SetAllBladesActive(false);
        }
    }

    private void SetAllBladesActive(bool active)
    {
        foreach(GameObject blade in BladeBases)
        {
            blade.SetActive(active);
        }
    }

    private void SetAllBladeLengths(float length)
    {
        foreach (GameObject blade in BladeBases)
        {
            blade.transform.localScale = new Vector3(initialScaleX, length, initialScaleZ);
        }
    }
}
