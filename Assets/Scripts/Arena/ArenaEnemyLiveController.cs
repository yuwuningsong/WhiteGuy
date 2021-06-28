using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnemyLiveController : MonoBehaviour
{
    public float totalHealth = 0;
    public float health = 0; //血量
    public float defense = 0; //防御力

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) isDead = true;
        Dead();
    }

    void Dead()
    {
        if (isDead)
        {
            //死亡动画+掉落武器
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //被攻击后根据防御力进行变幅扣血
        if (collision.CompareTag("Weapon"))
        {
            int attack = collision.gameObject.GetComponent<WeaponAttackController>().attack;
            health -= attack * (10 / defense);
        }
    }
}
