using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private float degrees = 180;

    private Rigidbody2D rb;
    private Animator anim;
    Vector2 movement;

    private States State
    {
        get { return (States)anim.GetInteger("state");}
        set { anim.SetInteger("state", (int)value);}
    } 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Run()
    {
        State = States.run;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Flip();
    }

    private void Flip()
    {
        degrees = movement.x < 0f?180:0;
        Vector3 rotate = transform.eulerAngles;
        rotate.y = degrees;
        transform.rotation = Quaternion.Euler(rotate);
    }

    private void FixedUpdate()
    {
        State = States.idle;
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            Run();
    }
}
public enum States
{
    idle,
    run,
    death
}