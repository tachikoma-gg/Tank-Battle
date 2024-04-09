using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthMax;
    private float healthCurrent;
    public float healthPercentage
    {
        get
        {
            return healthCurrent/healthMax;
        }
    }

    void Start()
    {
        healthCurrent = healthMax;
    }

    void Update()
    {
        Debug.Log(healthPercentage);
    }

    public void TakeDamage(float damage)
    {
        healthCurrent -= damage;

        if(healthCurrent <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        // Explosion particle system
        // Recolor to scorched color
        Destroy(gameObject);
    }
}
