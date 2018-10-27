using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveX;
    public float moveY;
    public int playerSpeed = 10;
    public int jump = 500;
    public int jumps = 0;
    public bool facingRight;
    private Rigidbody2D rigidbodie;
    public float yVelocity;

    // Use this for initialization
    void Start () {
        facingRight = true;
        rigidbodie = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        yVelocity = rigidbodie.velocity.y;
        Jump();
        moveX = Input.GetAxis("Horizontal");
        gameObject.GetComponent<Animator>().SetFloat("speed", Mathf.Abs(moveX));
        moveY = Input.GetAxis("Vertical");
        rigidbodie.velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetKeyDown("up") && jumps < 2)
        {
            jumps++;
            rigidbodie.AddForce(Vector2.up * jump);
            gameObject.GetComponent<Animator>().SetInteger("State", 3);
        }
        if (moveX > 0.0f && facingRight == false)
        {
            FlipX();
        }
        else if (moveX < 0.0f && facingRight == true)
        {
            FlipX();
        }


    }

    void Jump()
    {
        if(rigidbodie.velocity.y > 0)
        {
            gameObject.GetComponent<Animator>().SetInteger("state", 3);
        }
        else if (rigidbodie.velocity.y < 0)
        {
            gameObject.GetComponent<Animator>().SetInteger("state", 1);
        }
        else
        {
            jumps = 0;
            gameObject.GetComponent<Animator>().SetInteger("state", 0);
        }
    }

    void FlipX()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
