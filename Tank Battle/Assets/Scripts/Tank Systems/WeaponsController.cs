using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    [SerializeField]private GameObject ammoPrefab;
    private GameObject weapon;
    private GameObject firingPoint;

    private bool armed = true;

    [SerializeField] private float cooldown;

    void Awake()
    {
        GetComponent<TankController>().FireWeaponEvent += FireWeapon;
    }

    void FireWeapon()
    {
        if(armed)
        {
            armed = false;
            GameObject ammo = Instantiate(ammoPrefab, firingPoint.transform.position, weapon.transform.rotation);
            ammo.transform.SetParent(transform);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        armed = true;
    }
}
