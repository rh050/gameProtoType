using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public static Vector2 movement;
    public static int gameScore = 0;
    public static int hiderStopPlay = 0;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    string[] str;
    private bool canMove = false;
    public float waitTime = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        StartCoroutine(CountdownEvent(waitTime));
    }

    void Update()
    {
        movement.x = Input.GetAxis(nameof(InputStr.Horizontal));
        movement.y = Input.GetAxis(nameof(InputStr.Vertical));
        if (canMove)
        { 
            UpdateAnimation(); 
            if (movement.x < 0) 
            { 
                spriteRenderer.flipX = true;
            }
            else if (movement.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);
         }
    }
    

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * (speed * Time.fixedDeltaTime));
        }
    }
    
    IEnumerator CountdownEvent(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canMove = true; 
    }
 

    void UpdateAnimation()
    {
        if (movement.magnitude > 0)
        {
            animator.SetBool(nameof(InputStr.isWalking), true);
            animator.SetFloat(nameof(InputStr.inputX), movement.x);
            animator.SetFloat(nameof(InputStr.inputY), movement.y);
           
        }
        else
        { 
            animator.SetBool(nameof(InputStr.isWalking), false);
            animator.SetFloat(nameof(InputStr.lastInputX), movement.x);
            animator.SetFloat(nameof(InputStr.lastInputY), movement.y);
        }
    }
    
    

    enum InputStr
    {
        None,
        Horizontal,
        Vertical,
        isWalking,
        inputX,
        inputY,
        lastInputX,
        lastInputY
    }
}