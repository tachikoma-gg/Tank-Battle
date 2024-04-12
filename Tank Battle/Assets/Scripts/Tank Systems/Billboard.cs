using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private Vector3 direction;

    void Update()
    {
        direction = transform.position - playerCamera.transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
