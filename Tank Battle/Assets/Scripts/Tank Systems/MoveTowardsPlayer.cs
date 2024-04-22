using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private float speed = 5f;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = FindObjectOfType<MissVoTankBot>().gameObject.transform;
    }

    void Update()
    {
        transform.LookAt(playerTransform.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
