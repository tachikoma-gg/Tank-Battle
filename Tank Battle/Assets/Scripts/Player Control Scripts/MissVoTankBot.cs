using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissVoTankBot : MonoBehaviour
{
    private TankController controller;

    [SerializeField] private float throttle;
    [SerializeField] private float steering;
    [SerializeField] private float launchForce;
    [SerializeField] private bool fire;

    [SerializeField] private Vector3 aimInput;

    void Start()
    {
        controller = GetComponent<TankController>();
    }

    void Update()
    {
        controller.MoveTank(throttle);
        controller.RotateTank(steering);
        controller.AimTank(aimInput);

        if(fire)
        {
            controller.FireWeapon(launchForce);
            fire = false;
        }
    }
}
