using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnemyAttackCloseController : MonoBehaviour
{
    [Header("Weapon")]
    public float attack = 0; //攻击力
    public float attackDistance = 0; //攻击距离

    [Header("Frequence")]
    [SerializeField] float attackTimeCounter = 0f;
    [SerializeField] float attackTimeLimit = 0f;

    [Header("Recent Status")]
    private Animator anim;
    [SerializeField] bool canAttack = true; //攻击频率
    [SerializeField] bool inDistance = false; //攻击距离

    private Transform playerFollow = null;
    private Rigidbody2D rb;
    private Animator animPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerFollow = GameObject.Find("ArenaPlayer").transform;
        anim = GetComponent<Animator>();
        animPlayer = GameObject.Find("ArenaPlayer").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (anim.GetBool("isDead")) return;
        FrequenceCheck();
        DistanceCheck();
        Attack();
    }

    void Attack()
    {
        //int defense = playerFollow.GetComponentInChildren<WeaponAttackController>().defense;
        if (inDistance && canAttack)
        {
            playerFollow.GetComponent<ArenaPlayerLiveController>().health -= attack;// * (10 / defense);
            anim.SetBool("isAttack", true);
            animPlayer.SetTrigger("isHurt");
            attackTimeCounter = attackTimeLimit;
            canAttack = false;
        }
    }

    void EndAttack()
    {
        anim.SetBool("isAttack", false);
    }

    //检查是否处于近战攻击范围内
    void DistanceCheck()
    {
        float x = GetComponent<Transform>().position.x - playerFollow.position.x;
        float y = GetComponent<Transform>().position.y - playerFollow.position.y;
        float z = attackDistance;
        if (x * x + y * y <= z * z)
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
