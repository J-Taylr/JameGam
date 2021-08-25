using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    private int bulletColour;
    private float bulletSpeed = 10;

    private float bulletX;
    private float bulletY;

    void Start()
    {
        Debug.Log(bulletColour);
    }

    void FixedUpdate()
    {
        
    }

    public void MoveBullet(Quaternion rotation)
    {
        rb.AddForce(-transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        print(other.gameObject.name);
        Destroy(gameObject);
    }

    public void SetColour(int bulletColour)
    {
        this.bulletColour = bulletColour;
    }

    public int GetColour()
    {
        return bulletColour;
    }
}
