using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField]private Transform firepoint;
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField] private AimWeapon aimWeapon;

    private int bulletColour = 0;
    public int standardAmmoReset = 4;
    public int ammo = 4;
    private int reloads = 0;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        aimWeapon = GetComponent<AimWeapon>();
    }

    void Update()
    {
        HandleShooting();
        HandleAmmo();
    }

    public void ResetAmmo()
    {
        ammo = standardAmmoReset;
    }

    public void AddReload(int reloads)
    {
        this.reloads += reloads;
    }

    public int GetReloads()
    {
        return reloads;
    }

    void HandleShooting()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Shot!");
            Shoot();
        }
    }

    void Shoot()
    {
        if (ammo > 0)
        {
            FireBullet();
        }
        else
        {
            Debug.Log("Empty!");
        }
    }

    void FireBullet()
    {
       

        //Instantiate the bullet and send it what colour it should be
        GameObject GO = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet bulletinstance = GO.GetComponent<Bullet>();
        bulletinstance.SetColour();
        bulletinstance.MoveBullet(rb.velocity, rb.velocity.magnitude);
        ammo--;
        bulletColour++;
    }

    //Resets the player ammo loaded if reloads are avaiable
    //Resets the color counter
    void HandleAmmo()
    {
        if (ammo <= 0 && reloads > 0)
        {
                ammo = 4;
        }

        if (bulletColour >= 4)
        {
            bulletColour = 0;
        }
    }
}
