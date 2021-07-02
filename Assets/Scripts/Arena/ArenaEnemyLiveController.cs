using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnemyLiveController : MonoBehaviour
{
    private Animator anim;

    public float totalHealth = 0;
    public float health = 0; //血量
    public float defense = 0; //防御力

    private bool isDead = false;
    private int leftWeapon = 0;

    [Header("Weapon")]
    [SerializeField] Transform weapon = null;
    private Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
        tf = GetComponent<Transform>();
        anim = GetComponent<Animator>();
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
            if (leftWeapon == 0)
            {
                Transform weaponLeft = Instantiate(weapon);
                weaponLeft.position = new Vector2(tf.position.x, tf.position.y);
                Destroy(weaponLeft.gameObject, 5f);
                leftWeapon++;
            }
            anim.SetBool("isDead", true);
            Destroy(gameObject, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //被攻击后根据防御力进行变幅扣血
        if (collision.CompareTag("Weapon"))
        {
            int attack = collision.gameObject.GetComponent<WeaponAttackController>().attack;
            health -= attack * (10 / defense);
            anim.SetBool("isHurt", true);
        }
    }

    void EndHurt()
    {
        anim.SetBool("isHurt", false);
    }
}
