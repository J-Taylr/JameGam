using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        //DontDestroyOnLoad(this.gameObject);
    }
    //starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere


    public enum colourType {RED, GREEN, BLUE, YELLOW}
    public colourType colour;

    public Transform lastSpawn;
    public GameObject player;
    public CharacterController2D playerController;
    public Animator UIAnim;

    public bool dead;
    public bool gameActive;
    public float time;
    public TextMeshProUGUI timeText;

    public Color A_Red;
    public Color A_Blue;
    public Color A_Green;
    public Color A_Yellow;

    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<CharacterController2D>();

        A_Red = new Color(0.9803922f, 0, 0.1803922f, 1);
        A_Blue = new Color(0, 0.1803922f, 0.9803922f, 1);
        A_Green = new Color(0.09803922f, 0.9803922f, 0.254902f, 1);
        A_Yellow = new Color(0.9803922f, 0.7568628f, 0.09803922f, 1);

        gameActive = true;
    }

    private void Update()
    {

        StopWatch();
        FullReset();
        
    }


    public void StopWatch()
    {
        if (gameActive)
        {
            time += Time.deltaTime;
        }

        DisplayTime(time);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = (timeToDisplay % 1) * 1000;

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes,seconds, milliseconds);
    }


    public void NextColour()
    {

        if (colour == colourType.YELLOW)
        {
            colour = 0;
        }
        else
        {
            colour += 1;
        }
        
    }


    public void SetSpawn(Transform spawn)
    {
        print("spawn set");
        lastSpawn.transform.position = spawn.transform.position;
    }


    public void ResetRoom()
    {
       
        colour = 0;
        playerController.EnableScripts();
        player.transform.position = lastSpawn.transform.position;
        PlayerShoot shooter = player.GetComponentInChildren<PlayerShoot>();
        shooter.ammo = shooter.standardAmmoReset;
        dead = false;
        gameActive = true;

    }

    public void PlayerDeath()
    {
        if (!dead)
        {
            gameActive = false;
            dead = true;
            UIAnim.SetTrigger("Death");
            playerController.Die();
        }
    }

    public void FullReset()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
            

            

            gameActive = true;
        }
    }
}
