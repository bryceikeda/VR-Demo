using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthFloatVariable : MonoBehaviour
{
    public FloatVariable HP;

    public bool ResetHP;

    public FloatVariable StartingHP;

    private void Start()
    {
        if (ResetHP)
            HP.SetValue(StartingHP.Value);
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
        if (damage != null)
            HP.ApplyChange(-damage.DamageAmount);
    }
}