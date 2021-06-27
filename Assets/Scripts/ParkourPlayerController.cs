using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourPlayerController : MonoBehaviour
{
    public Rigidbody2D rb;      //设置成私有，简化界面，调试时可在最前面加[SerializeField]
    public Animator anim;
    public Collider2D coll;     //获得人物到地面的碰撞信息

    //public float speed;         //速度
    public float upspeed = 8;
    public float jumpforce;
    public LayerMask ground;    //下落碰地

    public bool IsJump = false;
    public bool IsStop = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SwitchAnim();
    }

    void Movement()
    {
        //float horizontalmove = Input.GetAxis("Horizontal");     //-1向左，0不动，1向右
        //float facedirection = Input.GetAxisRaw("Horizontal");

        //if (IsStop == false)
        //{
        //    //一直向右运动
        //    rb.transform.Translate(speed * Time.deltaTime, 0, 0);
        //}

        /*
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
        */

        float hight = GetComponent<BoxCollider2D>().bounds.size.y;

        //按下空格键可以使方块跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, hight, LayerMask.GetMask("ParkourGround")))
            {
                //给它一个向上的力
                upwardForce();
            }

            if (Physics2D.Raycast(transform.position, Vector2.down, hight, LayerMask.GetMask("Ceiling")))
            {
                //给它一个向上的力
                downwardForce();
            }
        }

        if (transform.localScale.x > 0.3)
        {
            //按下A键可以缩小方块
            shrink();
        }
        if (transform.localScale.x <= 1)
        {
            //按下D键可以变大方块
            //检测到方块上面是天花板则不能变大
            if (!Physics2D.Raycast(transform.position, Vector2.up, 0.5f * hight, LayerMask.GetMask("ceiling")))
            {
                enlarge();
            }
        }
    }

    void SwitchAnim()
    {
        anim.SetBool("running", false);
        if (anim.GetBool("jumping"))
        {
            anim.SetBool("jumping", false);
            anim.SetBool("running", true);
        }
    }

    void shrink()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, transform.localScale.z - 0.01f);
            //speed = speed + 0.05f;
            upspeed = upspeed + 0.05f;
        }
    }
    void enlarge()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, transform.localScale.z + 0.01f);
            //speed = speed - 0.05f;
            upspeed = upspeed - 0.05f;
        }
    }

    void upwardForce()
    {
        rb.AddForce(Vector3.up * upspeed, ForceMode2D.Impulse);
    }

    void downwardForce()
    {
        rb.AddForce(Vector3.up * upspeed, ForceMode2D.Impulse);
    }

}
