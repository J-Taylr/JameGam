using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowAttack : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform yellowTransform;
    [SerializeField] private Transform firepoint;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float yellowRange = 10f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float maxTimer = 1f;
    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        AttackCooldown();
    }

    void DetectPlayer()
    {
        Collider2D collider = Physics2D.OverlapCircle(yellowTransform.position, yellowRange, layer.value);
        if (collider && canAttack)
        {
            Attack(collider.GetComponent<Transform>());
        }
    }

    void Attack(Transform playerTransform)
    {
        GameObject laserInstance = Instantiate(laserPrefab, firepoint.position, playerTransform.rotation);
        laserInstance.GetComponent<Laser>().MoveLaser(playerTransform);
        canAttack = false;
    }

    void AttackCooldown()
    {   
        if (!canAttack)
        {
                attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                attackCooldown = maxTimer;
                canAttack = true;
            }
        }
    }
}
