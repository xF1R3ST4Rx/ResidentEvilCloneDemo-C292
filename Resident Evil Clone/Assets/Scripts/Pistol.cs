using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    private void Start()
    {
        canFire = true;
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    protected override void Fire()
    {
        if (currentMag == null)
        {
            Debug.Log("No mag");
            return;
        }

        RaycastHit hit;
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, 100))
        {

            if (hit.transform.CompareTag("Zombie"))
            {
                hit.transform.GetComponent<Zombie>().TakeDamage(1);
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
        currentMag.Reload();
    }
}
