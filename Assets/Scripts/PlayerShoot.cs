using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]private Transform firepoint;
    [SerializeField]private GameObject bulletPrefab;
    private int bulletColour = 0;
    private int ammo = 4;
    private int reloads = 0;

    void Update()
    {
        HandleShooting();
        HandleAmmo();
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
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (ammo > 0)
        {   
            //Instantiate the bullet and send it what colour it should be
            GameObject bulletInstance = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            bulletInstance.GetComponent<Bullet>().SetColour(bulletColour);
            ammo--;
            bulletColour++;
        }
        else
        {
            Debug.Log("Empty!");
        }
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
