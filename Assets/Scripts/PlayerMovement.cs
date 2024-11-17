using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;       // Kecepatan gerakan horizontal
    public float jumpForce = 10f;     // Kekuatan lompatan

    private Rigidbody2D rb;           // Komponen Rigidbody2D
    private bool isGrounded = false;  // Apakah karakter sedang di tanah

    private SpriteRenderer spriteRenderer; // Komponen SpriteRenderer untuk flipping

    [Header("Ground Check")]
    public Transform groundCheck;     // Posisi pengecekan tanah
    public float groundCheckRadius = 0.2f; // Radius pengecekan tanah
    public LayerMask groundLayer;     // Layer yang dianggap tanah

    void Start()
    {
        // Ambil komponen Rigidbody2D dan SpriteRenderer
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Gerakan horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip sprite berdasarkan arah gerakan
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // Menghadap kanan
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // Menghadap kiri
        }

        // Melompat
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Cek apakah karakter sedang di tanah
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
