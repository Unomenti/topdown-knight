using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class movementPlayer : MonoBehaviour
{
    // Speed
    public float moveSpeed;
    // Input
    public Vector2 moveInput;
    // Rigid Body
    public Rigidbody2D rigidBody;
    // Animator
    public Animator anim;
    
    // Coin int
    public int coinCounter;
    // Coin Text
    public TextMeshProUGUI coinText;
    // Health points
    public int health;
    // Health Text
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody Component
        rigidBody = GetComponent<Rigidbody2D>();
        // Animator Component
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = moveInput * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Horizontal", moveInput.x);
        anim.SetFloat("Vertical", moveInput.y);
        anim.SetFloat("Speed", moveInput.sqrMagnitude);

        healthText.text = "HP: " + health.ToString();
        coinText.text = coinCounter.ToString();

        if (health <= 0)
        {
            moveSpeed = 0;
            healthText.text = "R.I.P.";
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            coinCounter++;
            Destroy(collision.gameObject);
        }
    }

    private void OnMove(InputValue inputvalue)
    {
        moveInput = inputvalue.Get<Vector2>();
    }
}
