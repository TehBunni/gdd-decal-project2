using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private float playerSpeed;
    #endregion
    
    #region Private Variables
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float moveX;
    private float moveY;

    private bool canMove;
    #endregion

    #region Initialization
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
        moveX = 0f;
        moveY = 0f;

        canMove = true;
    }
    #endregion

    #region Main Updates
    // Update is called once per frame
    private void Update()
    {
        moveX = 0f;
        moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Up", true);
            moveY = +1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Down", true);
            moveY = -1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true);
            moveX = +1f;
        }
        else
        {
            animator.SetBool("Idle", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Up", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Down", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Left", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Right", false);
        }

        // moveX = 0f;
        // moveY = 0f;

        // if (Input.GetKey(KeyCode.W)) moveY = +1f;
        // if (Input.GetKey(KeyCode.S)) moveY = -1f;
        // if (Input.GetKey(KeyCode.A)) moveX = -1f;
        // if (Input.GetKey(KeyCode.D)) moveX = +1f;

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        if (canMove)
        {
            transform.position += moveDir * playerSpeed * Time.deltaTime;
        }
    }

    public void ToggleMove()
    {
        canMove = !canMove;
    }
    #endregion
}
