using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class UnitHealthWithEvents : MonoBehaviour
{
    [SerializeField] private FloatVariable HP;
    [SerializeField] private bool ResetHP;
    [SerializeField] private FloatReference StartingHP;
    [SerializeField] private UnityEvent DamageEvent;
    [SerializeField] private UnityEvent DeathEvent;

    private void Start()
    {
        if (ResetHP)
            HP.SetValue(StartingHP);
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
        if (damage != null)
        {
            HP.ApplyChange(-damage.DamageAmount);
            DamageEvent.Invoke();
        }

        if (HP.Value <= 0.0f)
        {
            DeathEvent.Invoke();
            StartCoroutine(DeathDelay());
        }
    }

    private IEnumerator DeathDelay()
    {
        // Wait for death delay
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }
}