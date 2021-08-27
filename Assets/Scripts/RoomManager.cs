using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public CameraMover cam;

    public int roomNum = 1;
    public Transform spawnPoint;

    public Animator LockedDoor;

    public bool roomActive = false;
    public bool resetting = false;
    public bool roomCleared = false;

    public List<GameObject> enemysInRoom = new List<GameObject>();

    [Header("enemys")]
    public GameObject redEnemy;
    public GameObject blueEnemy;
    public GameObject greenEnemy;
    public GameObject yellowEnemy;

    public Transform redspwn;
    public Transform bluespwn;
    public Transform greenspwn;
    public Transform yellowspwn;


    private void Awake()
    {
        
        cam = Camera.main.GetComponent<CameraMover>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            roomActive = true;
            collision.GetComponentInChildren<PlayerShoot>().ResetAmmo();
            GameManager.Instance.SetSpawn(spawnPoint);
        }
    }
    


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            roomActive = false;
            
            cam.TransitionRoom(roomNum);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !resetting)
        {
            resetting = true;
            ResetRoom();
        }

        if (enemysInRoom.Count <= 0 && !resetting)
        {
            roomCleared = true;
            
            LockedDoor.SetBool("openDoor", true);
        }
    }


    public void ResetRoom()
    {
        if (roomActive)
        {
            
            LockedDoor.SetBool("openDoor", false);
            GameManager.Instance.ResetRoom();
            foreach (var item in enemysInRoom)
            {
                
                Destroy(item);
            }
            enemysInRoom.Clear();
            print("test");
            var newRed = Instantiate(redEnemy, redspwn.position, Quaternion.identity);
            newRed.transform.parent = this.gameObject.transform;
            enemysInRoom.Add(newRed);

            var newBlue = Instantiate(blueEnemy, bluespwn.position, Quaternion.identity);
            newBlue.transform.parent = this.gameObject.transform;
            enemysInRoom.Add(newBlue);

            var newGreen = Instantiate(greenEnemy, greenspwn.position, Quaternion.identity);
            newGreen.transform.parent = this.gameObject.transform;
            enemysInRoom.Add(newGreen);

            var newYellow = Instantiate(yellowEnemy, yellowspwn.position, Quaternion.identity);
            newYellow.transform.parent = this.gameObject.transform;
            enemysInRoom.Add(newYellow);
            

        }
        resetting = false;
    }
}
