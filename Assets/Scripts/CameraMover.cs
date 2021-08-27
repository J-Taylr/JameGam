using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public List<Transform> camPositions = new List<Transform>();
    public int room;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3f;

    bool moveRoom = false;

   

    void Start()
    {
        transform.position = camPositions[0].position;
       
    }

    private void Update()
    {
        if (moveRoom)
        {
            transform.position = Vector3.SmoothDamp(transform.position, camPositions[room].position, ref velocity, smoothTime);
        }
        
        if (transform.position == camPositions[room].position)
        {
            moveRoom = false;
        }
    }

    public void TransitionRoom(int roomNumber)
    {

        room = roomNumber;
        moveRoom = true;
    }
   
}
