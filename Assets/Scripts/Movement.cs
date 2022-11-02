using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private States State
    {
        get { return (States)anim.GetInteger("state");}
        set { anim.SetInteger("state", (int)value);}
    } 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Run()
    {
        State = States.run;
        Vector3 dir_x = transform.right * Input.GetAxisRaw("Horizontal");
        Vector3 dir_y = transform.up * Input.GetAxisRaw("Vertical");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir_x + dir_y, speed * Time.deltaTime);
        sprite.flipX = dir_x.x < 0.0f;
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