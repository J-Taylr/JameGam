using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowAttack : MonoBehaviour
{
    [SerializeField] private Transform yellowTransform;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float yellowRange = 10f;
    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
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
        Debug.Log("Got it!");
    }
}
