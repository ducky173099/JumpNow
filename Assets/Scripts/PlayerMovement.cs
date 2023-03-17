using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite; //bien truy cap thuoc tinhs trong component SpriteRenderer cua player
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState
    {
        idle, //anim 0
        running,//anim 1
        jumping,//anim 2
        falling//anim 3
    }

    [SerializeField] private AudioSource jumSoundEffect;


    // Start is called before the first frame update
    private void Start()
    {
        //rb.GetComponent<Rigidbody2D>();
        rb = GameObject.FindObjectOfType<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); //di chuyen sang 2 ben

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //jumping
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;


        if (dirX > 0f) //chay anim running, set sprite xoay truc X ben phai
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)//chay anim running, set sprite xoay truc X ben trai
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else //khi dung yen
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f) //khi bat dau jumping (nhay len)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)//khi bat dau falling (roi xuong)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);

    }

    //ham nay co tac dung nhu sau
    private bool IsGrounded()
    {
        //neu nhu player dang va cham voi ground thi cho phep jumping
        //neu nhu da jumping r, co nghia la k con va cham voi ground nua => k jumping dc
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
