using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   // [SerializeField]private int enemyColour;
    public GameManager.colourType enemyColour;

    public void Die()
    {
        Destroy(gameObject);
    }

   

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterController2D>().Die();
        }
        if (collider.CompareTag("Bullet"))
        {
          Bullet bullet = collider.GetComponent<Bullet>();

            if (bullet.KillColour == enemyColour)
            {
                Die();
            }
            else
            {
                bullet.Destroy();
            }

        }
    }
}
