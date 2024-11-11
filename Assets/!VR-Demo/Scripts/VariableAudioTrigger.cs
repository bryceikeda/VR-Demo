using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class VariableAudioTrigger : MonoBehaviour
{
    [SerializeField] private FloatVariable HP;

    [SerializeField] private FloatReference LowThreshold;

    private AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (HP.Value < LowThreshold)
        {
            if (!AudioSource.isPlaying)
                AudioSource.Play();
        }
        else
        {
            if (AudioSource.isPlaying)
                AudioSource.Stop();
        }
    }
}