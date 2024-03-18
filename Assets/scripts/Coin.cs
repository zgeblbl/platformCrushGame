using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;
    public int scoreValue;
    public AudioSource coinSound;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            gameManager.AddScore(scoreValue);
            coinSound.Play();
            Destroy(this.gameObject);
        }
    }

}
