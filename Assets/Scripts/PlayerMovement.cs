using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumpableground;
    //private enum MovementState {idle , running , jump , fall}
    //MovementState state = MovementState.idle;
    [SerializeField] private float MoveSpeed = 10f;
    [SerializeField] private float JumpForce = 7f;
    [SerializeField] private AudioSource JumpSoundEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      float dirX = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(dirX*MoveSpeed,rb.velocity.y);
      //Debug.Log(rb.velocity.y);
      if (Input.GetKeyDown("space") && IsGrounded())
      {
        JumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x,JumpForce);
      }   
      // Start of editing running variable
      if (dirX>0){
        sprite.flipX= false;
        anim.SetBool("running",true);
      }
      else if (dirX<0){
        sprite.flipX= true;
        anim.SetBool("running",true);
      }
      else {
        anim.SetBool("running",false);
      }
      // End of editing running variable
      // Start of editing jump variable
      if (rb.velocity.y>=0.01){
        anim.SetBool("jump",true);
      }
      else {
        anim.SetBool("jump",false);
      }
      // End of jump variable
      //Start of fall variable
      if (rb.velocity.y<=-0.01){
        anim.SetBool("fall",true);
      }
      else {
        anim.SetBool("fall",false);
      }
      //end of fall variable
    }
    private bool IsGrounded(){
      return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,0.1f,jumpableground);
    }
}
