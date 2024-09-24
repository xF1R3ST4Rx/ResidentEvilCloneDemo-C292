using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    private void Start()
    {
        ammoCapacity = 10;
        currentAmmo = ammoCapacity;
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    protected override void Fire()
    {
        if (currentAmmo > 0)
        {
            Debug.Log("Pistol Fired");
            currentAmmo--;

            {
                RaycastHit hit;
                if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, 100))
                {
                    Debug.DrawRay(firePoint.position, firePoint.forward * hit.distance, Color.red, 2f);
                    if (hit.transform.CompareTag("Zombie"))
                    {
                        hit.transform.GetComponent<Zombie>().TakeDamage(1);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Out of Ammo");
        }
    }
    protected override void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }
    private IEnumerator ReloadCoroutine()
    {
        canFire = false;

        yield return new WaitForSeconds(reloadtime);
        Debug.Log("Reload");
        canFire = true;
        currentAmmo = ammoCapacity;
    }
}
