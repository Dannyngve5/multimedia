using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerScript : MonoBehaviour
{

    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rb2D;
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJummpMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("d") || Input.GetKey("right")){
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);

        }else if(Input.GetKey("a") || Input.GetKey("left")){
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
        }else{
            rb2D.velocity = new Vector2(0,rb2D.velocity.y ); 
        }
        if ((Input.GetKey("w") || Input.GetKey("up")) &&  CheckGround.isGrounded ){
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed) ;
        }
        if (betterJump){
            if(rb2D.velocity.y < 0){ 
                rb2D.velocity += Vector2.up*Physics2D.gravity.y*(fallMultiplier)*Time.deltaTime;
            }
            if(rb2D.velocity.y > 0 && (!Input.GetKey("w") || !Input.GetKey("up"))){
                rb2D.velocity += Vector2.up*Physics2D.gravity.y*(lowJummpMultiplier)*Time.deltaTime;
            }

        }

    }
}
