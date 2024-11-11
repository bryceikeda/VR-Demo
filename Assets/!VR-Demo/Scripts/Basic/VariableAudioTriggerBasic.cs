using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class VariableAudioTriggerBasic : MonoBehaviour
{
    [SerializeField] private PlayerHealthBasic playerHealth;

    [Tooltip("Health value that heartbeat starts to play")]
    [SerializeField] private float LowThreshold = 25;

    private AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playerHealth.CurrentHealth < LowThreshold)
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