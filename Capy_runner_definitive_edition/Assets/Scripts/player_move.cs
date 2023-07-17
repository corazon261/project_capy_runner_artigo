using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D rig;

    public bool isJump;

    public bool c_ground;
    public Transform Detect_ground;
    public LayerMask Who_ground;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        c_ground = Physics2D.OverlapCircle(Detect_ground.position,0.2f,Who_ground);
        Move();
        Jump();
    }
    void Move(){

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * Speed;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && c_ground == true ){

            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
}
