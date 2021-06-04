using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimationController : MonoBehaviour
{
    private Animator anim;
    private PlayerWalkController walk;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        walk = GetComponent<PlayerWalkController>();
    }

    // Update is called once per frame
    void Update()
    {
        SetValues();
    }

    void SetValues()
    {
        anim.SetFloat("velocityX", walk.HorizontalInput);
        anim.SetFloat("velocityY", walk.VerticalInput);
    }
}
