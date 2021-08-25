using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private int enemyColour;

    public void Die()
    {
        Destroy(gameObject);
    }

    public int GetColour()
    {
        return enemyColour;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterController2D>().Die();
        }
    }
}
