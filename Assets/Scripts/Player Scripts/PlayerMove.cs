using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D playerBody;
    private float moveForce_X = 1.5f, moveForce_Y = 1.5f;

    private PlayerAnimations playerAnimation;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimations>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(h > 0)
        {
            playerBody.velocity = new Vector2(moveForce_X, playerBody.velocity.y);
        } else if(h < 0)
        {
            playerBody.velocity = new Vector2(-moveForce_X, playerBody.velocity.y);
        } else
        {
            playerBody.velocity = new Vector2(0f, playerBody.velocity.y);
        }

        if(v > 0)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, moveForce_Y);
        } else if (v < 0)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, -moveForce_Y);
        } else
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, 0f);
        }

        // ANimate
        if (playerBody.velocity.x != 0 || playerBody.velocity.y != 0)
        {
            playerAnimation.PlayerRunAnimation(true);
        } else if (playerBody.velocity.x == 0 && playerBody.velocity.y == 0)
        {
            playerAnimation.PlayerRunAnimation(false);
        }

        Vector2 tempScale = transform.localScale;
        if (h > 0)
        {
            tempScale.x = -1f;
        } else if (h < 0)
        {
            tempScale.x = 1f;
        }

        transform.localScale = tempScale;
    }
}
