using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomIdentifier : MonoBehaviour
{
    CameraMover cameraMover;
    BoxCollider2D col;

    public int roomNumber = 1;

    private void Awake()
    {
        cameraMover = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMover>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            
            print("transitioning to " + roomNumber);
            cameraMover.TransitionRoom(roomNumber);

        }
    }

   
   
    
}
