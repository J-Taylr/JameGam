using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum ColourType {Red, Green, Blue, Yellow}
    public ColourType colour;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if bullet its equal to colour type, destroy
        //otherwise do nothing
        //if player touches enemy, destroy player 
    }
}
