using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    private int bulletColour;
    private float bulletSpeed = 10f;

    void Start()
    {
        Debug.Log(bulletColour);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(bulletSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
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
