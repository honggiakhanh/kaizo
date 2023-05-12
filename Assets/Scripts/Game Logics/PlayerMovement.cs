using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
    public float jumpForce = 10f;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button backButton;
    private bool isGrounded;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Animator anim;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        float moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        
        isGrounded = IsGrounded();
        anim.SetBool("IsJumping", !isGrounded);
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(col.bounds.center, Vector2.down, col.bounds.extents.y + .3f);
        return raycastHit.collider != null;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            GameManager.Instance.EndGame();
            replayButton.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);
        }
    }
}
