using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Editor Variables
    private float playerSpeed;
    #endregion
    
    #region Private Variables
    // private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float moveX;
    private float moveY;
    #endregion

    #region Initialization
    // Start is called before the first frame update
    void Start()
    {
        // animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
        moveX = 0f;
        moveY = 0f;
        playerSpeed = 10f;
    }
    #endregion

    #region Main Updates
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     // animator.SetTrigger("Jump");
        //     // rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        //     Vector2 movementVector = new Vector2(0, playerSpeed);
        //     rb.MovePosition(rb.position + movementVector);
        // }
        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     // animator.SetBool("Speed", true);
        //     // transform.position = (Vector2)transform.position + new Vector2(5, 0) * Time.deltaTime;
        //     Vector2 movementVector = new Vector2(playerSpeed, 0);
        //     rb.MovePosition(rb.position + movementVector);
        //     // sr.flipX = false;
        // }
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     // animator.SetBool("Speed", true);
        //     // transform.position = (Vector2)transform.position + new Vector2(-5, 0) * Time.deltaTime;
        //     Vector2 movementVector = new Vector2(-playerSpeed, 0);
        //     rb.MovePosition(rb.position + movementVector);
        //     // sr.flipX = true;
        // }
        // if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     // animator.SetBool("Speed", false);
        //     Vector2 movementVector = new Vector2(0, -playerSpeed);
        //     rb.MovePosition(rb.position + movementVector);
        // }

        moveX = 0f;
        moveY = 0f;

        if (Input.GetKey(KeyCode.W)) moveY = +1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = +1f;

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += moveDir * playerSpeed * Time.deltaTime;
    }
    #endregion
}
