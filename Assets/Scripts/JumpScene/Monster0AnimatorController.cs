using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster0AnimatorController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorSetting();
    }

    void AnimatorSetting()
    {
        anim.SetBool("isRun", true);
    }
}
