using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissVoTankBot : MonoBehaviour
{
    private TankController controller;

    [SerializeField] private float throttle;
    [SerializeField] private float steering;

    void Start()
    {
        controller = GetComponent<TankController>();
    }

    void Update()
    {
        controller.MoveTank(throttle);
        controller.RotateTank(steering);
    }
}
