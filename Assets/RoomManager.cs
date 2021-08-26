using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int roomNum = 1;

    public GameObject LockedDoor;

    public bool roomActive = false;
    public bool roomCleared = false;

    public List<GameObject> enemysInRoom = new List<GameObject>();

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
        }
    }

    private void Update()
    {
        if (enemysInRoom.Count <= 0)
        {
            roomCleared = true;
            LockedDoor.SetActive(false);
        }
    }
}
