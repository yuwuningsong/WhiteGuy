using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtController : MonoBehaviour
{
    public int health = 0;
    public bool isHurt = false;
    [SerializeField] int totalHealth = 0;
    [SerializeField] bool isDead = false;

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

    // 受伤
    public void Hurt(int attack)
    {
        health -= attack;
        isHurt = true;
        GetComponent<Animator>().SetTrigger("isHurt");
    }

    // 恢复
    public void Recover(int num)
    {
        health += num;
    }

    // 死亡
    void Dead()
    {
        if (isDead)
        {
            Debug.Log("YOU DEAD!");
        }
    }
}
