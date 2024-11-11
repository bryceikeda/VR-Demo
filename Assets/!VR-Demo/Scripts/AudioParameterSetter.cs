using UnityEngine;
using UnityEngine.Audio;

public class AudioParameterSetterBasic : MonoBehaviour
{
    [Tooltip("Mixer to set the parameter in.")]
    [SerializeField] private AudioMixer Mixer;

    [Tooltip("Name of the parameter to set in the mixer.")]
    [SerializeField] private string ParameterName = "";

    [Tooltip("Variable to send to the mixer parameter.")]
    [SerializeField] private FloatVariable Variable;

    [Tooltip("Minimum value of the Variable that is mapped to the curve.")]
    [SerializeField] private FloatReference Min;

    [Tooltip("Maximum value of the Variable that is mapped to the curve.")]
    [SerializeField] private FloatReference Max;

    [Tooltip("Curve to evaluate in order to look up a final value to send as the parameter.\n" +
                "T=0 is when Variable == Min\n" +
                "T=1 is when Variable == Max")]
    [SerializeField] private AnimationCurve Curve;

    private void Update()
    {
        float t = Mathf.InverseLerp(Min.Value, Max.Value, Variable.Value);
        float value = Curve.Evaluate(Mathf.Clamp01(t));
        Mixer.SetFloat(ParameterName, value);
    }
}