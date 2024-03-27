using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody rocketRb;
    private float launchForce;

    void Start()
    {
        launchForce = GetComponentInParent<TankController>().launchForce;
        rocketRb = GetComponent<Rigidbody>();
        rocketRb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
    }
}
