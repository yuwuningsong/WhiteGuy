using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnemyAttackRemoteController : MonoBehaviour
{
    [Header("Frequence")]
    [SerializeField] float attackTimeCounter = 0f;
    [SerializeField] float attackTimeLimit = 0f;

    [Header("Recent Status")]
    [SerializeField] bool isAttack = false; //攻击动画
    [SerializeField] bool canAttack = true; //攻击频率
    [SerializeField] bool inDistance = false; //攻击距离

    [Header("Player Follow")]
    [SerializeField] Rigidbody2D playerFollow = null;

    [Header("Bullet")]
    [SerializeField] GameObject bullet = null;

    private Rigidbody2D rb;
    private Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        FrequenceCheck();
        DistanceCheck();
        Attack();
    }

    void Attack()
    {
        //创建新攻击物体并为其设定方向
        if (inDistance && canAttack)
        {
            //Vector3 position = new Vector3(tf.position.x, tf.position.y, 0);
            //GameObject newBullet = Instantiate(bullet, tf, false);
            //GameObject newBullet1 = Instantiate(bullet, tf, true);
            //newBullet.transform.localScale = new Vector3(tf.localScale.x, 0, 0);
            isAttack = true;
            attackTimeCounter = attackTimeLimit;
            canAttack = false;
        }
    }

    void DistanceCheck()
    {
        float x = tf.position.x - playerFollow.GetComponent<Transform>().position.x;
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
