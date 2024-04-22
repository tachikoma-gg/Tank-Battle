using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthMax;
    [SerializeField] private float healthCurrent;

    private float _healthPercentage;
    public float HealthPercentage
    {
        get
        {
            return _healthPercentage;
        }
    }

    void Start()
    {
        healthCurrent = healthMax;
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

    void Update()
    {
        _healthPercentage = healthCurrent / healthMax;
        _healthPercentage = Mathf.Clamp(_healthPercentage, 0, 1);
    }
}
