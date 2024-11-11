using UnityEngine;
using UnityEngine.UI;


public class ImageFillSetterBasic : MonoBehaviour
{
    [Tooltip("Value to use as the current health")]
    [SerializeField] private PlayerHealthBasic playerHealth;

    [Tooltip("Image to set the fill amount on.")]
    [SerializeField] private Image Image;
    
    private float Min = 0f;
    private float Max = 100f;

    private void Start()
    {
        Min = playerHealth.MinHealth;
        Max = playerHealth.MaxHealth;
    }

    private void Update()
    {
        Image.fillAmount = Mathf.Clamp01(
            Mathf.InverseLerp(Min, Max, playerHealth.CurrentHealth));
    }
}