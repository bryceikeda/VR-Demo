using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Takes a FloatVariable and sends a curve filtered version of its value 
/// to an exposed audio mixer parameter every frame on Update.
/// </summary>
public class AudioParameterSetter : MonoBehaviour
{
    [Tooltip("Mixer to set the parameter in.")]
    [SerializeField] private AudioMixer Mixer;

    [Tooltip("Name of the parameter to set in the mixer.")]
    [SerializeField] private string ParameterName = "";

    [Tooltip("Value to use as the current health")]
    [SerializeField] private PlayerHealthBasic playerHealth;

    [Tooltip("Curve to evaluate in order to look up a final value to send as the parameter.\n" +
                "T=0 is when Variable == Min\n" +
                "T=1 is when Variable == Max")]
    public AnimationCurve Curve;

    private float Min = 0f;
    private float Max = 100f;

    private void Start()
    {
        Min = playerHealth.MinHealth;
        Max = playerHealth.MaxHealth;
    }

    private void Update()
    {
        float t = Mathf.InverseLerp(Min, Max, playerHealth.CurrentHealth);
        float value = Curve.Evaluate(Mathf.Clamp01(t));
        Mixer.SetFloat(ParameterName, value);
    }
}