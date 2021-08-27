using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sprite;
    public List<GameObject> particlePrefab = new List<GameObject>();
    public GameManager.colourType KillColour;
    public TrailRenderer trail;
    public float bulletSpeed = 10;

    private float bulletX;
    private float bulletY;

    public int bulletLife = 3;
   
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        trail = GetComponentInChildren<TrailRenderer>();
    }

    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        
    }

    public void MoveBullet(Vector2 vel, float mag)
    {
        rb.AddForce(vel * mag);
        rb.AddForce(-transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject collider = collision.gameObject;
        if (collider.CompareTag("Enemy"))
        {
            Destroy();
        }
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterController2D>().Die();
            Destroy();
        }
        if (collider.CompareTag("Ground"))
        {
            bulletLife--;
            if (bulletLife <= 0)
            {
                Destroy();
            }
        }
        
    }

    public void SetColour()
    {
        switch (GameManager.Instance.colour)
        {
            case GameManager.colourType.RED:
                KillColour = GameManager.colourType.RED;
                sprite.color = GameManager.Instance.A_Red;
                SpawnParticle("red");

                break;
            case GameManager.colourType.GREEN:
                KillColour = GameManager.colourType.GREEN;
                sprite.color = GameManager.Instance.A_Green;
                SpawnParticle("green");
                break;

            case GameManager.colourType.BLUE:
                KillColour = GameManager.colourType.BLUE;
                sprite.color = GameManager.Instance.A_Blue;
                SpawnParticle("blue");
                break;
            

            case GameManager.colourType.YELLOW:
                KillColour = GameManager.colourType.YELLOW;
                sprite.color = GameManager.Instance.A_Yellow;
                SpawnParticle("yellow");
                break;
        }
        trail.startColor = sprite.color;
        GameManager.Instance.NextColour();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void SpawnParticle(string colour)
    {
        switch (colour)
        {
            case "red":
                Instantiate(particlePrefab[0], transform.position, Quaternion.identity);

                break;
            case "green":
                Instantiate(particlePrefab[1], transform.position, Quaternion.identity);
                break;
            case "blue":
                Instantiate(particlePrefab[2], transform.position, Quaternion.identity);
                break;

            case "yellow":
                Instantiate(particlePrefab[3], transform.position, Quaternion.identity);
                break;
        }
    }
    
}
