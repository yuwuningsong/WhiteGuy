using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private JumpController jumpController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpController = GetComponent<JumpController>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorSetting();
    }

    // Kid's animator settings
    void AnimatorSetting()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isJump", jumpController.GetIsJump());
        anim.SetFloat("velocityY", rb.velocity.y);
        anim.SetBool("isGround", jumpController.GetIsGround());
    }
}
