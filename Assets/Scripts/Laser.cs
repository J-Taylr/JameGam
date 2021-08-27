using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float laserSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MoveLaser(Transform playerTransform)
    {
        Debug.Log(playerTransform.position);
        rb.AddRelativeForce(playerTransform.position * laserSpeed, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        GameObject collider = collisionInfo.gameObject;
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterController2D>().Die();
        }
        Destroy(gameObject);
    }
}
