using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    

    [SerializeField] private Collider[] colliders;
    private readonly float gravity = -9.8f;

    [Header("Movement")]
    private CharacterController controller;

    private readonly float speed = 15;
    private readonly float rotateSpeed = 30;

    private Vector3 velocity;
    private Vector3 _input;
    public Vector3 input
    {
        get
        {
            return _input;
        }
    }

    [Header("Aiming")]
    private readonly float aimRate = 30;
    private readonly float aimAngleMin = -5;
    private readonly float aimAngleMax = 15;

    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject turret;

    private Vector3 aimDirection;

    [Header("Weapons")]
    private bool armed = true;
    private readonly float launchForceMax = 50;

    [SerializeField] private float cooldown;
    [SerializeField] private GameObject shellPrefab;
    [SerializeField] private GameObject firingPoint;

    private float _launchForce;
    public float launchForce
    {
        get
        {
            return _launchForce;
        }
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();

        for(int i = 0; i < colliders.Length; i++)
        {
            Physics.IgnoreCollision(controller, colliders[i]);
        }
    }

    void LateUpdate()
    {
        velocity.y = (controller.isGrounded && velocity.y <= 1) ? -2f : (velocity.y + gravity * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);
    }

    public void MoveTank(float _throttle)
    {
        _input.z = Mathf.Abs(_throttle) <= 1 ? speed * _throttle : speed * _throttle / Mathf.Abs(_throttle);
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(0, 0, _input.z);

        velocity.x = move.x;
        velocity.z = move.z;
    }

    public void RotateTank(float _rotate)
    {
        _input.x = Mathf.Abs(_rotate) <= 1 ? _input.x + Time.deltaTime * rotateSpeed * _rotate : _input.x + Time.deltaTime * rotateSpeed * _rotate / Mathf.Abs(_rotate);
        _input.x = Mathf.Abs(_input.x) >= 360 ? _input.x - 360 * _input.x / Mathf.Abs(_input.x) : _input.x;

        transform.rotation = Quaternion.AngleAxis(_input.x, Vector3.up);
    }

    public void AimTank(Vector3 _aimInput)
    {
        aimDirection.y = Mathf.Abs(_aimInput.x) <= 1 ? aimDirection.y + Time.deltaTime * aimRate * _aimInput.x : aimDirection.y + Time.deltaTime * aimRate * _aimInput.x / Mathf.Abs(_aimInput.x);
        aimDirection.x = Mathf.Abs(_aimInput.y) <= 1 ? aimDirection.x + Time.deltaTime * aimRate * _aimInput.y : aimDirection.x + Time.deltaTime * aimRate * _aimInput.y / Mathf.Abs(_aimInput.y);
        aimDirection.y = Mathf.Abs(aimDirection.y) >= 360 ? aimDirection.y - 360 * aimDirection.y / Mathf.Abs(aimDirection.y) : aimDirection.y;
        aimDirection.x = Mathf.Clamp(aimDirection.x, aimAngleMin, aimAngleMax);

        turret.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + aimDirection.y, 0);
        cannon.transform.rotation = Quaternion.Euler(0, turret.transform.eulerAngles.y, 0) * Quaternion.AngleAxis(aimDirection.x, Vector3.left);
    }

    public void FireWeapon(float _force)
    {
        _launchForce = _force;
        _launchForce = Mathf.Clamp(_launchForce, 0, launchForceMax);

        if(armed)
        {
            armed = false;
            GameObject shell = Instantiate(shellPrefab, firingPoint.transform.position, cannon.transform.rotation);
            shell.transform.SetParent(transform);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        armed = true;
    }
}
