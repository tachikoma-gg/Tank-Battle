using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetect : MonoBehaviour
{
    public void TakeDamage(float damage)
    {
        GetComponentInParent<Health>().TakeDamage(damage);
    }
}
