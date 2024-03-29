using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    [SerializeField] private int rotationDirection;

    private readonly float rotationSpeed = 135;
    private TankController tankController;

    void Start()
    {
        tankController = GetComponentInParent<TankController>();
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * (tankController.input.z + 2 * tankController.input.x * rotationDirection) * Time.deltaTime * Vector3.right);
    }
}
