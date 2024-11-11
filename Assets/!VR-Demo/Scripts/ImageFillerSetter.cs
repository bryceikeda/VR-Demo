using UnityEngine;
using UnityEngine.UI;


public class ImageFillSetter : MonoBehaviour
{
    [Tooltip("Value to use as the current health")]
    [SerializeField] private FloatVariable HP;

    [Tooltip("Min value that Variable to have no fill on Image.")]
    [SerializeField] private FloatReference Min; 

    [Tooltip("Max value that Variable can be to fill Image.")]
    [SerializeField] private FloatReference Max;

    [Tooltip("Image to set the fill amount on.")]
    [SerializeField] private Image Image;

    private void Update()
    {
        Image.fillAmount = Mathf.Clamp01(
            Mathf.InverseLerp(Min, Max, HP.Value));
    }
}