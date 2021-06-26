using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLiveController : MonoBehaviour
{
    [SerializeField] int totalHealth = 0;
    public int health = 0;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            int attack = collision.gameObject.GetComponent<WeaponAttackController>().attack;
            health -= attack;
            collision.gameObject.GetComponentInParent<PlayerHurtController>().health += attack;
        }
        if (collision.CompareTag("Player"))
        {
            int attack = GetComponent<MonsterAttackController>().attack;
            collision.gameObject.GetComponentInParent<PlayerHurtController>().health -= attack;
            health += attack;
        }
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
