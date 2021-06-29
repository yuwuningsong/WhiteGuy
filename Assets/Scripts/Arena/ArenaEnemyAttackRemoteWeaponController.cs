using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnemyAttackRemoteWeaponController : MonoBehaviour
{
    [Header("Weapon")]
    public float attack = 0; //攻击力
    //public float attackDistance = 0; //攻击距离
    public float speed = 0; //飞行速度

    [Header("Recent Status")]
    public int faceDirection = 0;
    //public float distanceRemain = 0; //剩余可以飞的距离

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Fly();
    }

    void Fly()
    {
        rb.velocity = new Vector2(faceDirection * speed, rb.velocity.y);
        //distanceRemain -= speed * Time.deltaTime;
        //if (distanceRemain <= 0)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //箭撞到主角给主角扣血
        if (collision.CompareTag("Player"))
        {
            //float defense = collision.gameObject.GetComponentInChildren<WeaponAttackController>().defense;
            //collision.gameObject.GetComponent<ArenaPlayerLiveController>().health -= attack * (10 / defense);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //撞到碰撞体停留一段时间销毁
        Destroy(gameObject, .5f);
    }
}
