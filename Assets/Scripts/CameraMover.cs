using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public List<Transform> camPositions = new List<Transform>();
  

    private void Awake()
    {
    }

   

    void Start()
    {
        transform.position = camPositions[0].position;
       
    }

    public void TransitionRoom(int roomNumber)
    {
       
       
        if (camPositions[roomNumber] != null)
        {
            transform.position = camPositions[roomNumber].position;
            
        }
    }
   
}
