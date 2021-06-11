using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourPlayerController : MonoBehaviour
{
    public Rigidbody2D rb;      //设置成私有，简化界面，调试时可在最前面加[SerializeField]
    public Animator anim;
    public Collider2D coll;     //获得人物到地面的碰撞信息

    public float speed;         //速度
    public float jumpforce;
    public LayerMask ground;    //下落碰地



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SwitchAnim();
    }

    void Movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");     //-1向左，0不动，1向右
        //float facedirection = Input.GetAxisRaw("Horizontal");

        // 角色移动
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
            //anim.SetFloat("running", Mathf.Abs(facedirection));
        }
        

        // 角色跳跃
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
            anim.SetBool("jumping", true);
        }
    }

    void SwitchAnim()
    {
        anim.SetBool("running", false);
        // TO DO:减少嵌套
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)      //降落
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
            else if (coll.IsTouchingLayers(ground))     //下落碰到地面
            {
                anim.SetBool("falling", false);
                anim.SetBool("running", true);
            }
        }
        
    }

}
