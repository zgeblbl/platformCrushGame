using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    public float pushForce = 1000f;
    private float movement;
    [SerializeField]
    private float speed = 5f;
    public Vector3 respawnPoint;
    private GameManager gameManager;
    public AudioSource crashSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rb.AddForce(0, 0, pushForce*Time.fixedDeltaTime);
        rb.velocity = new Vector3(movement*speed, rb.velocity.y, rb.velocity.z);
        FallDetector();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            crashSound.Play();
            gameManager.RespawnPlayer();
        }
    }
    private void FallDetector()
    {
        if (rb.position.y < -2f && rb.position.z<125)
        {
            gameManager.RespawnPlayer();
        }
        else if (rb.position.y < -2f)
        {
            gameManager.LevelUp();
        }
    }
}
