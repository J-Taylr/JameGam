using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // [SerializeField]private int enemyColour;
    private Transform playerTransform;
    public GameManager.colourType enemyColour;
    public RoomManager room;

    public GameObject death;

    private void Start()
    {
        room = GetComponentInParent<RoomManager>();
    }
    public void Die()
    {
        
        Instantiate(death, transform.position, Quaternion.identity);
        SendColourMessage();
        room.enemysInRoom.Remove(this.gameObject);
        Destroy(gameObject);
    }

    


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.CompareTag("Player"))
        {
            GameManager.Instance.PlayerDeath();
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


    public void SendColourMessage()
    {
        switch (enemyColour)
        {
            case GameManager.colourType.RED:
                
                room.ColourBackground("Red");
                break;
            case GameManager.colourType.GREEN:
                
                room.ColourBackground("Green");
                break;
            case GameManager.colourType.BLUE:
                

                room.ColourBackground("Blue");
                break;
            case GameManager.colourType.YELLOW:
               

                room.ColourBackground("Yellow");
                break;
        }
    }
}
