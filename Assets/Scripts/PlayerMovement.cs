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

    [SerializeField] float coyoteTime = 0.1f; // Bisa lompat dalam 0.1 detik setelah meninggalkan tanah
    [SerializeField] float gravityScale = 3f; // Lebih tinggi agar jatuh lebih cepat


    private enum MovementState { idle, walk, jump, fall }

    float dirX = 0f;
    private float lastGroundedTime; // Menyimpan waktu terakhir di tanah

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
        //rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); //jika masih hapus comment
        /*dirX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);

        }*/

        UpdateAnimation();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }


    void UpdateAnimation()
    {
        MovementState state;
        if (dirX != 0f) // Jika bergerak
        {
            state = MovementState.walk;
            sprite.flipX = dirX < 0;
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


    public void Jump()
    {
        if (isGrounded() || Time.time - lastGroundedTime <= coyoteTime)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            MusicManager.instance.JumpSFX();
            lastGroundedTime = -1f; // Reset agar tidak bisa lompat terus-menerus
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
