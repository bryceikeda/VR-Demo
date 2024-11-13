using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBasic : MonoBehaviour
{
    [Tooltip("Value to use as the current health")]
    [SerializeField] float HP = 100f;

    [Tooltip("Value to use as the current health")]
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
        {
            HP -= damage.DamageAmount;
            if (HP < 0f)
            {
                HP = minHealth;
            }
        }
            

    }
}