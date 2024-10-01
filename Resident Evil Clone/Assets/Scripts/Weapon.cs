using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{ 
    [SerializeField] protected magazine currentMag;
    [SerializeField] protected float fireRate;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float damage;
    [SerializeField] protected bool canFire;
    [SerializeField] protected float reloadtime;

    public magazine CurrentMag { get => currentMag; set=>currentMag = value; }
    protected virtual void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    protected virtual void Fire()
        {

        }
    protected virtual void Reload()
        {

        }
}
