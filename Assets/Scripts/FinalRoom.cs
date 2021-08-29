using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.gameActive = false;
            GameManager.Instance.SaveTime();
            GameManager.Instance.CompleteGame();
        }
    }
}
