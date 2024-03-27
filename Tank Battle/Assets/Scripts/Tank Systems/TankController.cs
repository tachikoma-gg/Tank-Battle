using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private Collider[] colliders;

    [SerializeField] private GameObject firingPoint;

    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float acceleration;

    [SerializeField] private float cooldown;

    private Vector3 input;

    private bool armed = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        for(int i = 0; i < colliders.Length; i++)
        {
            Physics.IgnoreCollision(controller, colliders[i]);
        }
    }

    public void MoveTank(float throttle)
    {
        if(Mathf.Abs(throttle) <= 1)
        {
            float targetInput = speed * throttle;
            input.z = Mathf.Lerp(input.z, targetInput, acceleration * Time.deltaTime);

            controller.Move(transform.forward * input.z * Time.deltaTime);
        }
        else
        {
            Debug.Log(gameObject.name + "Error: Invalid throttle value.");
        }
    }

    public void RotateTank(float rotate)
    {
        if(Mathf.Abs(rotate) <= 1)
        {
            float targetInput = rotateSpeed * rotate;
            input.x = Mathf.Lerp(input.x, targetInput, acceleration * Time.deltaTime);

            transform.Rotate(Vector3.up * input.x * Time.deltaTime);
        }
        else
        {
            Debug.Log(gameObject.name + "Error: Invalid steering value.");
        }
    }

    // rotate turret. Take Vector3. x y to move, z is 0;

    public void FireWeapon()
    {
        if(armed)
        {
            armed = false;
            StartCoroutine(Cooldown());

            // Fire weapon
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        armed = true;
    }
}
