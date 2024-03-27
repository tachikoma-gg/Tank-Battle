using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");

        if(collision.gameObject.CompareTag("Tank"))
        {
            Debug.Log("hit tank");
            collision.gameObject.GetComponent<HitDetect>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
