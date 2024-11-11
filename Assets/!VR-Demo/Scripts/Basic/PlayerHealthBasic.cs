using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBasic : MonoBehaviour
{
    [SerializeField] float HP = 100f;
    [SerializeField] float minHealth = 0f;
    [SerializeField] float maxHealth = 100f;

    // Add getter for healthPoints
    public float CurrentHealth
    {
        get { return HP; }
    }

    public float MinHealth
    { 
        get { return minHealth; } 
    }

    public float MaxHealth
    {
        get { return maxHealth;}
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
        if (damage != null)
            HP -= damage.DamageAmount;
    }
}