using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private Rigidbody2D rb;
    public Vector3 LaunchOffset;
    public float runSpeed = 40f;
    private Animator anim;
    private SpriteRenderer playerSpriteRenderer;
    private float horizontalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("jump", true);
        }
        else
        {
            //jump = false;
            anim.SetBool("jump", false);
        }


        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetBool("running", true);
            //anim.Update(1f);
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
