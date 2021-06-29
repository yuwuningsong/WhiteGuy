using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLiveController : MonoBehaviour
{
    [SerializeField] int totalHealth = 0;
    [SerializeField] int attack = 0; // 攻击力
    public int health = 0;

    private bool isDead = false;
    private bool isHurt = false;

    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalHealth < health) totalHealth = health;
        if (health <= 0) isDead = true;
        Dead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            int attack = collision.gameObject.GetComponent<WeaponAttackController>().attack;
            Hurt(attack);
            collision.gameObject.GetComponentInParent<PlayerHurtController>().Recover(attack);
        }
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerHurtController>().Hurt(attack);
            Recover(attack);
        }
    }

    // 受伤
    public void Hurt(int attack)
    {
        health -= attack;
        isHurt = true;
    }

    // 恢复
    public void Recover(int num)
    {
        health += num;
    }

    void Dead()
    {
        if (isDead)
        {
            health = 0;
            Debug.Log("Monster is DEAD!");
        }
    }
}
