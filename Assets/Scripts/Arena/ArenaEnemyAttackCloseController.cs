using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnemyAttackCloseController : MonoBehaviour
{
    public float attack = 0; //攻击力
    public float attackDistance = 0; //攻击距离
    public float attackFrequence = 0; //攻击频率

    [SerializeField] float attackTimeCounter = 0f;
    [SerializeField] float attackTimeLimit = 0f;

    [Header("Recent Status")]
    [SerializeField] bool isAttack = false; //攻击动画
    [SerializeField] bool canAttack = true; //攻击频率
    [SerializeField] bool inDistance = false; //攻击距离

    [Header("Player Follow")]
    [SerializeField] Rigidbody2D playerFollow = null;

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
        FrequenceCheck();
        DistanceCheck();
        //Attack();
    }

    void Attack()
    {
        int defense = playerFollow.gameObject.GetComponentInChildren<WeaponAttackController>().defense;
        if (inDistance && canAttack)
        {
            playerFollow.GetComponent<ArenaPlayerLiveController>().health -= attack * (10 / defense);
            isAttack = true;
            attackTimeCounter = attackTimeLimit;
            canAttack = false;
        }
    }

    void DistanceCheck()
    {
        float x = GetComponent<Transform>().position.x - playerFollow.GetComponent<Transform>().position.x;
        float y = GetComponent<Transform>().position.y - playerFollow.GetComponent<Transform>().position.y;
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
