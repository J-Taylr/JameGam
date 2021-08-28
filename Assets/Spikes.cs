using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float power = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !GameManager.Instance.dead)
        {
           Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
            player.AddForce(new Vector3(0,1,1) * power, ForceMode2D.Impulse);
            GameManager.Instance.PlayerDeath();
            
        }
    }
}
