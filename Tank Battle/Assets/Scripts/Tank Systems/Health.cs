using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthMax;
    private float healthCurrent;

    // Explosion particle system

    void Start()
    {
        healthCurrent = healthMax;
    }

    public void TakeDamage(float damage)
    {
        healthCurrent -= damage;

        if(healthCurrent <= 0)
        {
            Destroy(gameObject);
        }
    }
}
