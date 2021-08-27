using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   // [SerializeField]private int enemyColour;
    private Transform playerTransform;
    public GameManager.colourType enemyColour;
    public RoomManager room;


    private void Awake()
    {
        room = GetComponentInParent<RoomManager>();
    }
    public void Die()
    {
        room.enemysInRoom.Remove(this.gameObject);
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

    void FindPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }
}
