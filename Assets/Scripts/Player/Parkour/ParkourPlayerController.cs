using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParkourPlayerController : MonoBehaviour
{
    public Rigidbody2D rb;      //设置成私有，简化界面，调试时可在最前面加[SerializeField]
    public Animator anim;       //动画
    public Collider2D coll;     //获得人物到地面的碰撞信息
    public float upspeed = 8;   //弹跳速度
    public float jumpforce;     //弹力
    public int Count;           //金币数量
    public Text CoinNum;        //金币显示


    void Update()
    {
        Movement();
        SwitchAnim();
    }


    void Movement()     //玩家操作
    {
        float hight = GetComponent<BoxCollider2D>().bounds.size.y;          //获取高度

        //按下空格键可以使方块跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //如果检测到在地面或者空气墙上则可以跳跃（避免出现连环跳）
            upwardForce(hight);
        }

        //主角的缩小放大
        if (transform.localScale.x > 0.9)
        {
            shrink();               //按下A键主角可以缩小
        }
        if (transform.localScale.x <= 1.5)
        {
            enlarge(hight);          //按下D键主角可以变大
        }
    }

    void SwitchAnim()       //动画切换
    {
        anim.SetBool("running", false);
        if (anim.GetBool("jumping"))
        {
            anim.SetBool("jumping", false);
            anim.SetBool("running", true);
        }
    }


    void upwardForce(float hight)       //向上的力
    {
        //在地面上
        if (Physics2D.Raycast(transform.position, Vector2.down, hight, LayerMask.GetMask("ParkourGround")))
        {
            rb.AddForce(Vector3.up * upspeed, ForceMode2D.Impulse);      //给它一个向上的力
        }
        //在空气墙上
        if (Physics2D.Raycast(transform.position, Vector2.down, hight, LayerMask.GetMask("AirWall")))
        {
            rb.AddForce(Vector3.up * upspeed, ForceMode2D.Impulse);      //给它一个向上的力
        }
    }

    void shrink()           //主角缩小
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, transform.localScale.z - 0.01f);     //形态变小
            upspeed = upspeed + 0.05f;                      //主角弹跳速度增大
            ParkourEnvironmentController.speed = 13f;       //障碍物移动速度增大
            ParkourBackgroundController.speed = 13f;        //背景移动速度增大
        }
    }

    void enlarge(float hight)          //主角变大
    {
        //检测到方块上面是空气墙则不能变大
        if (Physics2D.Raycast(transform.position, Vector2.up, 0.5f * hight, LayerMask.GetMask("AirWall")))
        {
            return;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, transform.localScale.z + 0.01f);     //形态变大
            upspeed = upspeed - 0.05f;                      //主角弹跳速度减小
            ParkourEnvironmentController.speed = 10f;       //障碍物移动速度减小
            ParkourBackgroundController.speed = 10f;        //背景移动速度减小
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)     //碰撞触发
    {
        //收集金币
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);      //销毁自身
            Count += 1;                         //金币数量+1
            CoinNum.text = Count.ToString();    //金币显示
        }

        //死亡复活
        if (collision.tag == "Die")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //重新加载当前场景
        }
    }
}
