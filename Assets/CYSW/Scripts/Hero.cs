using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    Camera cam;
    public GameObject r;

    public float PlayerSpd = 0f;
    public float JumpPow = 0f;

    bool isJump = false; 

    Rigidbody2D rig;
    

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playMove();
    }

    private void Update()
    { 
    }

    void playDash()
    {

    }

    void playMove()
    {
        if (Input.GetKey(KeyCode.A))
            rig.velocity = new Vector2(-PlayerSpd, rig.velocity.y);
        if (Input.GetKey(KeyCode.D))
            rig.velocity = new Vector2(PlayerSpd, rig.velocity.y);

        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            rig.AddForce(Vector2.up * JumpPow);
            isJump = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
            rig.velocity = new Vector2(0, rig.velocity.y);
        if (Input.GetKeyUp(KeyCode.D))
            rig.velocity = new Vector2(0, rig.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isJump)
        {
            if (collision.collider.CompareTag("MAP"))
            {
                isJump = false;
            }
        }
    }
}
