using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnemyAttackRemoteController : MonoBehaviour
{
    [Header("Frequence")]
    [SerializeField] float attackTimeCounter = 0f;
    [SerializeField] float attackTimeLimit = 0f;

    [Header("Recent Status")]
    private Animator anim;
    [SerializeField] bool canAttack = true; //攻击频率
    [SerializeField] bool inDistance = false; //攻击距离

    [Header("Player Follow")]
    [SerializeField] Transform playerFollow = null;

    [Header("Bullet")]
    [SerializeField] Transform bullet = null;

    private Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        playerFollow = GameObject.Find("ArenaPlayer").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (anim.GetBool("isHurt")) return;
        FrequenceCheck();
        DistanceCheck();
        Attack();
    }

    void Attack()
    {
        //创建新攻击物体并为其设定方向
        if (inDistance && canAttack)
        {
            Transform newBullet = Instantiate(bullet);
            newBullet.position = new Vector2(tf.position.x, tf.position.y);  //生成的子弹以人物为起始位置
            newBullet.localScale = new Vector3(tf.localScale.x, 1, 1);  //改变子弹图片方向
            newBullet.gameObject.GetComponent<ArenaEnemyAttackRemoteWeaponController>().faceDirection
                = (int)tf.localScale.x;  //调整子弹飞行方向

            anim.SetBool("isAttack", true);
            attackTimeCounter = attackTimeLimit;
            canAttack = false;
        }
    }

    void EndAttack()
    {
        anim.SetBool("isAttack", false);
    }

    //检查敌人是否在可攻击方向
    void DistanceCheck()
    {
        float x = tf.position.x - playerFollow.position.x;
        float y = tf.localScale.x;
        if ((x > 0 && y == -1) || (x < 0 && y == 1))
        {
            inDistance = true;
        }
        else
        {
            inDistance = false;
        }
    }

    //检查攻击冷却cd是否走完
    void FrequenceCheck()
    {
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        else
        {
            canAttack = true;
        }
    }
}
