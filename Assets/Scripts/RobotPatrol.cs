using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPatrol : MonoBehaviour
{
    public float leftBoundary = 71f; // Batas kiri
    public float rightBoundary = 75f; // Batas kanan
    public float speed = 2f; // Kecepatan robot

    private bool movingRight = true; // Arah gerakan
    private SpriteRenderer spriteRenderer; // Komponen SpriteRenderer

    public MusicManager MusicManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Patrol();
    }

    //fungsi patroli robot
    private void Patrol()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= rightBoundary)
            {
                movingRight = false;
                FlipSprite();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBoundary)
            {
                movingRight = true;
                FlipSprite();
            }
        }
    }

    private void FlipSprite()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX; // Membalik sprite pada sumbu X
        }
    }
}
