using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int a = 0;
    [SerializeField]
    private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pattern") && a == 0)
        {
            a++;
            Die();
        }
    }

    public void Die()
    {
        gameManager.GetComponent<GameManager>().GameOver();
        this.gameObject.GetComponent<PlayerMovement>().enabled = false;
    }
}
