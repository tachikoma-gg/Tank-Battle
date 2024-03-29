using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissVoTankBot : MonoBehaviour
{
    private TankController controller;

    private float throttle;
    private float steering;
    private float launchForce = 50;

    private Vector3 aimInput;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<TankController>();
    }

    void Update()
    {
        throttle = Input.GetAxis("Vertical");
        steering = Input.GetAxis("Horizontal");

        aimInput.x = Input.GetAxis("Mouse X");
        aimInput.y = Input.GetAxis("Mouse Y");

        controller.MoveTank(throttle);
        controller.RotateTank(steering);
        controller.AimTank(aimInput);

        if(Input.GetMouseButtonDown(0))
        {
            controller.FireWeapon(launchForce);
        }
    }
}
