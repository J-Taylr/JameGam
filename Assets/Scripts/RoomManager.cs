using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public CameraMover cam;

    public int roomNum = 1;

    public Animator LockedDoor;

    public bool roomActive = false;
    public bool roomCleared = false;

    public List<GameObject> enemysInRoom = new List<GameObject>();

    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraMover>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            roomActive = true;
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
        if (enemysInRoom.Count <= 0)
        {
            roomCleared = true;
            LockedDoor.SetTrigger("openDoor");
        }
    }
}
