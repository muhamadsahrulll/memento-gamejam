using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    public MusicManager MusicManager;
    [SerializeField] float jump = 0f;
    [SerializeField] float moveSpeed = 7f;


    private enum MovementState { idle, walk, jump, fall }

    float dirX;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update velocity berdasarkan dirX
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        /*dirX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);

        }*/

        UpdateAnimation();

    }

    void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.walk;
            sprite.flipX = false;
            // Karakter bergerak ke kanan

        }
        else if (dirX < 0f)
        {
            state = MovementState.walk;
            sprite.flipX = true;
            // Karakter bergerak ke kiri

        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }



    // Dipanggil saat tombol ditekan
    public void PointerDownLeft()
    {
        dirX = -1f; // Bergerak ke kiri
        MusicManager.instance.PlayFootStep();
    }

    public void PointerDownRight()
    {
        dirX = 1f; // Bergerak ke kanan
        MusicManager.instance.PlayFootStep();
    }

    // Dipanggil saat tombol dilepas
    public void PointerUp()
    {
        dirX = 0f; // Berhenti
        MusicManager.instance.StopFootStep();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            MusicManager.instance.JumpSFX();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            MusicManager.instance.PlaySFX(MusicManager.Landing);
        }
    }
}
